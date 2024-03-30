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
        private readonly List<IBotListner> _bots = [];
        private readonly String _fileBath;
        public BotsDataFile(string filepath)
        {
            _fileBath = filepath;
        }
        public List<IBotListner> GetBots()
        {
            if (_bots.Count == 0) {
                LoadBotsInFile();
            }
            return [.. _bots];
        }

        private void LoadBotsInFile()
        {
            string configFile = File.ReadAllText(_fileBath);
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
            ReadBotsInFileJsonFormat(configs);
        }
        private void ReadBotsInFileJsonFormat(JsonDocument configs)
        {
            JsonElement root = configs.RootElement;
            foreach (JsonProperty property in root.EnumerateObject())
            {
                string botName = property.Name;
                JsonElement botConfig = property.Value;

                try
                {
                    bool enabled = botConfig.GetProperty("enabled").GetBoolean();
                    if (!enabled) continue;
                    (double? newValue, Threshold? threshold) = UpdatedThreshold(botConfig);
                    string message = botConfig.GetProperty("message").GetString()!;
                    _bots.Add(BotsFactory.CreateBot(botName, (Threshold)threshold!, (double)newValue!, message));
                }
                catch
                {
                    continue;
                }
            }
        }

        private static (double?, Threshold) UpdatedThreshold(JsonElement botConfig)
        {
            if (botConfig.TryGetProperty("temperatureThreshold", out var temperatureThresholdElement))
            {
                return (temperatureThresholdElement.GetDouble(), Threshold.temperature);
            }
            if (botConfig.TryGetProperty("humidityThreshold", out var humidityThresholdElement))
            {
                return (humidityThresholdElement.GetDouble(), Threshold.humidity);
            }
            throw new Exception("Invaild bot threshold data");
        }
    }
}
