using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Components
{
	/// <summary>
	/// Descriptor for an RF communication device
	/// </summary>
    public sealed class RFTransmitter : TransmitterBase
	{
        private const int range = 20;

        public RFTransmitter()
            : base(CommunicationTypes.RF)
        {
        }

        protected override void Transmit()
		{
		}

        public override int Range
        {
            get
            {
                return range;
            }
        }
	}
}
