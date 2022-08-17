
// PlayerMoveCheckState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class PlayerMoveCheckState : EamonRT.Game.States.PlayerMoveCheckState, IPlayerMoveCheckState
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			if (eventType == EventType.AfterBlockingArtifactCheck && gGameState.R2 == -34)
			{
				// Note: this could easily be made a death trap

				gOut.Print("That would be most unwise.");

				GotoCleanup = true;
			}
		}
	}
}
