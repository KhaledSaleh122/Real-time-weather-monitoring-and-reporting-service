using FluentAssertions;
using Real_time_weather_monitoring_and_reporting_service.classes.WeatherData;
using Real_time_weather_monitoring_and_reporting_service.Enum;

namespace Real_time_weather_Project_Tests
{
    public class StanderWeatherDataParserFactoryShould
    {
        [Theory]
        [InlineData(WeatherDataParserType.XML)]
        [InlineData(WeatherDataParserType.JSON)]
        public void CreateParserExpectedParser(WeatherDataParserType dataParserType)
        {
            var sut = new StanderWeatherDataParserFactory();
            var pareser = sut.CreateParser(dataParserType);
            if (dataParserType == WeatherDataParserType.JSON)
            {
                pareser.Should().BeOfType<JsonWeatherDataParser>();
            }
            else if (dataParserType == WeatherDataParserType.XML)
            {
                pareser.Should().BeOfType<XmlWeatherDataParser>();
            }
        }

        [Fact]
        public void ThrowExeptionWhenExpectedParserNotExist()
        {
            var sut = new StanderWeatherDataParserFactory();
            Action action = () => sut.CreateParser(WeatherDataParserType.None);
            action.Should().Throw<Exception>("Unknow Parser Type");
        }
    }
}
