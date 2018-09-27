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
            this.Separations = new List<ISeparation>();
        }

        public void CalculateSeparations(List<IVehicle> vehicles)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                int counter;


                for (counter = i + 1; counter < vehicles.Count - i; counter++)
                {

                    Double xDistance = Math.Sqrt(Math.Sqrt(vehicles[i].Xcoordinate) - vehicles[counter].Xcoordinate);
                    Double yDistance = Math.Sqrt(Math.Sqrt(vehicles[i].Ycoordinate) - vehicles[counter].Ycoordinate);

                    Double distanceBetweenVehicles = Math.Sqrt(xDistance + yDistance);


                    if ((vehicles[i].Altitude - vehicles[counter].Altitude < 300) && distanceBetweenVehicles < 5000)
                    {
                        ISeparation separation = new Separation(vehicles[i], vehicles[counter],DateTime.Now);
                        Separations.Add(separation);
                    }
                    
                }
            }

            args.separations = Separations;
            HandleEvent(args);

        }

        protected virtual void HandleEvent(SeparationChangedEventArgs e)
        {
            SeparationEvent?.Invoke(this, e);
        }

    }
}
