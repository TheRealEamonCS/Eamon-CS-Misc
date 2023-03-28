
// DropCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class DropCommand : EamonRT.Game.Commands.DropCommand, IDropCommand
	{
		public override void ProcessArtifact(IArtifact artifact)
		{
			Debug.Assert(artifact != null);

			// If scimitar is readied weapon and amulet not worn

			if (artifact.Uid == 2 && gEngine.ShouldScimitarStickToHand(ActorMonster))
			{
				gEngine.PrintScimitarSticksToHand(ActorRoom, ActorMonster, artifact, false, DroppedArtifactList[0] != artifact);
			}
			else
			{
				base.ProcessArtifact(artifact);
			}
		}
	}
}
