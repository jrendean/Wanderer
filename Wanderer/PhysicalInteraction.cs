using System;
using System.Collections.Generic;
using System.Drawing;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer
{
    public class PhysicalInteraction
    {
        private Bot bot;
        private Point location;

        public PhysicalInteraction(Bot bot)
        {
            this.bot = bot;
        }

        public void TriggerBump(BumpSensorLocation bumpSensorLocation)
        {
            bot.SensorArray.BumpSensors.Bump(bumpSensorLocation);
        }

        public void CommunicationInRange(CommunicationTypes communicationType)
        {
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
