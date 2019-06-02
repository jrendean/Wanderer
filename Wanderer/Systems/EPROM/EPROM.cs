using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Enums;

namespace Robot.Wanderer.Systems
{
	/// <summary>
	/// The location of the bots memory
	/// </summary>
	[Serializable()]
	public sealed class EPROM
	{
        private Guid id;
        private CommunicationTypes communicationType;
        private BumpSensorLocations bumpSensors;
        private History history;

		/// <summary>
		/// Constructor
		/// </summary>
        /// <param name="id">The bots ID</param>
        /// <param name="communicationType">The bots communication type</param>
        /// <param name="bumpSensorLocations"></param>
        public EPROM(Guid id, CommunicationTypes communicationType, BumpSensorLocations bumpSensors)
		{
            this.communicationType = communicationType;
            this.bumpSensors = bumpSensors;
            this.id = id;
			FileHelper.SaveROM(id, this);
            history = new History();
		}


        /// <summary>
        /// The bots ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        
        /// <summary>
		/// The communication type of the bot
		/// </summary>
		public CommunicationTypes CommunicationType
		{
            get { return communicationType; }
		}

        /// <summary>
        /// 
        /// </summary>
        public BumpSensorLocations BumpSensors
        {
            get { return bumpSensors; }
        }

		/// <summary>
		/// The bots history list
		/// </summary>
		public History History
		{
			get { return history; }
		}
	}
}
