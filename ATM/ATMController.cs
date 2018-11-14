using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    public class AtmController : IController
    {

        public event EventHandler SeparationEventHandler;
        private ISeparationDetector _separationDetector;
        private ITransponderReceiver _transponderReceiver;
        private IDecoder _decoder;
        private ICourseCalculator _courseCalculator;
        private IAirspaceFilter _airspaceFilter;

        private IConsoleLogger _consoleLogger;

        private IFileLogger _fileLogger;

        private ITrackDetector _trackDetector;

        private List<IVehicle> _vehicles;

        private List<IVehicle> vehiclesEnter = new List<IVehicle>();
        private List<IVehicle> vehiclesExit = new List<IVehicle>();

        public AtmController(ITransponderReceiver receiver, IFileLogger fileLogger, IConsoleLogger consoleLogger, ISeparationDetector separationDetector, ITrackDetector trackDetector, IAirspaceFilter airspaceFilter, ICourseCalculator courseCalculator)
        {
            if (receiver == null || fileLogger == null || consoleLogger == null || separationDetector == null || trackDetector == null || airspaceFilter == null || courseCalculator == null)
            {
                throw new ArgumentNullException("atm controller depepdency injection.");
            }
            // Decoder
            _decoder = new Decoder();

            // Course calculator
            _courseCalculator = courseCalculator;

            // Airspace Filter
            _airspaceFilter = airspaceFilter;
            _airspaceFilter.SetAirspace(10000, 90000, 10000, 90000, 500, 20000);

            // Set _vehicles list
            _vehicles = new List<IVehicle>();

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

            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            _consoleLogger.SetSeparations(args.Separations);
            foreach (var separation in args.Separations)
            {
                _fileLogger.Log(separation);
            }
        }

        public void LogEnterTracks(object source, TrackEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            //Log the entered _vehicles
            vehiclesEnter.AddRange(args.Tracks);
      
        }

        public void RemoveEnterTracks(object source, TrackEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            //Remove the entered _vehicles
            foreach (var vehicle in args.Tracks)
            {
                vehiclesEnter.Remove(vehicle);
            }
        }

        public void LogExitTracks(object source, TrackEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            //Log the exited _vehicles
            vehiclesExit.AddRange(args.Tracks);
        }

        public void RemoveExitTracks(object source, TrackEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            //Remove the exited _vehicles
            foreach (var vehicle in args.Tracks)
            {
                vehiclesExit.Remove(vehicle);
            }
        }

        public void NewTransponderData(object source, RawTransponderDataEventArgs data)
        {

            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            // Decode received transponder data
            List<IVehicle> newVehicles = _decoder.Decode(data.TransponderData);

            // Filter the newVehicles 
            newVehicles = _airspaceFilter.FilterVehicles(newVehicles);

            // Track detections to log
            _trackDetector.Update(newVehicles, _vehicles);

            _consoleLogger.ClearConsole();

            if (newVehicles.Count > 0)
            {
                // Calculate Course
                _vehicles = _courseCalculator.CalculateCourse(newVehicles, _vehicles);

                // Log to the console
                _consoleLogger.SetVehicles(_vehicles);

                // Look for Separations
                _separationDetector.CalculateSeparations(_vehicles);

                
            }
            else
            {
                _vehicles = newVehicles;
            }

            if (vehiclesEnter.Count > 0)
            {
                _consoleLogger.SetEnterTracks(vehiclesEnter);
            }

            if (vehiclesExit.Count > 0)
            {
                _consoleLogger.SetExitTracks(vehiclesExit);
            }
        }

    }
}
