﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Unit.Test;
using TransponderReceiver;

namespace ATM.Application
{
    class Program
    {
        static void Main(string[] args)
        {


            ITransponderReceiver transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();

            // TODO: Fix Path
            IFileWriter writer = new FileWriter("C: DUMMY");
            IFileLogger fileLogger = new FileLogger(writer);

            IConsoleWriter consoleWriter = new ConsoleWriter();
            IConsoleLogger consoleLogger = new ConsoleLogger(consoleWriter);

            ISeparationDetector separationDetector = new SeparationDetector();

            ITrackDetector trackDetector = new TrackDetector();

            IAirspaceFilter airspaceFilter = new AirspaceFilter();

            ICourseCalculator courseCalculator = new CourseCalculator();

            IController controller = new AtmController(transponderReceiver, fileLogger, consoleLogger, separationDetector, trackDetector, airspaceFilter, courseCalculator);
            
            
            Console.ReadKey();
        }
    }
}
