using System;
using System.Xml;


namespace Robot.Wanderer.Systems
{
	/// <summary>
	/// Main class for the bots OS
	/// </summary>
	public sealed class OS
	{
		private XmlDocument os;
		private Guid botID;
		private Process process;

		/// <summary>
		/// The delegate for the OSReload event
		/// </summary>
		//public delegate void OSReloadedDelegate();
		/// <summary>
		/// Used to tell the bot that a new OS has been received and reloaded
		/// </summary>
		//public event OSReloadedDelegate OSReloaded;

		/// <summary>
		/// Constructor for loading an existing OS
		/// </summary>
		/// <param name="botOS">The OS of the bot</param>
		public OS(XmlDocument botOS)
		{
            os = botOS;

			process = new Process();
            process.Start(os);
		}

		/// <summary>
		/// Constructor for creating a new OS on a bot
		/// </summary>
		/// <param name="botID">The bots ID</param>
		/// <param name="genZeroOS">Whether the new OS will be Gen Zero of Listener</param>
		public OS(Guid botID, bool genZeroOS)
		{
            this.botID = botID;

			if (genZeroOS)
				FileHelper.CreateGenZeroOS(botID);
			else
				FileHelper.CreateListenOS(botID);

            os = FileHelper.LoadOS(botID);

			process = new Process();
            process.Start(os);
		}

		/// <summary>
		/// Used to get the bots OS for transmission to another bot
		/// </summary>
		/// <returns>The bots OS as a string</returns>
		public string GetOSForTransmit()
		{
            return os.InnerXml;
		}

		/// <summary>
		/// Used when another bot is transmitting its OS to this bot
		/// </summary>
		/// <param name="os">The transmitting bots OS</param>
		public void ReceiveOS(string botOS)
		{
			process.Stop();

            if (FileHelper.SaveOS(botID, botOS))
                os = FileHelper.LoadOS(botID);

            process.Start(os);
			
			//if (OSReloaded != null)
			//	OSReloaded.Invoke();
		}




		/// <summary>
		/// The type of OS running (Listener or Bot)
		/// </summary>
		public string Type
		{
            get { return os.DocumentElement.Attributes["generation"].Value == "-" ? "Listener" : "Bot"; }
		}

		/// <summary>
		/// The generation of the running OS
		/// </summary>
		public string Generation
		{
            get { return os.DocumentElement.Attributes["generation"].Value; }
		}


		/// <summary>
		/// The OS process(or)
		/// </summary>
		public Process Process
		{
			get { return process; }
		}
	}
}
