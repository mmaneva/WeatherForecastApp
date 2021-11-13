using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastApp.Models.WeatherForecastResponse;

namespace WeatherForecastApp.Services
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherDto>> GetWeatherForecastAsync(string city, DateTime? date, string language);
    }
}
