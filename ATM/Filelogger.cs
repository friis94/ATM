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
        private readonly IFileWriter _fileWriter;

        // FileLogger constructor
        public FileLogger(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        // Log a separation event
        public void Log(ISeparation separation)
        {
            // Format date and time
            var dateTimeString = separation.Timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            // Log to txt file
            _fileWriter.WriteLine($"[Separation Event] between {separation.VehicleA.Tag} and {separation.VehicleB.Tag} @ {dateTimeString}");
        }
    }
}
