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
        private readonly BotFactory _botFactory;
        private readonly IBotSystem _botSystem;
        public BotsDataFile(string filepath, BotFactory botFactory, IBotSystem botSystem)
        {
            _fileBath = filepath;
            _botFactory = botFactory;
            _botSystem = botSystem;
        }
        public List<IBotListner> GetBots()
        {
            if (_bots.Count == 0)
            {
                LoadBots();
            }
            return [.. _bots];
        }

        public void LoadBots()
        {
            if (_bots.Count != 0) throw new Exception("File Already Loaded");
            LoadBotsInFile();
            foreach (var bot in _bots)
            {
                _botSystem.Subscribe(bot);
            }
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
                    _bots.Add(_botFactory.CreateBot(botName, temperature, humidity, message));
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
