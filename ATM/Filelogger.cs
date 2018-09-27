using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class FileLogger : IFileLogger
    {
        private string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(ISeperation seperation)
        {
            
            System.IO.File.AppendAllText(_filePath, "[Seperation Event] between XXXX and YYYY @ 2018-12-24 21:34:56.789" + Environment.NewLine);
            

        }
    }
}
