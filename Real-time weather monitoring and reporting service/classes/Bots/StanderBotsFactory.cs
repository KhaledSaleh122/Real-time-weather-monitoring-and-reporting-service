using Real_time_weather_monitoring_and_reporting_service.classes.Bots;
using Real_time_weather_monitoring_and_reporting_service.classes.Logger;
using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;


namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    public class StanderBotsFactory : BotFactory
    {
        private readonly ILogger _logger = new ConsoleLogger();
        public override IBotListner CreateBot(string botName, double temperature, double humidity, string message)
        {
            if (botName == "RainBot")
            {
                return new RainBot(humidity, message, _logger);
            }
            else if (botName == "SunBot")
            {
                return new SunBot(temperature, message, _logger);
            }
            else if (botName == "SnowBot")
            {
                return new SnowBot(temperature, message, _logger);
            }
            else
            {
                throw new Exception("Unknown Bot");
            }
        }
    }
}
