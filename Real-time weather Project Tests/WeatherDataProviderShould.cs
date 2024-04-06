using AutoFixture;
using FluentAssertions;
using Moq;
using Real_time_weather_monitoring_and_reporting_service.classes.WeatherData;
using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using Real_time_weather_monitoring_and_reporting_service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_Project_Tests
{
    public class WeatherDataProviderShould
    {
        [Fact]
        public void GetWeatherDataWhenDataInputIsValid()
        {
            var fixture = new Fixture();
            var mock = new Mock<WeatherDataParserFactory>();
            var parserMock = new Mock<IWeatherDataParser>();
            mock.Setup(x => x.CreateParser(It.IsAny<WeatherDataParserType>())).Returns(parserMock.Object);
            IWeatherDataModel? weatherData = fixture.Create<WeatherDataModel>();
            parserMock.Setup(x => x.TryParse(It.IsAny<String>(), out weatherData)).Returns(true);
            var sut = new WeatherDataProvider(mock.Object, WeatherDataParserType.JSON);
            sut.GetWeatherData(fixture.Create<String>());
        }

        [Fact]
        public void ThrowExeptionWhenDataInputIsNotValid()
        {
            var fixture = new Fixture();
            var mock = new Mock<WeatherDataParserFactory>();
            var parserMock = new Mock<IWeatherDataParser>();
            mock.Setup(x => x.CreateParser(It.IsAny<WeatherDataParserType>())).Returns(parserMock.Object);
            IWeatherDataModel? weatherData = null;
            parserMock.Setup(x => x.TryParse(It.IsAny<String>(), out weatherData)).Returns(false);
            var sut = new WeatherDataProvider(mock.Object, WeatherDataParserType.JSON);
            Action action = () => sut.GetWeatherData(fixture.Create<String>());
            action.Should().Throw<Exception>().WithMessage("Invaild data format");
        }
    }
}
