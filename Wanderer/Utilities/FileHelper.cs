using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Robot.Wanderer.Systems;

namespace Robot.Wanderer
{
	/// <summary>
	/// Internal class used to help save and load EPROM and OS data and well as write out the starting OSes for GenZero and Listener
	/// </summary>
	internal static class FileHelper
	{
		private static BinaryFormatter binaryFormatter = new BinaryFormatter();
		
		/// <summary>
		/// Loads a bot EPROM from disk
		/// </summary>
		/// <param name="botID">The Guid of the bot</param>
		/// <returns>The EPROM object</returns>
		internal static EPROM LoadROM(Guid botID)
		{
			if (!File.Exists(Consts.FileLocation + botID.ToString() + Consts.EPROMExtenstion))
				return null;

			EPROM rom = null;

			using (FileStream fs = new FileStream(Consts.FileLocation + botID.ToString() + Consts.EPROMExtenstion, FileMode.Open))
			{
				if (fs.Length > 0)
                    rom = binaryFormatter.Deserialize(fs) as EPROM;
			}

			return rom;
		}

		/// <summary>
		/// Saves a bots EPROM to disk
		/// </summary>
		/// <param name="botID">The Guid of the bot</param>
		/// <param name="botROM">The bots EPROM object to save</param>
		/// <returns>Success or Failure</returns>
		internal static bool SaveROM(Guid botID, EPROM botROM)
		{
			try
			{
				using (FileStream fs = new FileStream(Consts.FileLocation + botID.ToString() + Consts.EPROMExtenstion, FileMode.Create))
				{
                    binaryFormatter.Serialize(fs, botROM);
				}

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		
		/// <summary>
		/// Loads a bots of from disk
		/// </summary>
		/// <param name="botID">The Guid of the bot</param>
		/// <returns>XmlDocument of the OS</returns>
		internal static XmlDocument LoadOS(Guid botID)
		{
			XmlDocument os = null;

			if (File.Exists(Consts.FileLocation + botID.ToString() + Consts.OSExtenstion))
			{
				os = new XmlDocument();
				os.Load(Consts.FileLocation + botID.ToString() + Consts.OSExtenstion);
			}

			return os;
		}

		/// <summary>
		/// Saves a bots OS to disk
		/// </summary>
		/// <param name="botID">The Guid of the bot</param>
		/// <param name="botOS">The bots OS as an xml string</param>
		/// <returns>Success or Failure</returns>
		internal static bool SaveOS(Guid botID, string botOS)
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.LoadXml(botOS);
				xmlDoc.Save(Consts.FileLocation + botID.ToString() + Consts.OSExtenstion);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Takes the Gen Zero OS from the assembyl and writes it out to a new OS file for a newly created bot
		/// </summary>
		/// <param name="botID">The Guid for the new bot</param>
		internal static void CreateGenZeroOS(Guid botID)
		{
			using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Robot.Wanderer.Systems.OS.GenZeroOS.xml"))
			{
				using (FileStream fs = new FileStream(Consts.FileLocation + botID.ToString() + Consts.OSExtenstion, FileMode.Create))
				{
					byte[] data = new byte[s.Length];
					s.Read(data, 0, (int)s.Length);
					fs.Write(data, 0, (int)s.Length);
				}
			}
		}

		/// <summary>
		/// Takes the Listener OS from the assembly and writes it out to a new OS file for a newly created bot
		/// </summary>
		/// <param name="botID">The Guid for the new bot</param>
		internal static void CreateListenOS(Guid botID)
		{
			using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Robot.Wanderer.Systems.OS.ListenOS.xml"))
			{
				using (FileStream fs = new FileStream(Consts.FileLocation + botID.ToString() + Consts.OSExtenstion, FileMode.Create))
				{
					byte[] data = new byte[s.Length];
					s.Read(data, 0, (int)s.Length);
					fs.Write(data, 0, (int)s.Length);
				}
			}
		}
	}
}
