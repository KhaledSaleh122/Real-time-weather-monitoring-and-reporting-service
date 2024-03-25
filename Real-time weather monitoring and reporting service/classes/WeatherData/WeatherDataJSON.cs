using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    public class WeatherDataJSON : IWeatherDataParser
    {
        public bool TryParse(string text, out WeatherDataModel? weatherData)
        {
            try
            {
                weatherData = JsonSerializer.Deserialize<WeatherDataModel>(text);
                if (weatherData is null || string.IsNullOrWhiteSpace(weatherData.Location)) return false;
                return true;

            }
            catch
            {
                weatherData = null;
                return false;
            }
        }

    }
}
