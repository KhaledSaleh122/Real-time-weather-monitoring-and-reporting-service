using Real_time_weather_monitoring_and_reporting_service.classes.Logger;
using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;


namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    public class RainBot : IBotListner
    {
        private readonly ILogger _logger;
        public string Message { get; set; }
        public double HumidityThreshold { get; set; }
        public double TemperatureThreshold { get; set; }

        public RainBot(double humidityThreshold, string message, ILogger logger)
        {
            HumidityThreshold = humidityThreshold;
            Message = message;
            _logger = logger;
        }

        public void Update(double temperature, double humidity)
        {
            if (humidity >= HumidityThreshold)
            {
                _logger.Log("RainBot activated!");
                _logger.Log($"RainBot: {Message}");
            }
        }
    }
}
