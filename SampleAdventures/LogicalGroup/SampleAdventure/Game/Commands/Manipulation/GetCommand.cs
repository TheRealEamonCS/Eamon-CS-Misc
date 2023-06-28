
// GetCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using System.Linq;
using Eamon.Framework;
using Eamon.Framework.Primitive.Classes;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class GetCommand : EamonRT.Game.Commands.GetCommand, IGetCommand
	{
		public override void ProcessArtifact(IArtifact artifact, IArtifactCategory ac, ref bool nlFlag)
		{
			Debug.Assert(artifact != null);

			var utensilsArtifact = gADB[4];

			Debug.Assert(utensilsArtifact != null);

			// For GET ALL, omit knife, fork and spoon Artifacts when utensils Artifact in game

			if (!GetAll || !gEngine.UtensilArtifactUids.Contains(artifact.Uid) || utensilsArtifact.IsInLimbo())
			{
				base.ProcessArtifact(artifact, ac, ref nlFlag);
			}
		}
	}
}
