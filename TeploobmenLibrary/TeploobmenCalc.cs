﻿using System.Security.Cryptography.X509Certificates;

namespace TeploobmenLibrary
{
    public class TeploobmenCalc
    {
        public double H; //Высота слоя (м)
        public double t1; //Начальная температура окатышей (градусы)
        public double T1; //Начальная температура воздуха (градусы)
        public double w; //Скорость вохдуха на свободное сечение шахты (м/с)
        public double C; //Средняя теплоёмкость воздуха при 200 градусах (кДж/(кг*К)
        public double Gm; //Расход окатышей
        public double Cm; //Теплоёмкость окатышей
        public double d; //Диаметр аппарата (м)
        public double a; //Объемный коэффициент теплоотдачи
        public

        TeploobmenCalc(TeploobmenInput input) //конструктор класса
        {
            H = input.H;
            t1 = input.t1;
            T1 = input.T;
            w = input.w;
            C = input.C;
            Gm = input.Gm;
            Cm = input.Cm;
            d = input.d;
            a = input.a;
        }

        public TeploobmenOutput calc() //Необходимые расчёты
        {
            double S = 3.14 * ((d / 2) * (d / 2));
            double m = (Gm * Cm) / (w * C * S);
            double Y0 = (H * a * S) / (w * C * S * 1000);
            double form1 = 1 - m * Math.Exp(((m - 1) * Y0) / m);
            int j;
            List<double> x = new List<double>();
            for (double i = 0; i <= H; i = i + 0.5)
            {
                x.Add(0 + i);
            }
            List<double> y = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                y.Add(Math.Round((((a * x[j]) / (w * C * 1000))), 2));
            }
            List<double> exp1 = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                exp1.Add(Math.Round(1 - Math.Exp(((m - 1) * y[j]) / m), 2));
            }
            List<double> exp2 = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                exp2.Add(Math.Round(1 - m * Math.Exp(((m - 1) * y[j]) / m), 2));
            }
            List<double> v = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                v.Add(Math.Round((exp1[j] / form1), 2));
            }
            List<double> o = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                o.Add(Math.Round((exp2[j] / form1), 2));
            }

            List<double> t = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                t.Add(Math.Round(Math.Abs(((T1 - t1) * v[j]) + t1), 0));
            }
            List<double> T = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                T.Add(Math.Round(Math.Abs(((T1 - t1) * o[j]) + t1), 0));
            }
            List<double> t_t = new List<double>();
            for (j = 0; j < x.Count; j++)
            {
                t_t.Add(Math.Round(Math.Abs(t[j] - T[j]), 2));
            }
            return new TeploobmenOutput
            {
                square = Math.Round(S, 4),
                relationship = Math.Round(m, 4),
                layer_height = Math.Round(Y0, 4),
                coordinata = x.GetRange(0, x.Count),
                Y = y.GetRange(0, y.Count),
                exp1 = exp1.GetRange(0, exp1.Count),
                exp2 = exp2.GetRange(0, exp2.Count),
                V = v.GetRange(0, v.Count),
                O = o.GetRange(0, o.Count),
                t = t.GetRange(0, t.Count),
                T = T.GetRange(0, T.Count),
                t_T = t_t.GetRange(0, t_t.Count)
            };
        }
    }
}