﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ATM
{

    public class TrackEventArgs : EventArgs
    {
        public List<IVehicle> Tracks { get; set; }
    }

    public interface ITrackDetector
    {
        event EventHandler<TrackEventArgs> EnterEvent;
        event EventHandler<TrackEventArgs> ExitEvent;
        event EventHandler<TrackEventArgs> ExitEventRemove;
        event EventHandler<TrackEventArgs> EnterEventRemove;

        void Update(List<IVehicle> newVehicles, List<IVehicle> oldVehicles);

    }
}
