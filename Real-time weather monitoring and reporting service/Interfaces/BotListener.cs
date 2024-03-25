using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public enum Threshold {
        humidity,
        temperature
    }
    public interface IBotListner
    {
        public Threshold Threshold { get; set; }
        public double ThresholdValue { get; set; }
        public string Message { get; set; }
        public void Update(double newValue);
    }
}
