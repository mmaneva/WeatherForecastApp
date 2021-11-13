using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<WeatherDto>> GetWeatherForecastAsync(string city, DateTime? date, string language)
        {
            string IDWeather = Constants.OPEN_WEATHER_APPID;

            var URL = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&units=metric&cnt={7}&appid={IDWeather}";

            HttpResponseMessage responseThirdParty = await httpClient.GetAsync(URL);

            string responseBody = await responseThirdParty.Content.ReadAsStringAsync();

            Root jsonResponse = JsonConvert.DeserializeObject<Root>(responseBody);

            List<WeatherDto> weatherDto = new List<WeatherDto>();

            if (!date.HasValue)
            {   
                for(int i = 0; i < 3; i++)
                {
                    DateTime dt = UnixTimeToDateTime(jsonResponse.list[i].dt).AddDays(i);
                    int dayNumber = (int)dt.DayOfWeek;
                    DaysOfWeek daysOfWeek = _weatherContext.DaysOfWeeks.Where(x => x.OrderNumber == dayNumber & language == x.LanguageDay).FirstOrDefault();

                    weatherDto.Add(new WeatherDto { city = jsonResponse.city.name, temp = jsonResponse.list[i].temp.day });

                    if (daysOfWeek != null)
                    {

                        WeatherInfo dbweatherInfo = new WeatherInfo
                        {
                            CityName = city,
                            Date = dt,
                            Temperatura = jsonResponse.list[i].temp.day,
                            TempMax = jsonResponse.list[i].temp.max,
                            TempMin = jsonResponse.list[i].temp.min,
                            DayId = daysOfWeek.Id
                        };

                        await _weatherContext.AddAsync(dbweatherInfo);
                    }
                    
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    DateTime dt = UnixTimeToDateTime(jsonResponse.list[i].dt).AddDays(i);
                    int dayNumber = (int)dt.DayOfWeek;
                    DaysOfWeek daysOfWeek = _weatherContext.DaysOfWeeks.Where(x => x.OrderNumber == dayNumber & language == x.LanguageDay).FirstOrDefault();

                    weatherDto.Add(new WeatherDto { city = jsonResponse.city.name, temp = jsonResponse.list[i].temp.day });

                    if (daysOfWeek != null)
                    {

                        WeatherInfo dbweatherInfo = new WeatherInfo
                        {
                            CityName = city,
                            Date = dt,
                            Temperatura = jsonResponse.list[i].temp.day,
                            TempMax = jsonResponse.list[i].temp.max,
                            TempMin = jsonResponse.list[i].temp.min,
                            DayId = daysOfWeek.Id
                        };

                        await _weatherContext.AddAsync(dbweatherInfo);
                    }
                }
            }

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
