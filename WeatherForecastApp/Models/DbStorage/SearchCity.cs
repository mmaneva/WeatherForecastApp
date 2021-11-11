using System;

namespace WeatherForecastApp.Models.DbStorage
{
    public class SearchCity
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
    }
}
