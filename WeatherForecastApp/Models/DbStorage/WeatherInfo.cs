namespace WeatherForecastApp.Models.DbStorage
{
    public class WeatherInfo
    {
        public int Id { get; set; }
        public decimal? Temperatura { get; set; }
        public decimal? TempMin { get; set; }
        public decimal? TempMax { get; set; }
        public int? DayId { get; set; }

        public virtual DaysOfWeek Day { get; set; }
    }
}
