
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
		public override void ExecuteForPlayer()
		{
			Debug.Assert(DobjArtifact != null);

			var hazMatSuitArtifact = gADB[1];

			Debug.Assert(hazMatSuitArtifact != null);

			// Can't wear armor while wearing Haz-Mat suit

			if (DobjArtifact.Wearable != null && DobjArtifact.Wearable.Field1 > 1 && gGameState.Ar <= 0 && hazMatSuitArtifact.IsWornByMonster(ActorMonster))
			{
				PrintWearingRemoveFirst01(hazMatSuitArtifact);

				NextState = gEngine.CreateInstance<IStartState>();
			}
			else
			{
				base.ExecuteForPlayer();
			}
		}
	}
}
