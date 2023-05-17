
// BlastCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class BlastCommand : EamonRT.Game.Commands.BlastCommand, IBlastCommand
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			// Tangle of overgrowth

			if (eventType == EventType.BeforeAttackArtifact && DobjArtifact.Uid == 1)
			{
				if (DobjArtifact.DoorGate.GetKeyUid() != -2)
				{
					gOut.Print("Your Blast spell isn't the right tool for the job.");

					NextState = gEngine.CreateInstance<IStartState>();
				}
				else
				{
					gOut.Print("You've already cleared a path through {0}.", DobjArtifact.GetTheName());
				}

				GotoCleanup = true;
			}
		}
	}
}
