using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalculator : ICourseCalculator
    {
        // Calculates the Course of vehicles in a list, compared to their previous 'old' location.
        public List<IVehicle> CalculateCourse(List<IVehicle> newVehicles, List<IVehicle> oldVehicles)
        {
            if (newVehicles == null)
            {
                throw new ArgumentNullException("newVehicles");
            }

            if (oldVehicles == null)
            {
                throw new ArgumentNullException("oldVehicles");
            }

            // Loop through all vehicles and look for them in the list of oldVehicle positions
            foreach (var newVehicle in newVehicles)
            {
                foreach (var oldVehicle in oldVehicles)
                {
                    // Check for matching tags
                    if (newVehicle.Tag == oldVehicle.Tag)
                    {
                        // Time between old and new data
                        TimeSpan deltaTime = newVehicle.Timestamp - oldVehicle.Timestamp;

                        // Distance traveled
                        int deltaX = newVehicle.XCoordinate - oldVehicle.XCoordinate;
                        int deltaY = newVehicle.YCoordinate - oldVehicle.YCoordinate;
                        int distance = (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                        // Velocity (meters pr second)
                        int velocity = (int)((1000 * distance) / deltaTime.TotalMilliseconds);

                        // Course (degrees)
                        int course = ((int)(Math.Atan2(deltaY, deltaX) * (180 / Math.PI)) + 360) % 360;

                        // Update vehicle
                        newVehicle.Velocity = velocity;
                        newVehicle.Course = course;

                        // Continue to next newVehicle in the list
                        break;
                    }

                    // If not found - make sure Velocity and Course are set to 0
                    newVehicle.Velocity = 0;
                    newVehicle.Course = 0;
                }
            }

            // Returns updated list with calculated Velocity and Course
            return newVehicles;

        }
    }
}
