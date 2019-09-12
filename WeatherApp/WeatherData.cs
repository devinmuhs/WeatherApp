using System;
using System.IO;
using Newtonsoft.Json;

namespace WeatherApp
{
    class WeatherData
    {
        public string Month { get; set; }
        public string DayOfMonth { get; set; }
        public string JulianDay { get; set; }
        public string NormalMaxTemp { get; set; }
        public string NormalMinTemp { get; set; }
        public string NormalPrecipitation { get; set; }
    }
}
