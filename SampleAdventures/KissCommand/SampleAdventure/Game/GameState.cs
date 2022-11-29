
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
		public virtual bool AmandaArmandKissed { get; set; }
	}
}
