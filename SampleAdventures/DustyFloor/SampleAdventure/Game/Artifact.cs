
// Artifact.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Artifact : Eamon.Game.Artifact, IArtifact
	{
		public override long Location
		{
			get
			{
				if (gEngine.EnableMutateProperties && gGameState.Ro > 0 && Uid == 1)
				{
					var room = gRDB[gGameState.Ro] as Framework.IRoom;

					Debug.Assert(room != null);

					// If player character is in a dusty floor Room, floor Artifact is present; otherwise it isn't

					return room.IsDustyFloorRoom() ? gGameState.Ro : base.Location;
				}
				else
				{
					return base.Location;
				}
			}

			set
			{
				base.Location = value;
			}
		}
	}
}
