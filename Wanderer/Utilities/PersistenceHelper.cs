using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Robot.Wanderer
{
	public static class PersistenceHelper
	{
		private static BinaryFormatter bf = new BinaryFormatter();

		public static void SaveBots(List<Guid> botIDs)
		{
			using (FileStream fs = new FileStream(Consts.FileLocation + "\\RunningBots.dat", FileMode.Create))
			{
				bf.Serialize(fs, botIDs);
			}
		}

		public static List<Guid> LoadBots()
		{
			if (!File.Exists(Consts.FileLocation))
				return null;

			List<Guid> botIDs = null;

			using (FileStream fs = new FileStream(Consts.FileLocation + "\\RunningBots.dat", FileMode.Open))
			{
				if (fs.Length > 0)
					botIDs = bf.Deserialize(fs) as List<Guid>;
			}

			return botIDs;
		}
	}
}
