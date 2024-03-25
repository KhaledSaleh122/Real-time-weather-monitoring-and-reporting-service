using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    public class WeatherDataProvider
    {
        private readonly IWeatherDataParser _parser;
        public WeatherDataProvider(IWeatherDataParser parser)
        {
            _parser = parser;
        }
        public WeatherDataModel GetWeatherData(string data)
        {
            if (_parser.TryParse(data, out var weatherData))
            {
                return weatherData!;
            }
            throw new Exception("Invaild data format");
        }
    }
}
