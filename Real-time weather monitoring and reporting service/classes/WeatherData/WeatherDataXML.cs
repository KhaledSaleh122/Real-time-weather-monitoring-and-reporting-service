using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;
using System.Data.SqlTypes;
using System.Text.Json;
using System.Xml.Linq;

namespace Real_time_weather_monitoring_and_reporting_service.classes.WeatherData
{
    internal class WeatherDataXML : IWeatherDataParser
    {
        public bool TryParse(string text, out WeatherDataModel? weatherData)
        {
            weatherData = null;
            try
            {
                XDocument xdoc = XDocument.Parse(text);
                var xmlWeathersData = xdoc.Element("WeatherData");
                if (!ValidateXMLData(xdoc)) return false;
                weatherData = new WeatherDataModel()
                {
                    Location = xmlWeathersData!.Element("Location")!.Value,
                    Humidity = double.Parse(xmlWeathersData!.Element("Temperature")!.Value),
                    Temperature = double.Parse(xmlWeathersData!.Element("Humidity")!.Value)
                };
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidateXMLData(XDocument xdoc)
        {
            var xLoaction = xdoc.Element("WeatherData")?.Element("Location")?.Value;
            var xTemperature = xdoc.Element("WeatherData")?.Element("Temperature")?.Value;
            var xHumidity = xdoc.Element("WeatherData")?.Element("Humidity")?.Value;
            return !string.IsNullOrWhiteSpace(xLoaction) &&
                   !string.IsNullOrWhiteSpace(xTemperature) &&
                   !string.IsNullOrWhiteSpace(xHumidity);
        }
    }
}
