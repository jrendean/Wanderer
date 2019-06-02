using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Components;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Systems
{
    public sealed class SensorArray
    {
        private BumpSensors bumpSensors;
        public event EventHandler<BumpEventArgs> OnBump;

        private CommunicationArray communicationArray;

        public SensorArray(CommunicationTypes communicationTypes, BumpSensorLocations bumpSensorLocations)
        {
            communicationArray = new CommunicationArray(communicationTypes);

            bumpSensors = new BumpSensors(bumpSensorLocations);
            bumpSensors.OnBump += new EventHandler<BumpEventArgs>(Bump);
        }

        private void Bump(object sender, BumpEventArgs e)
        {
            if (OnBump != null)
                OnBump(this, e);
        }


        public BumpSensors BumpSensors
        {
            get { return bumpSensors; }
        }

        public CommunicationArray CommunicationArray
        {
            get { return communicationArray; }
        }
    }
}
