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
        public event EventHandler EnterEventRemove;
        public event EventHandler<TrackEventArgs> ExitEvent;
        public event EventHandler ExitEventRemove;
        private TrackEventArgs args = new TrackEventArgs();
        private List<IVehicle> _newVehicles;
        private List<IVehicle> _oldVehicles;

        private List<IVehicle> VehichlesEntered = new List<IVehicle>();
        private List<IVehicle> VehichlesExited = new List<IVehicle>();


        public void LogTracks(List<IVehicle> NewVehicles, List<IVehicle> OldVehicles)
        {
            this._newVehicles = NewVehicles;
            this._oldVehicles = OldVehicles;

            FilterVehichles();

            if (VehichlesExited.Count > 0)
            {


                ITimer _exitTimer = new Timer(5000);
                _exitTimer.Expired += new EventHandler(LogExitedVehichles);
                args.tracks = VehichlesExited;
                ExitEvent?.Invoke(this, args);
                //_exitTimer = new Timer(5000);
                _exitTimer.Start();

            }
            if (VehichlesEntered.Count > 0)
            {
                ITimer _enterTimer = new Timer(5000);
                _enterTimer.Expired += new EventHandler(LogEnteredVehichles);
                args.tracks = VehichlesEntered;
                EnterEvent?.Invoke(this, args);
                //_enterTimer = new Timer(5000);
                _enterTimer.Start();
            }

        }

        public void LogEnteredVehichles(object source, EventArgs timerArgs)
        {
            EnterEventRemove?.Invoke(this, EventArgs.Empty);
            
            
        }

        public void LogExitedVehichles(object source, EventArgs timerArgs)
        {
            ExitEventRemove?.Invoke(this, EventArgs.Empty);
            
        }



        public void FilterVehichles()
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
