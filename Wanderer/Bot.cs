using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Robot.Wanderer.Systems;

namespace Robot.Wanderer
{
	/// <summary>
	/// The main entry point for a bot
	/// </summary>
    public sealed class Bot : IDisposable
	{
        private OS os;
        private EPROM eprom;
        private DriveTrain driveTrain;
        private SensorArray sensorArray;
        private PhysicalInteraction physicalInteraction;

		public Bot()
        {
            physicalInteraction = new PhysicalInteraction(this);
        }
		
		/// <summary>
		/// Destructor to shutdown the bot and save all data
		/// </summary>
		~Bot()
		{
			// TODO: Implement
		}

        public void Dispose()
        {
            throw new Exception("The method or operation is not implemented.");
        }

		/// <summary>
		/// Used in static helper methods to bind events to created bots
		/// </summary>
		public void BindEvents()
		{
			//os.OSReloaded += new OS.OSReloadedDelegate(OSReloaded);

            sensorArray.OnBump += new EventHandler<Robot.Wanderer.Components.BumpEventArgs>(sensorArrayOnBump);
		}

        private void sensorArrayOnBump(object sender, Robot.Wanderer.Components.BumpEventArgs e)
        {
            if (e.BumpSensorLocation == Robot.Wanderer.Enums.BumpSensorLocation.Front)
                driveTrain.Move(Robot.Wanderer.Enums.MovementDirection.Backward);

            if (e.BumpSensorLocation == Robot.Wanderer.Enums.BumpSensorLocation.Back)
                driveTrain.Move(Robot.Wanderer.Enums.MovementDirection.Forward);

            if (e.BumpSensorLocation == Robot.Wanderer.Enums.BumpSensorLocation.Left)
                driveTrain.Move(Robot.Wanderer.Enums.MovementDirection.Right);

            if (e.BumpSensorLocation == Robot.Wanderer.Enums.BumpSensorLocation.Right)
                driveTrain.Move(Robot.Wanderer.Enums.MovementDirection.Left);
        }

		/// <summary>
		/// Event handler for when a new OS is received and reloaded
		/// </summary>
        //public void OSReloaded()
        //{
        //    //TODO: Implement
        //}


        /// <summary>
        /// The bots OS
        /// </summary>
        public OS OS
        {
            get { return os; }
        }
        
        /// <summary>
		/// The bots EPROM data
		/// </summary>
		public EPROM EPROM
		{
			get { return eprom; }
		}
		
        /// <summary>
        /// The bots sensor array
        /// </summary>
        public SensorArray SensorArray
        {
            get { return sensorArray; }
        }

        /// <summary>
        /// The bots movement control class
        /// </summary>
        public DriveTrain DriveTrain
        {
            get { return driveTrain; }
        }

        /// <summary>
        /// A point where you can the "physical" world interacts with the bot
        /// </summary>
        public PhysicalInteraction PhysicalInteraction
        {
            get { return physicalInteraction; }
        }




        private static Robot.Wanderer.Enums.BumpSensorLocations allBumpSensors = (Robot.Wanderer.Enums.BumpSensorLocations)15;

        /// <summary>
        /// Static helper method to create a Listener bot with a random communication type
        /// </summary>
        /// <returns>The new bot</returns>
        public static Bot CreateRandomListener()
        {
            int rand = new Random((int)(DateTime.Now.Ticks * new Random().Next(DateTime.Now.Millisecond))).Next(1, 10);
            rand = (rand > 3) ? rand /= 3 : rand;

            return CreateListener((Enums.CommunicationTypes)rand);
        }

        /// <summary>
        /// Static helper method to create a new Listener bot
        /// </summary>
        /// <param name="commType">The bots communication type</param>
        /// <returns>The new bot</returns>
        public static Bot CreateListener(Enums.CommunicationTypes commType)
        {
            Bot bot = new Bot();
            Guid botID = Guid.NewGuid();
            bot.os = new OS(botID, false);
            bot.eprom = new EPROM(botID, commType, allBumpSensors);
            bot.sensorArray = new SensorArray(commType, allBumpSensors);
            bot.driveTrain = new DriveTrain(2, 1);
            bot.BindEvents();

            return bot;
        }

        /// <summary>
        /// Static helper method to create a new Gen Zero bot
        /// </summary>
        /// <param name="commType">The bots communication type</param>
        /// <returns>The new bot</returns>
        public static Bot CreateGenZero(Enums.CommunicationTypes commType)
        {
            Bot bot = new Bot();
            Guid botID = Guid.NewGuid();
            bot.os = new OS(botID, true);
            bot.eprom = new EPROM(botID, commType, allBumpSensors);
            bot.sensorArray = new SensorArray(commType, allBumpSensors);
            bot.driveTrain = new DriveTrain(2, 1);
            bot.BindEvents();

            return bot;
        }

        /// <summary>
        /// Static helper method to create a bot based on saved data
        /// </summary>
        /// <param name="botID">The ID of the bot to load</param>
        /// <returns>The bot</returns>
        public static Bot CreateExisting(Guid botID)
        {
            Bot bot = new Bot();
            bot.os = new OS(FileHelper.LoadOS(botID));
            bot.eprom = FileHelper.LoadROM(botID);
            bot.sensorArray = new SensorArray(bot.eprom.CommunicationType, bot.eprom.BumpSensors);
            bot.driveTrain = new DriveTrain(2, 1);
            bot.BindEvents();

            return bot;
        }
    }
}
