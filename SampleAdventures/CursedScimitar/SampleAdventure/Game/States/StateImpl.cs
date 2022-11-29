
// StateImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class StateImpl : EamonRT.Game.States.StateImpl, IStateImpl
	{
		// This trick has never been demonstrated before in any game.  You can process all events
		// system-wide in a single spot.  So if you have a bunch of Command classes in your game
		// only created to process events, you can discard them and do all event processing right
		// here.  In this example, we've avoided making game-specific PutCommand and ReadyCommand
		// classes.

		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			var scimitarArtifact = gADB[2];

			Debug.Assert(scimitarArtifact != null);

			var amuletArtifact = gADB[3];

			Debug.Assert(amuletArtifact != null);

			// If scimitar is readied weapon and amulet not worn

			if (eventType == EventType.BeforePutArtifact && State is IPutCommand pc && pc.DobjArtifact.Uid == 2 && pc.ActorMonster.Weapon == 2 && !amuletArtifact.IsWornByCharacter())
			{
				gOut.Print("The malevolent {0} stubbornly sticks to your hand!", scimitarArtifact.GetNoneName());

				GotoCleanup = true;
			}
			else if (eventType == EventType.BeforeReadyArtifact && State is IReadyCommand rc && rc.DobjArtifact.Uid != 2 && rc.ActorMonster.Weapon == 2 && !amuletArtifact.IsWornByCharacter())
			{
				gOut.Print("The malevolent {0} stubbornly sticks to your hand!", scimitarArtifact.GetNoneName());

				GotoCleanup = true;
			}
		}
	}
}
