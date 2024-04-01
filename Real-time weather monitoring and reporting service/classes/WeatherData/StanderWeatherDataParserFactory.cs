﻿using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    internal class StanderWeatherDataParserFactory : WeatherDataParserFactory
    {
        public override IWeatherDataParser CreateParser(WeatherDataParser weatherDataParser)
        {
            if (weatherDataParser == WeatherDataParser.JSON)
            {
                return new JsonWeatherDataParser();
            }
            else if (weatherDataParser == WeatherDataParser.XML)
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
