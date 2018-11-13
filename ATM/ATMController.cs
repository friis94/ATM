using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class ATMController : IController
    {

        public event EventHandler SeperationEventHandler;
        private ISeparationDetector _separationDetector;
        private ITransponderReceiver _transponderReceiver;
        private IDecoder _decoder;
        private ICourseCalculator _courseCalculator;
        private IAirspaceFilter _airspaceFilter;

        private IConsoleLogger _consoleLogger;

        private IFileLogger _fileLogger;

        private ITrackDetector _trackDetector;

        private List<IVehicle> vehicles;
        private List<ISeparation> separations;



        public ATMController(ITransponderReceiver receiver, IFileLogger fileLogger, IConsoleLogger consoleLogger, ISeparationDetector separationDetector, ITrackDetector trackDetector)
        {
            // Decoder
            _decoder = new Decoder();

            // Course calculator
            _courseCalculator = new CourseCalculator();

            // Airspace Filter
            _airspaceFilter = new AirspaceFilter();
            _airspaceFilter.SetAirSpace(10000, 90000, 10000, 90000, 500, 20000);

            // Set vehicles list
            vehicles = new List<IVehicle>();

            _separationDetector = separationDetector;
            _separationDetector.SeparationEvent += Update;

            //Set track detector
            _trackDetector = trackDetector;
            _trackDetector.EnterEvent += LogEnterTracks;
            _trackDetector.ExitEvent += LogExitTracks;
            _trackDetector.EnterEventRemove += RemoveEnterTracks;
            _trackDetector.ExitEventRemove += RemoveExitTracks;

            // Console logger
            _consoleLogger = consoleLogger;

            // File logger
            _fileLogger = fileLogger;

            _transponderReceiver = receiver;
            _transponderReceiver.TransponderDataReady += NewTransponderData;




        }


        public void Update(object source, SeparationChangedEventArgs args)
        {
            _consoleLogger.SetSeparations(args.separations);
            foreach (var separation in args.separations)
            {
                _fileLogger.Log(separation);
            }
        }

        public void LogEnterTracks(object source, TrackEventArgs args)
        {
            //Log the entered vehicles
            Console.WriteLine("TestEnter");
            
        }

        public void LogExitTracks(object source, TrackEventArgs args)
        {
            //Log the exited vehicles
            Console.WriteLine("TestExit");
        }

        public void RemoveExitTracks(object source, EventArgs args)
        {
            //Remove the exited vehicles
            Console.WriteLine("TestRemoveExit");
        }

        public void RemoveEnterTracks(object source, EventArgs args)
        {
            //Remove the entered vehicles
            Console.WriteLine("TestRemoveEnter");
        }

        public void NewTransponderData(object source, RawTransponderDataEventArgs data)
        {
            // Decode received transponder data
            List<IVehicle> newVehicles = _decoder.Decode(data.TransponderData);

            // Filter the newVehicles 
            newVehicles = _airspaceFilter.FilterVehicles(newVehicles);

            _consoleLogger.ClearConsole();

            if (newVehicles.Count > 0)
            {

                // Track detections to log
                _trackDetector.LogTracks(newVehicles, vehicles);

                // Calculate course
                vehicles = _courseCalculator.CalculateCourse(newVehicles, vehicles);

                // Log to the console
                _consoleLogger.SetVehicles(vehicles);

                // Look for separations
                _separationDetector.CalculateSeparations(vehicles);

                
            }
            else
            {
                vehicles = newVehicles;
            }
        }

    }
}
