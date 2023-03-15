
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
		// here.  In this example, we've avoided making game-specific GiveCommand, PutCommand, and
		// ReadyCommand classes.

		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			var scimitarArtifact = gADB[2];

			Debug.Assert(scimitarArtifact != null);

			// If scimitar is readied weapon and amulet not worn

			if ((eventType == EventType.AfterRefuseDeadBodyCheck && State is IGiveCommand gc && gc.DobjArtifact.Uid == 2 && gEngine.ShouldScimitarStickToHand(gc.ActorMonster)) || 
					(eventType == EventType.BeforePutArtifact && State is IPutCommand pc && pc.DobjArtifact.Uid == 2 && gEngine.ShouldScimitarStickToHand(pc.ActorMonster)) ||
					(eventType == EventType.BeforeReadyArtifact && State is IReadyCommand rc && rc.DobjArtifact.Uid != 2 && gEngine.ShouldScimitarStickToHand(rc.ActorMonster)))
			{
				gEngine.PrintScimitarSticksToHand(gCharRoom, gCharMonster, scimitarArtifact);

				GotoCleanup = true;
			}
		}
	}
}
