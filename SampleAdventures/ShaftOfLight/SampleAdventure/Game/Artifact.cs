
// Artifact.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Artifact : Eamon.Game.Artifact, IArtifact
	{
		public override string StateDesc
		{
			get
			{
				// Change shaft of light state description if no light source present

				return gEngine.EnableMutateProperties && Uid == 2 && IsInRoomUid(2) && gGameState.Ls <= 0 ? "shimmering in the darkness" : base.StateDesc;
			}

			set
			{
				base.StateDesc = value;
			}
		}
	}
}
