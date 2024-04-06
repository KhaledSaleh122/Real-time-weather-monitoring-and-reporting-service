using FluentAssertions;
using Real_time_weather_monitoring_and_reporting_service.classes.WeatherData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_Project_Tests
{
    public class JsonWeatherDataParserShould
    {
        [Fact]
        public void OutWeatherDataWhenJsonTextIsVaild()
        {
            var sut = new JsonWeatherDataParser();
            var json =
                """
                    {
                      "Location": "City Name",
                      "Temperature": 23.0,
                      "Humidity": 85.0
                    }
                """;
            sut.TryParse(json, out var weatherData);
            weatherData.Should().NotBeNull();
        }

        [Fact]
        public void OutNullWhenJsonTextIsNotVaild()
        {
            var sut = new JsonWeatherDataParser();
            var json =
                """
                    
                      "Location": "City Name",
                      "Temperature": 23.0,
                      "Humidity": 85.0
                    }
                """;
            sut.TryParse(json, out var weatherData);
            weatherData.Should().BeNull();
        }

    }
}
