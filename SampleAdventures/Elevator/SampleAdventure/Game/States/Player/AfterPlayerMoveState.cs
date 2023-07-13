
// AfterPlayerMoveState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using EamonRT.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class AfterPlayerMoveState : EamonRT.Game.States.AfterPlayerMoveState, IAfterPlayerMoveState
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			if (eventType == EventType.AfterExtinguishLightSourceCheck)
			{
				var elevatorArtifact = gADB[1];

				Debug.Assert(elevatorArtifact != null);

				var upButtonArtifact = gADB[3];

				Debug.Assert(upButtonArtifact != null);

				var downButtonArtifact = gADB[4];

				Debug.Assert(downButtonArtifact != null);

				if (gGameState.Ro != gGameState.R3)
				{
					// Exit elevator

					if (gGameState.R3 == 4)
					{
						gOut.Print("The door closes behind you, and the elevator car quickly departs.");

						elevatorArtifact.DoorGate.SetOpen(false);

						gGameState.UpButtonPushed = false;

						gGameState.DownButtonPushed = false;
					}

					upButtonArtifact.SetInLimbo();

					downButtonArtifact.SetInLimbo();

					// Set up/down button Locations

					if (gGameState.ElevatorRoomUid == gEngine.MinElevatorRoomUid)
					{
						upButtonArtifact.SetCarriedByContainerUid(2, ContainerType.On);
					}
					else if (gGameState.ElevatorRoomUid == gEngine.MaxElevatorRoomUid)
					{
						downButtonArtifact.SetCarriedByContainerUid(2, ContainerType.On);
					}
					else
					{
						upButtonArtifact.SetCarriedByContainerUid(2, ContainerType.On);

						downButtonArtifact.SetCarriedByContainerUid(2, ContainerType.On);
					}
				}
			}
		}
	}
}
