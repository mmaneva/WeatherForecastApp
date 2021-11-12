﻿using System.Collections.Generic;

namespace WeatherForecastApp.Models.OpenWheatherMapResponse
{
    public class Root
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
    }
}
