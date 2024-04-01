// See https://aka.ms/new-console-template for more information

using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.classes.Logger;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.UI;
IBotDataSource botDataSource = new BotsDataFile("./Config/Botconfig.json");
IBotSystem botSystem = new BotSystem();
foreach (var item in botDataSource.GetBots())
{
    botSystem.Subscribe(item);
}
IMessageViewer messageViewer = new WeatherMessageViewer();
IWeatherUI weatherUI = new WeatherUI(messageViewer);

weatherUI.CollectWeatherData(botSystem);

