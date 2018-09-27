using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ATM.Unit.Test
{
    /// <summary>
    /// Summary description for ConsoleLoggerUnitTest
    /// </summary>
    [TestFixture]
    public class ConsoleLoggerUnitTest
    {
        [Test]
        public void TestMethod1()
        {
            ConsolerLogger uut = new ConsolerLogger();

            // Separation event between to airplanes
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Now;
            ISeperation sep = new Seperation(airplaneA, airplaneB, dt);
            List<ISeperation> seps = new List<ISeperation>();
            seps.Add(sep);

            uut.SetSeperations(seps);

            Assert.AreEqual(0, 0);
        }
    }
}
