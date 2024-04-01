using Real_time_weather_monitoring_and_reporting_service.Enum;
using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.classes.Bots
{
    public abstract class BotFactory
    {
        public abstract IBotListner CreateBot(String botName, double temperature, double humidity, string message);
        public IBotListner GetBot(String botName, double temperature, double humidity, string message)
        {
            var bot = CreateBot(botName, temperature, humidity, message);
            return bot;
        }
    }
}
