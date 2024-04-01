using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.classes.WeatherData;
using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.UI
{
    public class WeatherUI : IWeatherUI
    {
        private IMessageViewer _messageViewer;
        private IBotSystem _botSystem;
        public WeatherUI(IMessageViewer messageViewer, IBotSystem botSystem)
        {
            _messageViewer = messageViewer;
            _botSystem = botSystem;
        }
        public void CollectWeatherData()
        {
            WeatherDataParserType parserType = default;
            String? input;
            do
            {
                _messageViewer.DisplayHeaderMessage("Weather Data");
                _messageViewer.DisplayOptions();
                input = Console.ReadLine();
                switch (input)
                {
                    case "~": return;
                    case "1":
                        Console.WriteLine("Your JSON : ");
                        input = Console.ReadLine();
                        if (_messageViewer.IsNullInput(input)) return;
                        parserType = WeatherDataParserType.JSON;
                        break;
                    case "2":
                        Console.WriteLine("Your XML : ");
                        input = Console.ReadLine();
                        if (_messageViewer.IsNullInput(input)) return;
                        parserType = WeatherDataParserType.XML;
                        break;
                    default:
                        _messageViewer.InvaildInput();
                        break;

                }
            } while (parserType == default);
            IWeatherDataProvider weatherDataProvider = new WeatherDataProvider(new StanderWeatherDataParserFactory(), parserType);
            IWeatherDataModel weatherData;
            try
            {
                weatherData = weatherDataProvider.GetWeatherData(input!);
                _botSystem.Notify(weatherData);
            }
            catch
            {
                _messageViewer.InvaildInput();
                return;
            }
        }
    }
}
