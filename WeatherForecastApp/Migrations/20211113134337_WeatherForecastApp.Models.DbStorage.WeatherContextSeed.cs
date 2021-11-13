using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecastApp.Migrations
{
    public partial class WeatherForecastAppModelsDbStorageWeatherContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "Id", "Day", "LanguageDay", "OrderNumber" },
                values: new object[,]
                {
                    { 1, "Monday", "en", 1 },
                    { 2, "Понеделник", "mk", 1 },
                    { 3, "Tuesday", "en", 2 },
                    { 4, "Вторник", "mk", 2 },
                    { 5, "Wednesday", "en", 3 },
                    { 6, "Среда", "mk", 3 },
                    { 7, "Thurstdau", "en", 4 },
                    { 8, "Четврток", "mk", 4 },
                    { 9, "Friday", "en", 5 },
                    { 10, "Петок", "mk", 5 },
                    { 11, "Saturday", "en", 6 },
                    { 12, "Сабота", "mk", 6 },
                    { 13, "Sunday", "en", 7 },
                    { 14, "Недела", "mk", 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DaysOfWeek",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
