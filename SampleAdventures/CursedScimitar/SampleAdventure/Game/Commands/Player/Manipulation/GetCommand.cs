
// GetCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
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

			// If scimitar is readied weapon and amulet not worn

			if (artifact.Uid == 2 && NextState is IRequestCommand rc && rc.IobjMonster != null && gEngine.ShouldScimitarStickToHand(rc.IobjMonster))
			{
				gEngine.PrintScimitarSticksToHand(ActorRoom, rc.IobjMonster, artifact);
			}
			else
			{
				base.ProcessArtifact(artifact, ac, ref nlFlag);
			}
		}
	}
}
