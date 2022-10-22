
// MainLoop.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class MainLoop : EamonRT.Game.MainLoop, IMainLoop
	{
		public override void Startup()
		{
			base.Startup();

			// Schedule shaft of light appears event

			var fireRound = gGameState.CurrTurn + gEngine.RollDice(1, 5, 5);

			gGameState.BeforePrintPlayerRoomEventHeap.Insert02(fireRound, "ShaftOfLightAppears", gEngine.GetRandomElement(new string[] { "yellow", "red", "orange", "blue", "green" }));
		}
	}
}
