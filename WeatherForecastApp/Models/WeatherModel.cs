using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecastApp.Models
{
    public class WeatherModel
    {
        public string City { get; set; }
        public string Description { get; set; }
        public float Temperature { get; set; }
        public int Humidity { get; set; }
    }
}