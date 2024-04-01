namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public interface IBotDataSource
    {
        List<IBotListner> GetBots();
        void LoadBots();
    }
}
