// See https://aka.ms/new-console-template for more information

using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.UI;
IBotDataSource botDataSource = new BotsDataFile("./Config/Botconfig.json");
var botSystem = new BotSystem();
foreach (var item in botDataSource.GetBots())
{
    botSystem.Subscribe(item);
}
WeatherUI.CollectWeatherData(botSystem);

