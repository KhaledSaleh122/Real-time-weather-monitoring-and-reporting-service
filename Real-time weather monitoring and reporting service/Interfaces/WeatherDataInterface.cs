using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public interface IWeatherDataParser
    {
        bool TryParse(string text, out WeatherDataModel? weatherData);
    }
}
