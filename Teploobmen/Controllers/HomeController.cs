using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Teploobmen.Data;
using Teploobmen.Models;
using TeploobmenLibrary;

namespace labwork2_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        private int _userId;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out _userId);
        }

        [HttpPost]
        public IActionResult Result(TeploobmenInput input)
        {
            //Сохранение варианта
            if (!string.IsNullOrEmpty(input.Name))
            {
                var existOption = _context.Options.FirstOrDefault(x => x.Name == input.Name);

                if (existOption != null)
                {
                    // Обновление варианта
                    existOption.H = input.H;
                    existOption.t1 = input.t1;
                    existOption.T = input.T;
                    existOption.w = input.w;
                    existOption.C = input.C;
                    existOption.Gm = input.Gm;
                    existOption.Cm = input.Cm;
                    existOption.d = input.d;
                    existOption.a = input.a;

                    _context.Options.Update(existOption);
                    _context.SaveChanges();
                }
                else
                {
                    //добавление варианта
                    var Option = new Option
                    {
                        Name = input.Name,
                        H = input.H,
                        t1 = input.t1,
                        T = input.T,
                        w = input.w,
                        C = input.C,
                        Gm = input.Gm,
                        Cm = input.Cm,
                        d = input.d,
                        a = input.a,
                        UserId = _userId,
                        CreatedAt = DateTime.Now
                    };

                    _context.Options.Add(Option);
                    _context.SaveChanges();
                }
            }
            //Выполнение расчёта
            var lib = new TeploobmenCalc(input);
            var result = lib.calc();
            if (ModelState.IsValid)
                return View(result);
            TempData["message"] = $"Заполните все поля";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Index(int? OptionId)
        {
            var viewModel = new HomeIndexViewModel();

            if (OptionId != null)
            {
                viewModel.Option = _context.Options
                    .Where(x => x.UserId == _userId || x.UserId == 0)
                    .FirstOrDefault(x => x.Id == OptionId);
            }

            viewModel.Options = _context.Options
                .Where(x => x.UserId == _userId || x.UserId == 0)
                .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Remove(int? OptionId)
        {
            var Option = _context.Options
                .Where(x => x.UserId == _userId || x.UserId == 0)
                .FirstOrDefault(x => x.Id == OptionId);

            if (Option != null)
            {
                _context.Options.Remove(Option);
                _context.SaveChanges();

                TempData["message"] = $"Вариант {Option.Name} удален.";
            }
            else
            {
                TempData["message"] = $"Вариант не найден.";
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}