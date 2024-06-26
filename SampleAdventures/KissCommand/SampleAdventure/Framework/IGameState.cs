﻿
// IGameState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Framework
{
	/// <inheritdoc />
	public interface IGameState : Eamon.Framework.IGameState
	{
		bool AmandaArmandKissed { get; set; }
	}
}
