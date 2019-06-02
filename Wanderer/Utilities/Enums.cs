using System;

namespace Robot.Wanderer.Enums
{
	/// <summary>
	/// Communication type of the bot (stored in EPROM)
	/// </summary>
	[Flags()]
	public enum CommunicationTypes : short
	{
		None = 0,
		IR = 1,
		RF = 2
	}

	/// <summary>
	/// The type of bump sensors the bot has (stored in EPROM)
	/// </summary>
    [Flags()]
    public enum BumpSensorLocations : short
	{
        None = 0,
		Front = 1,
        Back = 2,
        Right = 4,
		Left = 8
	}

    /// <summary>
    /// The individual bump sensor setting
    /// </summary>
    public enum BumpSensorLocation : short
    {
        Front,
        Back,
        Right,
        Left
    }

	/// <summary>
	/// Movement types the bot can make (used in EPROM.History.MovementLog)
	/// </summary>
	[Flags()]
	public enum MovementDirection : short
	{
        None = 0,
	    Forward = 1,
	    Left = 2,
	    Right = 4,
	    Backward = 8
	}





	public enum TransmissionTypes : short
	{
		Acknowledge,
		Status,
		Ping,
		TransmitOS
	}

	public enum ReceptionTypes : short
	{
		Acknowledge,
		Status,
		RecieveOS
	}



}
