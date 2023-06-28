
// DropCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using System.Linq;
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

			var utensilsArtifact = gADB[4];

			Debug.Assert(utensilsArtifact != null);

			// For DROP ALL, omit knife, fork and spoon Artifacts when utensils Artifact in game

			if (!DropAll || !gEngine.UtensilArtifactUids.Contains(artifact.Uid) || utensilsArtifact.IsInLimbo())
			{
				base.ProcessArtifact(artifact);
			}
		}
	}
}
