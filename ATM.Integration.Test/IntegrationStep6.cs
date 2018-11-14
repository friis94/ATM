using System;
using System.Collections.Generic;
using ATM.Unit.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TransponderReceiver;

namespace ATM.Integration.Test
{
    [TestClass]
    public class IntegrationStep6
    {

        [TestMethod]
        public void IntegrationTestNonColidingAirPlanesLoggedToConsole()
        {
            /*
             * ARRANGE
             */

            IDecoder decoder = new Decoder();
            IAirspaceFilter airspaceFilter = new AirspaceFilter();
            ICourseCalculator courseCalculator = new CourseCalculator();
            ITrackDetector trackDetector = new TrackDetector();
            ISeparationDetector separationDetector = new SeparationDetector();
            IConsoleLogger consoleLogger = new ConsoleLogger(Substitute.For<IConsoleWriter>());

            // Fake transponder receiver to generate data
            FakeTransponderReceiver fakeTransponderReceiver = new FakeTransponderReceiver();

            // Stub to assert on
            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            // ATMController
            IController controller = new ATMController(fakeTransponderReceiver, fileLogger, consoleLogger,
                separationDetector, trackDetector, airspaceFilter, courseCalculator);

            /*
             * ACT
             */
            fakeTransponderReceiver.transpondCollidingAirplanes();

            /*
             * Assert
             */
            fileLogger.Received().Log(Arg.Any<ISeparation>());

        }
    }
}
