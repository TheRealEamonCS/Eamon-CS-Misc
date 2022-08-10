
// Room.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Linq;
using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game
{
	[ClassMappings(typeof(IRoom))]
	public class Room : Eamon.Game.Room, Framework.IRoom
	{
		public virtual long Traversals { get; set; }

		public virtual bool IsDustyFloorRoom()
		{
			var floorRooms = new long[] { 2, 3 };        // Dusty floor is found in these rooms

			return floorRooms.Contains(Uid);
		}
	}
}
