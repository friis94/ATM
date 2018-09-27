using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }
    }
}
