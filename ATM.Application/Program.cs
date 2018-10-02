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

            IController controller = new ATMController(_transponderReceiver);
            
            
            Console.ReadKey();
        }
    }
}
