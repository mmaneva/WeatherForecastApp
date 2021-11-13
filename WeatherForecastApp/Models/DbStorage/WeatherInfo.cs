using System;

namespace WeatherForecastApp.Models.DbStorage
{
    public class WeatherInfo
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime? Date { get; set; }
        public double Temperatura { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int? DayId { get; set; }

        public virtual DaysOfWeek Day { get; set; }
    }
}
