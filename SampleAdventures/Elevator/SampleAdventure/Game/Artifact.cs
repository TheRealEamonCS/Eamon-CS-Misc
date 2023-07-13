
// Artifact.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Linq;
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
				var result = base.Location;

				if (gEngine.EnableMutateProperties)
				{
					switch (Uid)
					{
						case 1:     // Elevator
						case 2:		// Control panel
						{
							var roomUids = new long[] { 1, 2, 3 };			// Should contain all elevator exit rooms

							if (roomUids.Contains(gGameState.Ro))
							{
								result = gGameState.Ro;
							}

							break;
						}
					}
				}

				return result;
			}

			set
			{
				base.Location = value;
			}
		}
	}
}
