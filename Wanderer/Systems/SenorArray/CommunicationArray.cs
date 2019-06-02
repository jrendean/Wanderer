using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Components;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Systems
{
    public sealed class CommunicationArray
    {
        private CommunicationTypes communicationTypes;
        private List<TransmitterBase> transmitters;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="communicationType">The bots available communication type</param>
        public CommunicationArray(CommunicationTypes communicationTypes)
		{
            this.communicationTypes = communicationTypes;

            transmitters = new List<TransmitterBase>();

            if ((communicationTypes & CommunicationTypes.IR) != 0)
                transmitters.Add(new IRTransmitter());

            if ((communicationTypes & CommunicationTypes.RF) != 0)
                transmitters.Add(new RFTransmitter());
		}


		/// <summary>
		/// Tells the bot to listen
		/// </summary>
		public void Listen()
		{
            if (communicationTypes == CommunicationTypes.None)
				throw new Exception("Cannot start to listen on a bot that does not have any communication devices");
		}

		private void OnReceive(ReceptionTypes receiveType)
		{
		}

		public void Transmit(TransmissionTypes transmissionType)
		{
		}


        public List<TransmitterBase> Transmitters
        {
            get { return transmitters; }
        }
    }
}
