
// IGameState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Framework
{
	public interface IGameState : Eamon.Framework.IGameState
	{
		bool AntiGravSledActivated { get; set; }
	}
}
