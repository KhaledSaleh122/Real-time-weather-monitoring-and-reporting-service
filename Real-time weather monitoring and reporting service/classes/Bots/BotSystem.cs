using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    public class BotSystem : IBotSystem
    {
        private readonly List<IBotListner> botListners = [];
        public BotSystem()
        {
        }
        public void Subscribe(IBotListner botListner)
        {
            botListners.Add(botListner);
        }

        public void Notify(IWeatherDataModel weatherData)
        {
            botListners.ForEach((bot) => bot.Update(weatherData.Temperature, weatherData.Humidity));
        }
    }
}
