using System;
using System.Collections.Generic;
using System.Text;
using Robot.Wanderer.Enums;


namespace Robot.Wanderer.Systems
{
	/// <summary>
	/// The history store for the bot, kept in EPROM
	/// </summary>
	[Serializable()]
	public sealed class History
	{
		private List<MovementLog> m_Movements;
		private List<TransmissionLog> m_Transmissions;
		private List<ReceptionLog> m_Receptions;


		/// <summary>
		/// Movement log entry
		/// </summary>
		public struct MovementLog
		{
			public DateTime TimeStamp;
			public MovementDirection Direction;
			public TimeSpan Duration;


		}

		/// <summary>
		/// Transmission log entry
		/// </summary>
		public struct TransmissionLog
		{
			public DateTime TimeStamp;
			public TransmissionTypes TransmissionType;
			public bool Success;

			
		}

		/// <summary>
		/// Reception log entry
		/// </summary>
		public struct ReceptionLog
		{
			public DateTime TimeStamp;
			public ReceptionTypes ReceptionType;
			public bool Success;

			
		}
		

		public void ClearHistory()
		{
            m_Movements.Clear();
            m_Receptions.Clear();
            m_Transmissions.Clear();
		}


		/// <summary>
		/// List of all the movements
		/// </summary>
		public List<MovementLog> Movements
		{
			get { return m_Movements; }
		}

		/// <summary>
		/// List of all the transmissions
		/// </summary>
		public List<TransmissionLog> Transmissions
		{
			get { return m_Transmissions; }
		}

		/// <summary>
		/// List of all the receptions
		/// </summary>
		public List<ReceptionLog> Receptions
		{
			get { return m_Receptions; }
		}


		/// <summary>
		/// Count of all the movement entries
		/// </summary>
		public int MovementCount
		{
			get { return m_Movements == null ? 0 : m_Movements.Count; }
		}

		/// <summary>
		/// Count of all the transmissions
		/// </summary>
		public int TransmissionCount
		{
			get { return m_Transmissions == null ? 0 : m_Transmissions.Count; }
		}

		/// <summary>
		/// Count of all the receptions
		/// </summary>
		public int ReceptionCount
		{
			get { return m_Receptions == null ? 0 : m_Receptions.Count; }
		}
	}
}
