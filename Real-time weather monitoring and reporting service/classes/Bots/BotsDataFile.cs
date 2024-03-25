using Real_time_weather_monitoring_and_reporting_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.classes.bots
{
    public class BotsDataFile : IBotDataSource
    {
        private readonly List<IBotListner> Bots = [];
        public BotsDataFile(string filepath)
        {
            string configFile = File.ReadAllText(filepath);
            JsonDocument configs;
            try
            {
                configs = JsonDocument.Parse(configFile);
            }
            catch
            {
                Console.WriteLine("Loading config file failed!!");
                return;
            }
            JsonElement root = configs.RootElement;

            foreach (JsonProperty property in root.EnumerateObject())
            {
                string botName = property.Name;
                JsonElement botConfig = property.Value;

                try
                {
                    bool enabled = botConfig.GetProperty("enabled").GetBoolean();
                    if (!enabled) continue;
                    double? newValue = null;
                    Threshold? threshold = null;
                    if (botConfig.TryGetProperty("temperatureThreshold", out var temperatureThresholdElement))
                    {
                        newValue = temperatureThresholdElement.GetDouble();
                        threshold = Threshold.temperature;
                    }
                    if (botConfig.TryGetProperty("humidityThreshold", out var humidityThresholdElement))
                    {
                        newValue = humidityThresholdElement.GetDouble();
                        threshold = Threshold.humidity;
                    }
                    string message = botConfig.GetProperty("message").GetString()!;
                    if (newValue is null) continue;
                    Bots.Add(BotsFactory.CreateBot(botName, (Threshold)threshold!, (double)newValue, message));
                }
                catch
                {
                    continue;
                }
            }
        }

        public List<IBotListner> GetBots()
        {
            return [.. Bots];
        }
    }
}
