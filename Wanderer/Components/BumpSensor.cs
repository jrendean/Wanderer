using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Enums;


namespace Robot.Wanderer.Components
{
    /// <summary>
    /// Descriptor of a bump sensor
    /// </summary>
    internal sealed class BumpSensor
    {
        internal event EventHandler<BumpEventArgs> OnBump;

        private BumpSensorLocation bumpSensorLocation;

        internal BumpSensor(BumpSensorLocation bumpSensorLocation)
        {
            this.bumpSensorLocation = bumpSensorLocation;
        }

        private void Bump()
        {
            if (OnBump != null)
                OnBump(this, new BumpEventArgs(this.bumpSensorLocation));
        }
    }
    

    
    public sealed class BumpEventArgs : EventArgs
    {
        private BumpSensorLocation bumpSensorLocation;

        public BumpEventArgs(BumpSensorLocation bumpSensorLocation)
        {
            this.bumpSensorLocation = bumpSensorLocation;
        }

        public BumpSensorLocation BumpSensorLocation
        {
            get { return bumpSensorLocation; }
        }
    }
}
