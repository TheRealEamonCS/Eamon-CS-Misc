
// UseCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class UseCommand : EamonRT.Game.Commands.UseCommand, IUseCommand
	{
		public override void ExecuteForPlayer()
		{
			Debug.Assert(DobjArtifact != null);

			// Red button

			if (DobjArtifact.Uid == 3)
			{
				var antiGravSledArtifact = gADB[1];

				Debug.Assert(antiGravSledArtifact != null);

				if (gGameState.AntiGravSledActivated)
				{
					gOut.Print("You press the red button; the faint hum ceases, and {0} slowly settles back on the ground.", antiGravSledArtifact.GetTheName());

					antiGravSledArtifact.StateDesc = "";
				}
				else
				{
					gOut.Print("You press the red button, and a faint hum is heard from {0} as it comes to life.  Slowly, it rises from the ground to a height of about six inches, propelled by some mysterious force.", antiGravSledArtifact.GetTheName());

					antiGravSledArtifact.StateDesc = " floating above the ground";
				}

				gGameState.AntiGravSledActivated = !gGameState.AntiGravSledActivated;

				NextState = gEngine.CreateInstance<IMonsterStartState>();
			}
			else
			{
				base.ExecuteForPlayer();
			}
		}
	}
}
