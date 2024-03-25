using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.classes.WeatherData;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;

namespace Real_time_weather_monitoring_and_reporting_service.UI
{
    public static class WeatherUI
    {
        public static void CollectWeatherData(BotSystem botSystem) {
            IWeatherDataParser? parser = null;
            String? input;
            do {
                ConsoleMessage.DisplayHeaderMessage("Weather Data");
                ConsoleMessage.DisplayWeatherDataFormatOptions();
                input = Console.ReadLine();
                switch (input)
                {
                    case "~": return;
                    case "1" :
                        Console.WriteLine("Your JSON : ");
                        input = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(input)) {
                            ConsoleMessage.InvaildInput();
                            return;
                        }
                        parser = new WeatherDataJSON();
                        break;
                    case "2" :
                        Console.WriteLine("Your XML : ");
                        input = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(input))
                        {
                            ConsoleMessage.InvaildInput();
                            return;
                        }
                        parser = new WeatherDataXML();
                        break;
                    default:
                        ConsoleMessage.InvaildInput();
                        break;

                }
            } while (parser is null);
            var weatherDataFactory = new WeatherDataProvider(parser);
            WeatherDataModel weatherData;
            try
            {
                weatherData = weatherDataFactory.GetWeatherData(input!);
                botSystem.Notify(weatherData.Temperature, weatherData.Humidity);
            }
            catch { 
                ConsoleMessage.InvaildInput();
                return;
            }
        }
    }
}
