using Real_time_weather_monitoring_and_reporting_service.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    public class BotSystem
    {
        private readonly List<IBotListner> botListners = [];
        public BotSystem(IBotDataSource source)
        {
            foreach (var item in source.GetBots())
            {
                Subscribe(item);
            }
        }
        public void Subscribe(IBotListner botListner)
        {
            botListners.Add(botListner);
        }

        public void Notify(double temperature, double humidity)
        {
            botListners.ForEach((bot) => bot.Update(bot.Threshold == Threshold.humidity ? humidity : temperature));
        }
    }
}
