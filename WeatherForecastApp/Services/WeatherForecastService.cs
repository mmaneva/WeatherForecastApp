using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecastApp.Config;
using WeatherForecastApp.Models.DbStorage;
using WeatherForecastApp.Models.OpenWheatherMapResponse;
using WeatherForecastApp.Models.WeatherForecastResponse;

namespace WeatherForecastApp.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        WeatherContext _weatherContext;

        public WeatherForecastService(WeatherContext weatherContext)
        {
            _weatherContext = weatherContext;
        }

        HttpClient httpClient = new HttpClient();

        public async Task<WeatherDto> GetWeatherForecastAsync(string city, DateTime date, string language)
        {
            string IDWeather = Constants.OPEN_WEATHER_APPID;

            var URL = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&units=metric&cnt={7}&appid={IDWeather}";

            HttpResponseMessage responseThirdParty = await httpClient.GetAsync(URL);

            string responseBody = await responseThirdParty.Content.ReadAsStringAsync();

            Root jsonResponse = JsonConvert.DeserializeObject<Root>(responseBody);

            WeatherDto weatherDto = new WeatherDto();

            weatherDto.city = jsonResponse.city.name;
            weatherDto.temp = jsonResponse.list[0].temp.day;
            weatherDto.tomorrowTemp = jsonResponse.list[1].temp.day;

            SearchCity dbCity = new SearchCity
            {
                CityName = city,
                Date = UnixTimeToDateTime(jsonResponse.list[0].dt),
                Time = UnixTimeToDateTime(jsonResponse.list[0].dt).TimeOfDay
            };

            await _weatherContext.AddAsync(dbCity);

            await _weatherContext.SaveChangesAsync();

            return weatherDto;
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
    }
}
