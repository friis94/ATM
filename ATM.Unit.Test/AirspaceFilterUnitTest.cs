using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class AirspaceFilterUnitTest
    {
        private IAirspaceFilter uut;
        [SetUp]
        public void Init()
        {
            uut = new AirspaceFilter();
            uut.SetAirSpace(10000, 90000, 10000, 90000, 500, 20000);
        }

        [Test]
        public void FilterEmptyAirspaceTest()
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            // Act
            List<IVehicle> filtered = uut.FilterVehicles(vehicles);

            // Assert
            Assert.That(filtered.Count, Is.EqualTo(0));
        }

        [TestCase(10000, 15000, 1000, 1)] // Xmin inside
        [TestCase(9999, 15000, 1000, 0)] // Xmin outisde
        [TestCase(15000, 10000, 1000, 1)] // Ymin inside
        [TestCase(15000, 9999, 1000, 0)] // Ymin outisde
        [TestCase(15000, 15000, 500, 1)] // Altitude min inside
        [TestCase(15000, 15000, 499, 0)] // Altitude min outisde

        [TestCase(90000, 15000, 1000, 1)] // Xmax inside
        [TestCase(90001, 15000, 1000, 0)] // Xmax outisde
        [TestCase(15000, 90000, 1000, 1)] // Ymax inside
        [TestCase(15000, 90001, 1000, 0)] // Ymax outisde
        [TestCase(15000, 15000, 20000, 1)] // Altitude max inside
        [TestCase(15000, 15000, 20001, 0)] // Altitude max outisde
        public void AirfieldBoundaryTest(int x, int y, int altitude, int result)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            IVehicle vehicle = new Airplane();
            vehicle.Xcoordinate = x;
            vehicle.Ycoordinate = y;
            vehicle.Altitude = altitude;
            vehicles.Add(vehicle);

            // Act
            List<IVehicle> filtered = uut.FilterVehicles(vehicles);

            // Assert
            Assert.That(filtered.Count, Is.EqualTo(result));
        }
    }
}
