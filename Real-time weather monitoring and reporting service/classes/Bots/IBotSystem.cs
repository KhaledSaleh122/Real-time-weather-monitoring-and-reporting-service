using Real_time_weather_monitoring_and_reporting_service.Interfaces;

namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    public interface IBotSystem
    {
        void Notify(IWeatherDataModel weatherData);
        void Subscribe(IBotListner botListner);
    }
}