using Real_time_weather_monitoring_and_reporting_service.classes.Logger;
using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;


namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    internal class SunBot : IBotListner
    {
        private readonly ILogger _logger;
        public string Message { get; set; }
        public double HumidityThreshold { get; set; }
        public double TemperatureThreshold { get; set; }
        public SunBot(double temperatureThreshold, string message, ILogger logger)
        {
            TemperatureThreshold = temperatureThreshold;
            Message = message;
            _logger = logger;
        }


        public void Update(double temperature, double humidity)
        {
            if (temperature >= TemperatureThreshold)
            {
                _logger.Log("SunBot activated!");
                _logger.Log($"SunBot: {Message}");
            }
        }
    }
}
