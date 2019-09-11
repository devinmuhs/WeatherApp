using System;
using System.IO;
using Newtonsoft.Json;

namespace WeatherApp
{
    class WeatherData
    {
        public string month { get; set; }
        public string dayOfMonth { get; set; }
        public string julianDay { get; set; }
        public string normalMaxTemp { get; set; }
        public string normalMinTemp { get; set; }
        public string normalPrecipitation { get; set; }
    }
}
