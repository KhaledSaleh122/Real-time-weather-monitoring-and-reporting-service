﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    public class WeatherDataProvider : IWeatherDataProvider
    {
        private readonly IWeatherDataParser _parser;
        private readonly WeatherDataParserFactory _parserFactory;
        public WeatherDataProvider(WeatherDataParserFactory factory, WeatherDataParserType parserType)
        {

            _parserFactory = factory;
            _parser = factory.CreateParser(parserType);
        }
        public IWeatherDataModel GetWeatherData(string data)
        {
            if (_parser.TryParse(data, out var weatherData))
            {
                return weatherData!;
            }
            throw new Exception("Invaild data format");
        }
    }
}
