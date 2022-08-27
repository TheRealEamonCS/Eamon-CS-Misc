
// BeforePrintPlayerRoomEventState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Eamon.Framework;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using Eamon.Game.Extensions;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class BeforePrintPlayerRoomEventState : EamonRT.Game.States.BeforePrintPlayerRoomEventState, IBeforePrintPlayerRoomEventState
	{
		public virtual void SweepArtifactsDownstreamEvent(object obj)
		{
			var sweptArtifactList = new List<IArtifact>();

			var sweptInArtifactList = new List<IArtifact>();

			var sweptOutArtifactList = new List<IArtifact>();

			var riverRoomList = gRDB.Records.Cast<Framework.IRoom>().Where(r => r.IsRiverRoom()).ToList();

			// Get list of Artifacts that could be swept away

			foreach (var room in riverRoomList)
			{
				sweptArtifactList.AddRange(room.GetTakeableList());
			}

			// River current sweeps Artifacts away

			foreach (var artifact in sweptArtifactList)
			{
				var rl = gEngine.RollDice(1, 100, 0);

				if (artifact.Weight < 10 || rl <= 25)
				{
					var room = artifact.GetInRoom() as Framework.IRoom;

					Debug.Assert(room != null);

					var nextRoomUid = room.GetNextRiverRoomUid();

					var nextRoom = nextRoomUid > 0 ? gRDB[nextRoomUid] : null;

					if (gCharMonster.IsInRoom(room))
					{
						sweptOutArtifactList.Add(artifact);
					}

					if (nextRoom != null)
					{
						if (gCharMonster.IsInRoom(nextRoom))
						{
							sweptInArtifactList.Add(artifact);
						}

						artifact.SetInRoom(nextRoom);			// Note: maybe use a MoveArtifactsBetweenRooms method ???
					}
					else
					{
						artifact.SetInLimbo();
					}
				}
			}

			// Print list of Artifacts swept into player character's Room

			if (sweptInArtifactList.Count > 0)
			{
				Globals.Buf.SetFormat("The swiftly moving current sweeps ");

				gEngine.GetRecordNameList(sweptInArtifactList.Cast<IGameBase>().ToList(), ArticleType.A, true, StateDescDisplayCode.None, false, false, Globals.Buf);

				Globals.Buf.AppendFormat(" in from upstream.");

				gOut.Print("{0}", Globals.Buf.ToString());
			}

			// Print list of Artifacts swept out of player character's Room

			if (sweptOutArtifactList.Count > 0)
			{
				Globals.Buf.SetFormat("The swiftly moving current sweeps ");

				gEngine.GetRecordNameList(sweptOutArtifactList.Cast<IGameBase>().ToList(), ArticleType.A, true, StateDescDisplayCode.None, false, false, Globals.Buf);

				Globals.Buf.AppendFormat(" downstream.");

				gOut.Print("{0}", Globals.Buf.ToString());
			}

			// Schedule next river current event; lambda ensures only one event ever outstanding (swept away Artifact Location change also schedules event)

			if (sweptArtifactList.Count > 0)
			{
				gGameState.BeforePrintPlayerRoomEventHeap.Insert(gGameState.CurrTurn + 5, "SweepArtifactsDownstream", (k, v) => v.EventName == "SweepArtifactsDownstream");
			}
		}
	}
}
