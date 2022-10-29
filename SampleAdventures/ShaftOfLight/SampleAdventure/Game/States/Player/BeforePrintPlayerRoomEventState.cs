
// BeforePrintPlayerRoomEventState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class BeforePrintPlayerRoomEventState : EamonRT.Game.States.BeforePrintPlayerRoomEventState, IBeforePrintPlayerRoomEventState
	{
		public virtual void ShaftOfLightAppearsEvent(object obj)
		{
			Debug.Assert(gCharMonster != null);

			if (gCharMonster.IsInRoomUid(2))
			{
				gOut.Print("A shaft of {0} light erupts from a fixture on the ceiling!", obj as string);
			}

			var shaftOfLightArtifact = gADB[2];

			Debug.Assert(shaftOfLightArtifact != null);

			shaftOfLightArtifact.SetInRoomUid(2);

			// Schedule next shaft of light disappears event

			var fireRound = gGameState.CurrTurn + gEngine.RollDice(1, 5, 5);

			gGameState.BeforePrintPlayerRoomEventHeap.Insert(fireRound, "ShaftOfLightDisappears");
		}

		public virtual void ShaftOfLightDisappearsEvent(object obj)
		{
			Debug.Assert(gCharMonster != null);

			if (gCharMonster.IsInRoomUid(2))
			{
				gOut.Print("The shaft of light fades away over time as the ceiling fixture goes dark.");
			}

			var shaftOfLightArtifact = gADB[2];

			Debug.Assert(shaftOfLightArtifact != null);

			shaftOfLightArtifact.SetInLimbo();

			// Schedule next shaft of light appears event

			var fireRound = gGameState.CurrTurn + gEngine.RollDice(1, 5, 5);

			gGameState.BeforePrintPlayerRoomEventHeap.Insert02(fireRound, "ShaftOfLightAppears", gEngine.GetRandomElement(new string[] { "yellow", "red", "orange", "blue", "green" }));
		}
	}
}
