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
            ISeparation sep = new Separation(airplaneA, airplaneB, dt);
            List<ISeparation> seps = new List<ISeparation>();
            seps.Add(sep);

            uut.SetSeparations(seps);

            Assert.AreEqual(0, 0);
        }
    }
}
