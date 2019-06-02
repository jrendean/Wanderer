using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Components
{
	/// <summary>
	/// Descriptor for an IR communication device
	/// </summary>
    public sealed class IRTransmitter : TransmitterBase
    {
        private const int range = 5;

        public IRTransmitter()
            : base(CommunicationTypes.IR)
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
