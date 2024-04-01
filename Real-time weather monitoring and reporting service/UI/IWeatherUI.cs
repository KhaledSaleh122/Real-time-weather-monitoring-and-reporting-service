using Real_time_weather_monitoring_and_reporting_service.classes.bots;

namespace Real_time_weather_monitoring_and_reporting_service.UI
{
    public interface IWeatherUI
    {
        void CollectWeatherData(IBotSystem botSystem);
    }
}