using AutoFixture;
using FluentAssertions;
using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Real_time_weather_Project_Tests
{
    public class StanderBotsFactoryShould
    {
        private readonly Fixture _fixture;

        public StanderBotsFactoryShould()
        {
            _fixture = new Fixture();
        }
        [Theory]
        [InlineData("RainBot")]
        [InlineData("SunBot")]
        [InlineData("SnowBot")]
        public void CreateBotIfThereExistBotForBotname(String botname)
        {
            var temperature = _fixture.Create<double>();
            var humidity = _fixture.Create<double>();
            var message = _fixture.Create<string>();
            var sut = new StanderBotsFactory();
            var bot = sut.CreateBot(botname, temperature, humidity, message);

        }
        [Fact]
        public void CreateBotThrowsExeptionIfBotnameUnknown()
        {
            var temperature = _fixture.Create<double>();
            var humidity = _fixture.Create<double>();
            var message = _fixture.Create<string>();
            var sut = new StanderBotsFactory();
            Action action = () => sut.CreateBot("", temperature, humidity, message);
            action.Should().Throw<Exception>().WithMessage("Unknown Bot");
        }
    }
}
