﻿using System;
using System.Collections.Generic;
using ATM.Unit.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TransponderReceiver;

namespace ATM.Integration.Test
{
    [TestClass]
    public class IntegrationStep2
    {

        [TestMethod]
        public void IntegrationTestAirspaceFilter()
        {
            /*
             * ARRANGE
             */

            IAirspaceFilter airspaceFilter = new AirspaceFilter();

            // Fake transponder receiver to generate data
            FakeTransponderReceiver fakeTransponderReceiver = new FakeTransponderReceiver();

            // Stub to assert on
            ICourseCalculator courseCalculator = Substitute.For<ICourseCalculator>();
            courseCalculator.CalculateCourse(Arg.Any<List<IVehicle>>(), Arg.Any<List<IVehicle>>()).Returns(new List<IVehicle>());


            // Needed to create ATMController
            ISeparationDetector separationDetector = new SeparationDetector();
            ITrackDetector trackDetector = Substitute.For<ITrackDetector>();
            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();
            IFileLogger fileLogger = Substitute.For<IFileLogger>();
            

            IController controller = new ATMController(fakeTransponderReceiver, fileLogger, consoleLogger,
                separationDetector, trackDetector, airspaceFilter, courseCalculator);

            /*
             * ACT
             */
            fakeTransponderReceiver.transpondNotCollidingAirplanes();

            /*
             * Assert
             */
            courseCalculator.Received().CalculateCourse(Arg.Any<List<IVehicle>>(), Arg.Any<List<IVehicle>>());

        }
    }
}
