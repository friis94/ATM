using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {

            IController controller = new ATMController();
 
            IConsoleWriter writer = new ConsoleWriter();
            ConsoleLogger uut = new ConsoleLogger(writer);

            // Separation event between to airplanes
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Now;
            ISeparation sep = new Separation(airplaneA, airplaneB, dt);
            List<ISeparation> seps = new List<ISeparation>();
            seps.Add(sep);

            uut.SetSeparations(seps);

            ATM.Decoder decoder= new ATM.Decoder();

            List<string> de = new List<string>();

            de.Add("ATR423;39045;12932;14000;20151006213456789");
            de.Add("ATT423;39045;12932;14000;20151006213456789");

            List<IVehicle> ve = decoder.Decode(de);

            uut.SetVehicles(ve);

            Console.ReadKey();
        }
    }
}
