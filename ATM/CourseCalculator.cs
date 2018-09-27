using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CourseCalculator : ICourseCalculator
    {
        // Calculates the course of vehicles in a list, compared to their previous 'old' location.
        public List<IVehicle> CalculateCourse(List<IVehicle> newVehicles, List<IVehicle> oldVehicles)
        {
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
                        int deltaX = newVehicle.Xcoordinate - oldVehicle.Xcoordinate;
                        int deltaY = newVehicle.Ycoordinate - oldVehicle.Ycoordinate;
                        int distance = (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                        // Velocity (meters pr second)
                        int velocity = (1000 * distance) / deltaTime.Milliseconds;

                        // Course (degrees)
                        int course = ((int)(Math.Atan2(deltaY, deltaX) * (180 / Math.PI)) + 360) % 360;

                        // Update vehicle
                        newVehicle.velocity = velocity;
                        newVehicle.course = course;

                        // Continue to next newVehicle in the list
                        break;
                    }

                    // If not found - make sure velocity and course are set to 0
                    newVehicle.velocity = 0;
                    newVehicle.course = 0;
                }
            }

            // Returns updated list with calculated velocity and course
            return newVehicles;

        }
    }
}
