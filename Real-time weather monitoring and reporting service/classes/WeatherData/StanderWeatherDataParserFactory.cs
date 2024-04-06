using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    public class StanderWeatherDataParserFactory : WeatherDataParserFactory
    {
        public override IWeatherDataParser CreateParser(WeatherDataParserType weatherDataParser)
        {
            if (weatherDataParser == WeatherDataParserType.JSON)
            {
                return new JsonWeatherDataParser();
            }
            else if (weatherDataParser == WeatherDataParserType.XML)
            {
                return new XmlWeatherDataParser();
            }
            else
            {
                throw new Exception("Unknow Parser Type");
            }
        }
    }
}
