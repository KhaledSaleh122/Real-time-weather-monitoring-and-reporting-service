using Real_time_weather_monitoring_and_reporting_service.classes.Bots;
using Real_time_weather_monitoring_and_reporting_service.Enum;
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
            if (_bots.Count == 0)
            {
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
                    double temperature = default;
                    if (botConfig.TryGetProperty("temperatureThreshold", out var temperatureThresholdElement))
                    {
                        temperature = temperatureThresholdElement.GetDouble();
                    }
                    double humidity = default;
                    if (botConfig.TryGetProperty("humidityThreshold", out var humidityThresholdElement))
                    {
                        humidity = humidityThresholdElement.GetDouble();
                    }
                    string message = botConfig.GetProperty("message").GetString()!;
                    BotFactory botFactory = new StanderBotsFactory();
                    _bots.Add(botFactory.CreateBot(botName, temperature, humidity, message));
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
