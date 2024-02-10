
// Globals.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;

namespace SampleAdventure.Game.Plugin
{
#pragma warning disable IDE1006 // Naming Styles

	/// <inheritdoc cref="EamonRT.Game.Plugin.Globals"/>
	public static class Globals
	{
		/// <inheritdoc cref="EamonRT.Game.Plugin.Globals.gGameState"/>
		public static IGameState gGameState
		{
			get
			{
				return EamonRT.Game.Plugin.Globals.gGameState;
			}
		}
	}

#pragma warning restore IDE1006 // Naming Styles
}
