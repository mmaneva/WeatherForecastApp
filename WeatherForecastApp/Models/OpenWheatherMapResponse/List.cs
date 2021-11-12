using System.Collections.Generic;

namespace WeatherForecastApp.Models.OpenWheatherMapResponse
{
    public class List
    {
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public Temp temp { get; set; }
        public FeelsLike feels_like { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
        public int clouds { get; set; }
        public double pop { get; set; }
    }
}
