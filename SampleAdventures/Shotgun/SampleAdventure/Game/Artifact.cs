
// Artifact.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Artifact : Eamon.Game.Artifact, IArtifact
	{
		public override bool IsReadyableByMonsterUid(long monsterUid)
		{
			// Only player character can wield shotgun

			return Uid != 2 ? base.IsReadyableByMonsterUid(monsterUid) : false;
		}

		public override bool ShouldAddContents(IArtifact artifact, ContainerType containerType = ContainerType.In)
		{
			Debug.Assert(artifact != null);

			// Shotgun can only contain shotgun shells

			return Uid == 2 ? artifact.Uid == 1 : base.ShouldAddContents(artifact, containerType);
		}
	}
}
