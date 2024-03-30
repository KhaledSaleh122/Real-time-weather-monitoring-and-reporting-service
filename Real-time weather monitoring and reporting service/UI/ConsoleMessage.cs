using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.UI
{
    public static class ConsoleMessage
    {
        public static void DisplayHeaderMessage(String text) {
            Console.Clear();
            int messageLength = text.Length + 8;
            var decorationLine = new String('*', messageLength);
            Console.WriteLine(decorationLine);
            Console.WriteLine("*   " + text + "   *");
            Console.WriteLine(decorationLine);
        }

        public static void DisplayWeatherDataFormatOptions() {
            Console.WriteLine("Select input data format: [Enter ~ to Cancel]");
            Console.WriteLine("Option 1 : JSON Fromat");
            Console.WriteLine("Option 2 : XML Fromat");
        }
        public static void CloseMessage() {
            Console.WriteLine("Press enter to continuo...");
            Console.ReadLine();
        }
        public static void InvaildInput() {
            Console.WriteLine("Invaild input");
            CloseMessage();
        }

        public static Boolean NullInput(String input) {
            if (String.IsNullOrWhiteSpace(input))
            {
                ConsoleMessage.InvaildInput();
                return true;
            }
            return false;
        }
    }
}
