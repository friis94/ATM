﻿using System;
using System.Text;
using System.Collections.Generic;
using Castle.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using NSubstitute;

namespace ATM.Unit.Test
{
    /// <summary>
    /// Summary description for ConsoleLoggerUnitTest
    /// </summary>
    [TestFixture]
    public class ConsoleLoggerUnitTest
    {
        [Test]
        public void ConsoleLogger_SetSeparationTest()
        {

            
            IConsoleWriter writer = Substitute.For<IConsoleWriter>();
            ConsoleLogger uut = new ConsoleLogger(writer);

            // Separation event between to airplanes
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Parse("2000/12/24 18:00:10");
            ISeparation sep = new Separation(airplaneA, airplaneB, dt);

            IVehicle airplaneC = new Airplane();
            IVehicle airplaneD = new Airplane();
            airplaneC.Tag = "Airplane C";
            airplaneD.Tag = "Airplane D";
            ISeparation sep2 = new Separation(airplaneC, airplaneD, dt);

            List<ISeparation> seps = new List<ISeparation>();
            seps.Add(sep);
            seps.Add(sep2);

            uut.SetSeparations(seps);

            Received.InOrder(() =>
            {
                writer.WriteLine(
                    " ------------------------------------ Separation Event -----------------------------------");
                writer.WriteLine($"Separation between {airplaneA.Tag} and {airplaneB.Tag} @ 2000-12-24 18:00:10.000");
                writer.WriteLine($"Separation between {airplaneC.Tag} and {airplaneD.Tag} @ 2000-12-24 18:00:10.000");
                writer.WriteLine("------------------------------------------------------------------------------------------");
            });
        }

        [Test]
        public void ConsoleLogger_SetVehicleTest()
        {


            IConsoleWriter writer = Substitute.For<IConsoleWriter>();
            ConsoleLogger uut = new ConsoleLogger(writer);

            // Separation event between to airplanes
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Parse("2000/12/24 18:00:10");
            airplaneA.Timestamp = dt;
            airplaneB.Timestamp = dt;
            
            List<IVehicle> airplanes = new List<IVehicle>();

            airplanes.Add(airplaneA);
            airplanes.Add(airplaneB);

            uut.SetVehicles(airplanes);

            Received.InOrder(() =>
            {
                writer.WriteLine(" ------------------------------- Airplanes in the airspace -------------------------------");
                writer.WriteLine($"{airplaneA.Tag} , Coordinate(x, y): ({airplaneA.XCoordinate}, {airplaneA.YCoordinate}), Altitude: {airplaneA.Altitude}, Velocity: {airplaneA.Velocity}, Compass Course: {airplaneA.Course}");
                writer.WriteLine($"{airplaneB.Tag} , Coordinate(x, y): ({airplaneB.XCoordinate}, {airplaneB.YCoordinate}), Altitude: {airplaneB.Altitude}, Velocity: {airplaneB.Velocity}, Compass Course: {airplaneB.Course}");
                writer.WriteLine("------------------------------------------------------------------------------------------");
            });
        }

        [Test]
        public void ConsoleLogger_SetEnterTracks()
        {


            IConsoleWriter writer = Substitute.For<IConsoleWriter>();
            ConsoleLogger uut = new ConsoleLogger(writer);

            // Separation event between to airplanes
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Parse("2000/12/24 18:00:10");
            airplaneA.Timestamp = dt;
            airplaneB.Timestamp = dt;

            List<IVehicle> airplanes = new List<IVehicle>();

            airplanes.Add(airplaneA);
            airplanes.Add(airplaneB);

            uut.SetEnterTracks(airplanes);

            Received.InOrder(() =>
            {
                writer.WriteLine(" ------------------------------- Airplanes Entered airspace -------------------------------");
                writer.WriteLine($"{airplaneA.Tag} at time @ 2000-12-24 18:00:10.000");
                writer.WriteLine($"{airplaneB.Tag} at time @ 2000-12-24 18:00:10.000");
                writer.WriteLine("------------------------------------------------------------------------------------------");
            });
        }

        [Test]
        public void ConsoleLogger_SetExitTracks()
        {


            IConsoleWriter writer = Substitute.For<IConsoleWriter>();
            ConsoleLogger uut = new ConsoleLogger(writer);

            // Separation event between to airplanes
            IVehicle airplaneA = new Airplane();
            IVehicle airplaneB = new Airplane();
            airplaneA.Tag = "Airplane A";
            airplaneB.Tag = "Airplane B";
            DateTime dt = DateTime.Parse("2000/12/24 18:00:10");
            airplaneA.Timestamp = dt;
            airplaneB.Timestamp = dt;

            List<IVehicle> airplanes = new List<IVehicle>();

            airplanes.Add(airplaneA);
            airplanes.Add(airplaneB);

            uut.SetExitTracks(airplanes);

            Received.InOrder(() =>
            {
                writer.WriteLine(" ------------------------------- Airplanes Exited airspace -------------------------------");
                writer.WriteLine($"{airplaneA.Tag} at time @ 2000-12-24 18:00:10.000");
                writer.WriteLine($"{airplaneB.Tag} at time @ 2000-12-24 18:00:10.000");
                writer.WriteLine("------------------------------------------------------------------------------------------");
            });
        }

        [Test]
        public void ConsoleLogger_ClearConsole()
        {
            IConsoleWriter writer = Substitute.For<IConsoleWriter>();
            ConsoleLogger uut = new ConsoleLogger(writer);

            uut.ClearConsole();

            writer.Received().Clear();
        }
    }
}
