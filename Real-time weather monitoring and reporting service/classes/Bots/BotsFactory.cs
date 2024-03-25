using Real_time_weather_monitoring_and_reporting_service.Interfaces;


namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    public static class BotsFactory
    {
        public static IBotListner CreateBot(string botName, Threshold threshold, double newValue, string message)
        {
            if (botName == "RainBot")
            {
                return new RainBot(threshold, newValue, message);
            }
            else if (botName == "SunBot")
            {
                return new SunBot(threshold, newValue, message);
            }
            else if (botName == "SnowBot")
            {
                return new SnowBot(threshold, newValue, message);
            }
            else
            {
                throw new Exception("Unknown Bot");
            }
        }
    }
}
