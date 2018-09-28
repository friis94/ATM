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

        private IConsoleWriter _consoleWriter;
        private IConsoleLogger _consoleLogger;

    
        
        public ISeparationDetector separationDetector { get; set; }
        public List<IVehicle> vehicles { get; set; }
        public List<ISeparation> separations { get; set; }



        public ATMController()
        {
            // Decoder
            _decoder = new Decoder();

            // Course calculator
            _courseCalculator = new CourseCalculator();
            

            this._separationDetector = new SeparationDetector();
            _separationDetector.SeparationEvent += Update;

            // Console logger
            _consoleWriter = new ConsoleWriter();
            _consoleLogger = new ConsoleLogger(_consoleWriter);

            _transponderReceiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            _transponderReceiver.TransponderDataReady += NewTransponderData;

        }




        public void Update(object source, SeparationChangedEventArgs args)
        {
            
        }

        public void NewTransponderData(object source, RawTransponderDataEventArgs data)
        {
            // Decode received transponder data
            List<IVehicle> newVehicles = _decoder.Decode(data.TransponderData);

            Console.WriteLine("New data...");

            if (newVehicles.Count > 0)
            {
                // Calculate course
                vehicles = _courseCalculator.CalculateCourse(newVehicles, vehicles);

                // TODO: THIS MUST BE DONE IN CONSOLE LOGGER NANNA somehow..
                System.Console.Clear();

                // Log to the console
                _consoleLogger.SetVehicles(vehicles);
            }
            else
            {
                vehicles = newVehicles;
            }
            
            
            
            
        }

    }
}
