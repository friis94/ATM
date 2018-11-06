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
        private ITimer _enterTimer;
        private ITimer _exitTimer;
        private List<IVehicle> VehichlesEntered = new List<IVehicle>();
        private List<IVehicle> VehichlesExited = new List<IVehicle>();

        public TrackDetector(ITimer enterTimer, ITimer exitTimer)
        {
            _enterTimer = enterTimer;
            _exitTimer = exitTimer;
            _enterTimer.Expired += new EventHandler(LogEnteredVehichles);
            _exitTimer.Expired += new EventHandler(LogExitedVehichles);
        }

        public void LogTracks(List<IVehicle> NewVehicles, List<IVehicle> OldVehicles)
        {
            this._newVehicles = NewVehicles;
            this._oldVehicles = OldVehicles;

            FilterVehichles();

            if (VehichlesExited.Count > 0)
            {

                args.tracks = VehichlesExited;
                ExitEvent?.Invoke(this, args);
                _exitTimer = new Timer(5000);
                _exitTimer.Start();

            }
            if (VehichlesEntered.Count > 0)
            {
                args.tracks = VehichlesEntered;
                EnterEvent?.Invoke(this, args);
                _enterTimer = new Timer(5000);
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
            //Find vehicles entered
            for (int i = 0; i < _newVehicles.Count; i++)
            {
                if (!_oldVehicles.Contains(_newVehicles[i]))
                {
                    VehichlesEntered.Add(_newVehicles[i]);
                }
            }

            //Find vehicles exited
            for (int i = 0; i < _oldVehicles.Count; i++)
            {
                if (!_newVehicles.Contains(_oldVehicles[i]))
                {
                    VehichlesExited.Add(_oldVehicles[i]);
                }
            }
            

        }



    }
}
