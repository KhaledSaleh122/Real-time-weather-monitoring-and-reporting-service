// See https://aka.ms/new-console-template for more information

using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.classes.Logger;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.UI;
IBotSystem botSystem = new BotSystem();
IBotDataSource botDataSource = new BotsDataFile("./Config/Botconfig.json", new StanderBotsFactory(), botSystem);
botDataSource.LoadBots();
IMessageViewer messageViewer = new WeatherMessageViewer();
IWeatherUI weatherUI = new WeatherUI(messageViewer, botSystem);

weatherUI.CollectWeatherData();

