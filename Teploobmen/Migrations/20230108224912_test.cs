using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teploobmen.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    H = table.Column<double>(type: "REAL", nullable: false),
                    t1 = table.Column<double>(type: "REAL", nullable: false),
                    T = table.Column<double>(type: "REAL", nullable: false),
                    w = table.Column<double>(type: "REAL", nullable: false),
                    C = table.Column<double>(type: "REAL", nullable: false),
                    Gm = table.Column<double>(type: "REAL", nullable: false),
                    Cm = table.Column<double>(type: "REAL", nullable: false),
                    d = table.Column<double>(type: "REAL", nullable: false),
                    a = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Options");
        }
    }
}
