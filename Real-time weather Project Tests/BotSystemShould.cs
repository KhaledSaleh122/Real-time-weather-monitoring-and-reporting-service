using FluentAssertions;
using Moq;
using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;

namespace Real_time_weather_Project_Tests
{
    public class BotSystemShould
    {
        public BotSystemShould()
        {

        }

        [Fact]
        public void SubscribeBot()
        {
            var sut = new BotSystem();
            var mock = new Mock<IBotListner>();
            sut.Subscribe(mock.Object);
            sut.GetBotListners().Should().Contain(mock.Object);
        }

        [Fact]
        public void NotifySubscribedBots()
        {
            var sut = new BotSystem();
            var mock = new Mock<IBotListner>();
            sut.Subscribe(mock.Object);
            var WeatherDataMock = new Mock<IWeatherDataModel>();
            sut.Notify(WeatherDataMock.Object);
            mock.Verify((x) => x.Update(It.IsAny<double>(), It.IsAny<double>()), Times.Once);
        }
    }
}
