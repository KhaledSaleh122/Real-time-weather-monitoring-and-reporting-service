using AutoFixture;
using Moq;
using Real_time_weather_monitoring_and_reporting_service.classes.bots;
using Real_time_weather_monitoring_and_reporting_service.classes.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_Project_Tests
{
    public class RainBotShould
    {
        [Fact]
        public void UpdateWhenHumidityExceedsThreshold()
        {
            var mock = new Mock<ILogger>();
            var fixture = new Fixture();
            var humidityTheshold = fixture.Create<double>();
            var message = fixture.Create<string>();
            var sut = new RainBot(humidityTheshold, message, mock.Object);
            sut.Update(fixture.Create<double>(), humidityTheshold + 1);
            mock.Verify(x => x.Log(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
