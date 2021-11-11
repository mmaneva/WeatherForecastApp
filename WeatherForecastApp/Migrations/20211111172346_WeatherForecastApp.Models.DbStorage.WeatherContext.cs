using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecastApp.Migrations
{
    public partial class WeatherForecastAppModelsDbStorageWeatherContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysOfWeek",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LanguageDay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfWeek", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "SearchCity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchCity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Temperatura = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Temp_min = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Temp_max = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    dayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Weather__dayId__36B12243",
                        column: x => x.dayId,
                        principalTable: "DaysOfWeek",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherInfo_dayId",
                table: "WeatherInfo",
                column: "dayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchCity");

            migrationBuilder.DropTable(
                name: "WeatherInfo");

            migrationBuilder.DropTable(
                name: "DaysOfWeek");
        }
    }
}
