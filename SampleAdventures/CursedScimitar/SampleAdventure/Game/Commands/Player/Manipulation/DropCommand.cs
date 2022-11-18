
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

			var amuletArtifact = gADB[3];

			Debug.Assert(amuletArtifact != null);

			// If scimitar is readied weapon and amulet not worn

			if (artifact.Uid == 2 && ActorMonster.Weapon == 2 && !amuletArtifact.IsWornByCharacter())
			{
				gOut.Print("{0}The malevolent {1} stubbornly sticks to your hand!", DroppedArtifactList[0] != artifact ? Environment.NewLine : "", artifact.GetNoneName());
			}
			else
			{
				base.ProcessArtifact(artifact);
			}
		}
	}
}
