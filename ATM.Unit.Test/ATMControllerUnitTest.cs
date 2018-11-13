using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture]
    class ATMControllerUnitTest
    {

        [Test]
        public void ATMControllerTest_TranspondTwoCollidingsAirplanes_FileLogAirplanes()
        {
            FakeTransponderReceiver transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();

            ISeparationDetector separationDetector  = new SeparationDetector();

            ITrackDetector trackDetector = new TrackDetector(new Timer(5000), new Timer(5000));
             
            IAirspaceFilter airspaceFilter = new AirspaceFilter();

            ICourseCalculator courseCalculator = new CourseCalculator();
            
            ATMController _uut = new ATMController(transponderReceiver, fileLogger, consoleLogger, separationDetector, trackDetector, airspaceFilter, courseCalculator);
            transponderReceiver.transpondCollidingAirplanes();

            fileLogger.Received().Log(Arg.Any<ISeparation>());
        }

        [Test]
        public void ATMControllerTest_TranspondTwoNonCollidingsAirplanes_AirplanesNotFileLogged()
        {
            FakeTransponderReceiver transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();

            ISeparationDetector separationDetector = new SeparationDetector();

            ITrackDetector trackDetector = new TrackDetector(new Timer(5000), new Timer(5000));

            IAirspaceFilter airspaceFilter = new AirspaceFilter();

            ICourseCalculator courseCalculator = new CourseCalculator();

            ATMController _uut = new ATMController(transponderReceiver, fileLogger, consoleLogger, separationDetector, trackDetector, airspaceFilter, courseCalculator);
            transponderReceiver.transpondNotCollidingAirplanes();

            fileLogger.DidNotReceive().Log(Arg.Any<ISeparation>());
        }

        [Test]
        public void ATMControllerTest_TranspondTwoNonCollidingsAirplanes_AirplanesConsoleLogged()
        {
            FakeTransponderReceiver transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();

            ISeparationDetector separationDetector = new SeparationDetector();

            ITrackDetector trackDetector = new TrackDetector(new Timer(5000), new Timer(5000));

            IAirspaceFilter airspaceFilter = new AirspaceFilter();

            ICourseCalculator courseCalculator = new CourseCalculator();

            ATMController _uut = new ATMController(transponderReceiver, fileLogger, consoleLogger, separationDetector, trackDetector, airspaceFilter, courseCalculator);
            transponderReceiver.transpondNotCollidingAirplanes();

            consoleLogger.Received().SetVehicles(Arg.Any<List<IVehicle>>());
        }

        [Test]
        public void ATMControllerTest_TranspondNoAirplanes_AirplanesNotConsoleLogged()
        {
            FakeTransponderReceiver transponderReceiver = new FakeTransponderReceiver();

            IFileLogger fileLogger = Substitute.For<IFileLogger>();

            IConsoleLogger consoleLogger = Substitute.For<IConsoleLogger>();

            ISeparationDetector separationDetector = new SeparationDetector();

            ITrackDetector trackDetector = new TrackDetector(new Timer(5000), new Timer(5000));

            IAirspaceFilter airspaceFilter = new AirspaceFilter();

            ICourseCalculator courseCalculator = new CourseCalculator();

            ATMController _uut = new ATMController(transponderReceiver, fileLogger, consoleLogger, separationDetector, trackDetector, airspaceFilter, courseCalculator);
            transponderReceiver.transpondNoAirplanes();

            consoleLogger.DidNotReceive().SetVehicles(Arg.Any<List<IVehicle>>());
        }

    }
}
