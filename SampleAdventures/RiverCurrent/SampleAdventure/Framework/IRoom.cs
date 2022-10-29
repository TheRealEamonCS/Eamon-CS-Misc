
// IRoom.cs

// Copyright (c) 2014+ by Michael R. Penner.  All rights reserved.

using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Framework
{
	public interface IRoom : Eamon.Framework.IRoom
	{
		/// <summary></summary>
		bool IsRiverRoom();

		/// <summary></summary>
		long GetNextRiverRoomUid();
	}
}
