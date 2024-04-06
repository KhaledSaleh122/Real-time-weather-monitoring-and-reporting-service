using AutoFixture;
using Moq;
using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.classes.Logger;

namespace Real_time_weather_Project_Tests
{
    public class SnowBotShould
    {
        [Fact]
        public void UpdateWhenTemperatureDropsBelowThreshold()
        {
            var mock = new Mock<ILogger>();
            var fixture = new Fixture();
            var temperatureTheshold = fixture.Create<double>();
            var message = fixture.Create<string>();
            var sut = new SnowBot(temperatureTheshold, message, mock.Object);
            sut.Update(temperatureTheshold - 1, fixture.Create<double>());
            mock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
