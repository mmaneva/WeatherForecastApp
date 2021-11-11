using System;
using System.Threading.Tasks;
using WeatherForecastApp.Models.WeatherForecastResponse;

namespace WeatherForecastApp.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherDto> GetWeatherForecastAsync(string city, DateTime date, string language);
    }
}
