using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastApp.Models.WeatherForecastResponse;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string city, [FromQuery] DateTime date, [FromQuery] string language)
        {
            WeatherDto weather = await _weatherForecastService.GetWeatherForecastAsync(city, date, language);
            return Ok(weather);
        }
    }
}
