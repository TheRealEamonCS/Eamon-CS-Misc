
// Artifact.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Artifact : Eamon.Game.Artifact, IArtifact
	{
		public override bool ShouldExposeContentsToRoom(ContainerType containerType = ContainerType.In)
		{
			// Control panel exposes contents to room

			if (Uid == 2 /* && containerType == ContainerType.On */)			// Note: could uncomment to only expose OnContainer contents
			{
				return true;
			}
			else
			{
				return base.ShouldExposeContentsToRoom(containerType);
			}
		}
	}
}
