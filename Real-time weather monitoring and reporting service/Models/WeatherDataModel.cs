using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.Model
{
    public class WeatherDataModel : IWeatherDataModel
    {
        public required string Location { get; set; }

        public required double Temperature { get; set; }

        public required double Humidity { get; set; }
    }

}
