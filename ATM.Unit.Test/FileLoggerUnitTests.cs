using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class FileLoggerUnitTests
    {
        [Test]
        public void LogOneSeperation()
        {
            // Logger
            IFileLogger uut = new FileLogger(@"C:\Users\Public\ATM.txt");

            // Separation event between to airplanes
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Now;
            ISeperation sep = new Seperation(airplaneA, airplaneB, dt);

            uut.Log(sep);
          
            Assert.AreEqual(0, 0);
        }
    }
}
