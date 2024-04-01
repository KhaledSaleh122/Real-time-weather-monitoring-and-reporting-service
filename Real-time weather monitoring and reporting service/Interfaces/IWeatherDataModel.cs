namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public interface IWeatherDataModel
    {
        double Humidity { get; set; }
        string Location { get; set; }
        double Temperature { get; set; }
    }
}