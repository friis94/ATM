using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ATM
{
    public class TrackDetector : ITrackDetector
    {

        public event EventHandler<TrackEventArgs> EnterEvent;
        public event EventHandler<TrackEventArgs> EnterEventRemove;
        public event EventHandler<TrackEventArgs> ExitEvent;
        public event EventHandler<TrackEventArgs> ExitEventRemove;
        private TrackEventArgs args = new TrackEventArgs();
        private List<IVehicle> _newVehicles;
        private List<IVehicle> _oldVehicles;

        private List<IVehicle> VehichlesEntered = new List<IVehicle>();
        private List<IVehicle> VehichlesExited = new List<IVehicle>();


        public void Update(List<IVehicle> NewVehicles, List<IVehicle> OldVehicles)
        {
            this._newVehicles = NewVehicles;
            this._oldVehicles = OldVehicles;

            FilterVehicles();

            if (VehichlesExited.Count > 0)
            {
                ITimer _exitTimer = new Timer(5000, VehichlesExited);
                _exitTimer.Expired += new EventHandler<TrackEventArgs>(LogExitedVehicles);
                args.tracks = VehichlesExited;
                ExitEvent?.Invoke(this, args);
                _exitTimer.Start();

            }

            if (VehichlesEntered.Count > 0)
            {
                ITimer _enterTimer = new Timer(5000, VehichlesEntered);
                _enterTimer.Expired += new EventHandler<TrackEventArgs>(LogEnteredVehicles);
                args.tracks = VehichlesEntered;
                EnterEvent?.Invoke(this, args);
                _enterTimer.Start();
            }

        }

        public void LogEnteredVehicles(object source, TrackEventArgs timerArgs)
        {

            EnterEventRemove?.Invoke(this, timerArgs);
            
            
        }

        public void LogExitedVehicles(object source, TrackEventArgs timerArgs)
        {
            ExitEventRemove?.Invoke(this, timerArgs);
        }



        public void FilterVehicles()
        {
            VehichlesEntered = new List<IVehicle>();
            VehichlesExited = new List<IVehicle>();

            List<String> _newVehiclesTags = new List<string>();
            List<String> _oldVehiclesTags = new List<string>();

            foreach (var vehicle in _newVehicles)
            {
                _newVehiclesTags.Add(vehicle.Tag);
            }
            foreach (var vehicle in _oldVehicles)
            {
                _oldVehiclesTags.Add(vehicle.Tag);
            }

            //Find vehicles entered
            for (int i = 0; i < _newVehicles.Count; i++)
            {
                
                if (!_oldVehiclesTags.Contains(_newVehiclesTags[i]))
                {
                    VehichlesEntered.Add(_newVehicles[i]);
                }
            }

            //Find vehicles exited
            for (int i = 0; i < _oldVehicles.Count; i++)
            {
                if (!_newVehiclesTags.Contains(_oldVehiclesTags[i]))
                {
                    VehichlesExited.Add(_oldVehicles[i]);
                }
            }          
        }
    }
}
