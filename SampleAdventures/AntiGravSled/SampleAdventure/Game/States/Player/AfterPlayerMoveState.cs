
// AfterPlayerMoveState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class AfterPlayerMoveState : EamonRT.Game.States.AfterPlayerMoveState, IAfterPlayerMoveState
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			if (eventType == EventType.AfterMoveMonsters)
			{
				var antiGravSledArtifact = gADB[1];

				Debug.Assert(antiGravSledArtifact != null);

				// Anti-grav sled follows player around

				if (antiGravSledArtifact.IsInRoomUid(gGameState.R3) && gGameState.AntiGravSledActivated)
				{
					gOut.Print("{0}, sensing your movement, follows behind you dutifully.", antiGravSledArtifact.GetTheName(true));

					antiGravSledArtifact.SetInRoomUid(gGameState.Ro);
				}
			}
		}
	}
}
