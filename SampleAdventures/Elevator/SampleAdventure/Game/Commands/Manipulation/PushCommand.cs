
// PushCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class PushCommand : EamonRT.Game.Commands.Command, Framework.Commands.IPushCommand
	{
		public override void ExecuteForPlayer()
		{
			Debug.Assert(DobjArtifact != null);

			var elevatorArtifact = gADB[1];

			Debug.Assert(elevatorArtifact != null);

			switch (DobjArtifact.Uid)
			{
				case 3:     // Up button
				case 4:     // Down button

					gOut.Print("{0} pushed.", DobjArtifact.GetNoneName(true));

					if (!gGameState.UpButtonPushed && !gGameState.DownButtonPushed)
					{
						gOut.Print("The elevator arrives from {0}, and the door quietly slides open.", DobjArtifact.Uid == 3 ? (ActorRoom.Uid == gEngine.MinElevatorRoomUid ? "above" : "below") : ActorRoom.Uid == gEngine.MaxElevatorRoomUid ? "below" : "above");

						elevatorArtifact.DoorGate.SetOpen(true);

						gGameState.ElevatorRoomUid = ActorRoom.Uid;

						if (DobjArtifact.Uid == 3)
						{
							gGameState.UpButtonPushed = true;
						}
						else
						{
							gGameState.DownButtonPushed = true;
						}
					}
					else
					{
						gOut.Print("Nothing happens.");
					}

					break;

				case 6:     // S1 button
				case 7:     // L1 button
				case 8:     // L2 button

					gOut.Print("{0} pushed.", DobjArtifact.GetNoneName(true));

					if ((gGameState.UpButtonPushed && gGameState.ElevatorRoomUid >= DobjArtifact.Treasure.Field1) || (gGameState.DownButtonPushed && gGameState.ElevatorRoomUid <= DobjArtifact.Treasure.Field1))
					{
						gOut.Print("{0} flashes briefly.", DobjArtifact.GetTheName(true));
					}
					else
					{
						gOut.Print("The door quietly slides closed and the elevator starts to {0}.", gGameState.UpButtonPushed ? "ascend" : "descend");

						gOut.Print("Moments later, it comes to a halt and the door opens.");

						elevatorArtifact.DoorGate.SetOpen(true);

						gGameState.ElevatorRoomUid = DobjArtifact.Treasure.Field1;
					}

					break;

				default:

					PrintCantVerbObj(DobjArtifact);

					NextState = gEngine.CreateInstance<IStartState>();

					goto Cleanup;
			}

		Cleanup:

			if (NextState == null)
			{
				NextState = gEngine.CreateInstance<IMonsterStartState>();
			}
		}

		public PushCommand()
		{
			Synonyms = new string[] { "press" };

			SortOrder = 440;

			IsNew = true;

			Name = "PushCommand";

			Verb = "push";

			Type = CommandType.Manipulation;
		}
	}
}
