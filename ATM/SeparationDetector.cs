using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeparationDetector : ISeparationDetector
    {
        public event EventHandler<SeparationChangedEventArgs> SeparationEvent;
        private SeparationChangedEventArgs args;
        public List<ISeparation> Separations;


        public SeparationDetector()
        {
            args = new SeparationChangedEventArgs();
            this.Separations = new List<ISeparation>();
        }

        public void CalculateSeparations(List<IVehicle> vehicles)
        {
            if (vehicles == null)
            {
                throw new ArgumentNullException("vehicles");
            }

            Separations = new List<ISeparation>();

            if (vehicles.Count < 2)
            {
                return;
            }

            //Adding the correct seperations
            for (int i = 0; i < vehicles.Count; i++)
            {
                IVehicle vehicleA = vehicles[i];
                int counter;
                
                for (counter = i + 1; counter < vehicles.Count; counter++)
                {

                    IVehicle vehicleB = vehicles[counter];
                    double xDistance = (double)vehicleA.XCoordinate - (double)vehicleB.XCoordinate;
                    double yDistance = (double)vehicleA.YCoordinate - (double)vehicleB.YCoordinate;


                    double distanceBetweenVehicles = Math.Sqrt(xDistance*xDistance + yDistance*yDistance);


                    if ((Math.Abs(vehicleA.Altitude - vehicleB.Altitude) < 300) && distanceBetweenVehicles < 5000)
                    {
                        ISeparation separation = new Separation(vehicleA, vehicleB, DateTime.Now);
                        Separations.Add(separation);

                    }
                    
                }
            }
            
            
            if (Separations.Count > 0)
            {
                args.Separations = Separations;
                HandleEvent(args);
            }

        }

        protected virtual void HandleEvent(SeparationChangedEventArgs e)
        {
            SeparationEvent?.Invoke(this, e);
        }

    }
}
