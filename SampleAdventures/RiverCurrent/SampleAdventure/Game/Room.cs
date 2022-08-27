
// Room.cs

// Copyright (c) 2014+ by Michael R. Penner.  All rights reserved.

using System.Linq;
using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game
{
	[ClassMappings(typeof(IRoom))]
	public class Room : Eamon.Game.Room, Framework.IRoom
	{
		public virtual bool IsRiverRoom()
		{
			var roomUids = new long[] { 2, 3, 4 };

			return roomUids.Contains(Uid);
		}

		public virtual long GetNextRiverRoomUid()
		{
			return Uid == 2 ? 3 : Uid == 3 ? 4 : 0;
		}
	}
}
