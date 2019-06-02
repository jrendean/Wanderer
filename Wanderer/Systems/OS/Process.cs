using System;
using System.Xml;


namespace Robot.Wanderer.Systems
{
	/// <summary>
	/// The OS process running on the bot
	/// </summary>
	public sealed class Process
	{
		private XmlDocument os;
		private bool running = false;
		private bool fault = false;
		
		public void Start(XmlDocument os)
		{
            running = true;
            this.os = os;
		}

		public void Stop()
		{
            running = false;
		}

		private void Interpert()
		{

			//if listener tell bot.communication to listen()

			// if bot determine movement paths

		}




		public bool Running
		{
            get { return running; }
		}

		public bool Fault
		{
			get { return fault; }
		}
	}
}
