using System.Collections.Generic;

namespace WeatherForecastApp.Models.DbStorage
{
    public class DaysOfWeek
    {
        public DaysOfWeek()
        {
            WeathersInfo = new HashSet<WeatherInfo>();
        }

        public int Id { get; set; }
        public string Day { get; set; }
        public string LanguageDay { get; set; }
        public int OrderNumber { get; set; }

        public virtual ICollection<WeatherInfo> WeathersInfo { get; set; }
    }
}
