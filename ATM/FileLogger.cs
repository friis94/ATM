using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class FileLogger : IFileLogger
    {
        // Which file to log to
        private readonly string _filePath;

        // FileLogger constructor
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        // Log a separation event
        public void Log(ISeparation separation)
        {
            // Format date and time
            var dateTimeString = separation.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            // Log to txt file
            System.IO.File.AppendAllText(_filePath, $"[Separation Event] between {separation.VehicleA.Tag} and {separation.VehicleB.Tag} @ {dateTimeString}" + Environment.NewLine);  
        }
    }
}
