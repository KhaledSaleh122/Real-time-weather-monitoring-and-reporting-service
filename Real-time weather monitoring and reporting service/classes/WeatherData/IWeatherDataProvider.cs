using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    public interface IWeatherDataProvider
    {
        IWeatherDataModel GetWeatherData(string data);
    }
}