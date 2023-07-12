
// GameState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings(typeof(IGameState))]
	public class GameState : Eamon.Game.GameState, Framework.IGameState
	{
		public virtual long ElevatorRoomUid { get; set; }

		public virtual bool UpButtonPushed { get; set; }

		public virtual bool DownButtonPushed { get; set; }

		public GameState()
		{
			ElevatorRoomUid = 2;			// Initial elevator exit room
		}
	}
}
