using Real_time_weather_monitoring_and_reporting_service.Interfaces;


namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    internal class RainBot : IBotListner
    {
        public Threshold Threshold { get; set; }

        public double ThresholdValue { get; set; }
        public string Message { get; set; }

        public RainBot(Threshold threshold, double thresholdValue, string message)
        {
            Threshold = threshold;
            ThresholdValue = thresholdValue;
            Message = message;
        }



        public void Update(double newValue)
        {
            if (newValue >= ThresholdValue)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine($"RainBot: {Message}");
            }
        }
    }
}
