using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    public abstract class WeatherDataParserFactory
    {
        public abstract IWeatherDataParser CreateParser(WeatherDataParserType weatherDataParser);
        public IWeatherDataParser GetParser(WeatherDataParserType weatherDataParser)
        {
            IWeatherDataParser parser = CreateParser(weatherDataParser);
            return parser;
        }
    }
}
