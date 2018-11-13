﻿using System;
using System.Collections.Generic;
using ATM.Unit.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TransponderReceiver;

namespace ATM.Integration.Test
{
    [TestClass]
    public class IntegrationStep3
    {

        [TestMethod]
        public void IntegrationTestCourseCalculator()
        {
            /*
             * ARRANGE
             */

            IDecoder decoder = new Decoder();
            IAirspaceFilter airspaceFilter = new AirspaceFilter();
            ICourseCalculator courseCalculator = new CourseCalculator();

            // Fake transponder receiver to generate data
            FakeTransponderReceiver fakeTransponderReceiver = new FakeTransponderReceiver();

            // Stub to assert on
            ITrackDetector trackDetector = Substitute.For<ITrackDetector>();
          
            // Needed to create ATMController
            ISeparationDetector separationDetector = new SeparationDetector();
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
            trackDetector.Received().LogTracks(Arg.Any<List<IVehicle>>(), Arg.Any<List<IVehicle>>());

        }
    }
}
