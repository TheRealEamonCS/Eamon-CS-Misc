
// Room.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	// This game implements an 3-Level elevator that can be extended to any number of Levels.  There are a few
	// requirements:  (1) Each button on the control panel inside the elevator must have the exit Room Uid stored
	// as its Field1.  (2) The elevator exit Room Uids must be ordered ascending from lowest Level to highest Level.
	// So, Level 1 Room Uid must be less than Level 2 Room Uid, which must be less than Level 3 Room Uid, etc.
	// While there is no requirement that the exit Rooms be consecutive it is probably a good idea.

	[ClassMappings]
	public class Room : Eamon.Game.Room, IRoom
	{
		public override long GetDir(long index)
		{
			if (gEngine.EnableMutateProperties)
			{
				if (Uid == 4)
				{
					return index == 2 ? gGameState.ElevatorRoomUid : base.GetDir(index);
				}
				else
				{
					return base.GetDir(index);
				}
			}
			else
			{
				return base.GetDir(index);
			}
		}
	}
}
