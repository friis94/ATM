using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeparationDetector : ISeparationDetector
    {
        public event EventHandler SeperationEvent;
        public void Update(List<IVehicle> vehicles)
        {
            throw new NotImplementedException();
        }

        public List<ISeparation> CalculateSeperations(List<IVehicle> vehicles)
        {
            List < ISeparation > seperations = new List<ISeparation>();
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
                        seperations.Add(separation);
                    }
                    
                }
            }

            return seperations;


        }

    }
}
