using FluentAssertions;
using Real_time_weather_monitoring_and_reporting_service.classes.WeatherData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_Project_Tests
{
    public class XmlWeatherDataParserShould
    {
        [Fact]
        public void OutWeatherDataWhenXmlTextIsVaild()
        {
            var sut = new XmlWeatherDataParser();
            var json =
                """
                 <WeatherData>
                  <Location>City Name</Location>
                  <Temperature>23.0</Temperature>
                  <Humidity>85.0</Humidity>
                </WeatherData>
                """;
            sut.TryParse(json, out var weatherData);
            weatherData.Should().NotBeNull();
        }

        [Fact]
        public void OutNullWhenXmlTextIsNotVaild()
        {
            var sut = new XmlWeatherDataParser();
            var json =
                """
                
                  <Location>City Name</Location>
                  <Temperature>23.0</Temperature>
                  <Humidity>85.0</Humidity>
                </WeatherData>
                """;
            sut.TryParse(json, out var weatherData);
            weatherData.Should().BeNull();
        }

    }
}
