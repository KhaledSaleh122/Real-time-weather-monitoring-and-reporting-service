using Real_time_weather_monitoring_and_reporting_service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public interface IBotListner
    {
        public double HumidityThreshold { get; set; }
        public double TemperatureThreshold { get; set; }
        public string Message { get; set; }
        public void Update(double temperature, double humidity);
    }
}
