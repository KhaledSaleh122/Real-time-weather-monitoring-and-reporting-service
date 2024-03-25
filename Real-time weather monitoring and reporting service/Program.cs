// See https://aka.ms/new-console-template for more information

using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.UI;
IBotDataSource botDataSource = new BotsDataFile("C:\\Users\\khale\\source\\repos\\Real-time weather monitoring and reporting service\\Real-time weather monitoring and reporting service\\Config\\Botconfig.json");
var botSystem = new BotSystem(botDataSource);
WeatherUI.CollectWeatherData(botSystem);

