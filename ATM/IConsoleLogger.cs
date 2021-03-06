﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IConsoleLogger
    {
        void SetVehicles(List<IVehicle> vehicles);
        void SetSeparations(List<ISeparation> separations);
        void SetEnterTracks(List<IVehicle> vehicles);
        void SetExitTracks(List<IVehicle> vehicles);
        void ClearConsole();
    }
}
