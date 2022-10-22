
// WearCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class WearCommand : EamonRT.Game.Commands.WearCommand, IWearCommand
	{
		public override void Execute()
		{
			Debug.Assert(DobjArtifact != null);

			// Wear manacles = death

			if (DobjArtifact.Uid == 1)
			{
				gOut.Print("As you slide the manacles onto your wrists, they snap closed with a loud clack!  You panic as you realize you have no key to free yourself.  Unfortunately, you die of thirst only a few days later (despite the damp walls).");

				gGameState.Die = 1;

				NextState = gEngine.CreateInstance<IPlayerDeadState>(x =>
				{
					x.PrintLineSep = true;
				});
			}
			else
			{
				base.Execute();
			}
		}
	}
}
