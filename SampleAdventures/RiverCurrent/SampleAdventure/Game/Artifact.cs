
// Artifact.cs

// Copyright (c) 2014+ by Michael R. Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Artifact : Eamon.Game.Artifact, IArtifact
	{
		public override long Location 
		{ 
			get
			{
				return base.Location;
			}

			set
			{
				base.Location = value;

				var room = value > 0 ? gRDB[value] as Framework.IRoom : null;

				// Schedule next river current event; lambda ensures only one event ever outstanding

				if (Globals.EnableGameOverrides && gGameState != null && room != null && room.IsRiverRoom())
				{
					gGameState.BeforePrintPlayerRoomEventHeap.Insert(gGameState.CurrTurn + 5, "SweepArtifactsDownstream", (k, v) => v.EventName == "SweepArtifactsDownstream");
				}
			}
		}
	}
}
