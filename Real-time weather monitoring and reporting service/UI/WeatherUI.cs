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
        public WeatherUI(IMessageViewer messageViewer)
        {
            _messageViewer = messageViewer;
        }
        public void CollectWeatherData(IBotSystem botSystem)
        {
            WeatherDataParser parserType = default;
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
                        parserType = WeatherDataParser.JSON;
                        break;
                    case "2":
                        Console.WriteLine("Your XML : ");
                        input = Console.ReadLine();
                        if (_messageViewer.IsNullInput(input)) return;
                        parserType = WeatherDataParser.XML;
                        break;
                    default:
                        _messageViewer.InvaildInput();
                        break;

                }
            } while (parserType == default);
            WeatherDataParserFactory parserFactory = new StanderWeatherDataParserFactory();
            IWeatherDataParser weatherDataParser = parserFactory.CreateParser(parserType);
            IWeatherDataProvider weatherDataProvider = new WeatherDataProvider(weatherDataParser);
            IWeatherDataModel weatherData;
            try
            {
                weatherData = weatherDataProvider.GetWeatherData(input!);
                botSystem.Notify(weatherData);
            }
            catch
            {
                _messageViewer.InvaildInput();
                return;
            }
        }
    }
}
