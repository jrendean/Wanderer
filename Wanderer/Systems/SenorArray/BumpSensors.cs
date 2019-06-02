using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Components;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Systems
{
    public sealed class BumpSensors
    {
        public event EventHandler<BumpEventArgs> OnBump;
        private List<BumpSensor> bumpSensors;
        
        public BumpSensors(BumpSensorLocations bumpSensorLocations)
        {
            bumpSensors = new List<BumpSensor>();

            if ((bumpSensorLocations & BumpSensorLocations.Back) != 0)
                bumpSensors.Add(new BumpSensor(BumpSensorLocation.Back));

            if ((bumpSensorLocations & BumpSensorLocations.Front) != 0)
                bumpSensors.Add(new BumpSensor(BumpSensorLocation.Front));

            if ((bumpSensorLocations & BumpSensorLocations.Left) != 0)
                bumpSensors.Add(new BumpSensor(BumpSensorLocation.Left));

            if ((bumpSensorLocations & BumpSensorLocations.Right) != 0)
                bumpSensors.Add(new BumpSensor(BumpSensorLocation.Right));

            // this is in case the bumpsensors themselves get code to invoke the bump
            foreach (BumpSensor bumpSensor in bumpSensors)
            {
                bumpSensor.OnBump += Bump;
            }
        }

        private void Bump(object sender, BumpEventArgs e)
        {
            if (OnBump != null)
                OnBump(this, e);
        }

        // internal for physicalinteraction to use
        internal void Bump(BumpSensorLocation bumpSensorLocation)
        {
            Bump(this, new BumpEventArgs(bumpSensorLocation));
        }
    }
}
