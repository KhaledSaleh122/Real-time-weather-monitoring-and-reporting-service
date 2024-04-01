using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Interfaces
{
    public interface IMessageViewer
    {
        void DisplayHeaderMessage(String text);
        void DisplayOptions();
        void CloseMessage();

        void InvaildInput();

        Boolean IsNullInput(String? input);


    }
}
