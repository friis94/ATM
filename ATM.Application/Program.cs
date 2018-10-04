using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Unit.Test;
using TransponderReceiver;

namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {


            ITransponderReceiver _transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            // TODO: Fix Path
            IFileWriter _writer = new FileWriter("C: DUMMY");
            IFileLogger _fileLogger = new FileLogger(_writer);

            IConsoleWriter _consoleWriter = new ConsoleWriter();
            IConsoleLogger _consoleLogger = new ConsoleLogger(_consoleWriter);

            IController controller = new ATMController(_transponderReceiver, _fileLogger, _consoleLogger);
            
            
            Console.ReadKey();
        }
    }
}
