using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Components
{
	/// <summary>
	/// Base class for communication devices 
	/// </summary>
	public abstract class TransmitterBase
	{
        private CommunicationTypes communicationType;
		internal event EventHandler OnReceive;

        protected TransmitterBase(CommunicationTypes communicationType)
        {
            this.communicationType = communicationType;
        }

        protected abstract void Transmit();

        public abstract int Range
        {
            get;
        }

        public CommunicationTypes CommunicationType
        {
            get { return communicationType; }
        }
	}
}
