
// IRoom.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Framework
{
	public interface IRoom : Eamon.Framework.IRoom
	{
		long Traversals { get; set; }

		bool IsDustyFloorRoom();
	}
}
