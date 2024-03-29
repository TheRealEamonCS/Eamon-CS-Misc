﻿
// GetPlayerInputState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Components;
using EamonRT.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class GetPlayerInputState : EamonRT.Game.States.GetPlayerInputState, IGetPlayerInputState
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			var hazMatSuitArtifact = gADB[1];

			Debug.Assert(hazMatSuitArtifact != null);

			Debug.Assert(gCharMonster != null);

			Debug.Assert(gCharRoom != null);

			// In the chemical factory

			if (eventType == EventType.BeforePrintCommandPrompt && gEngine.ShouldPreTurnProcess && gGameState.Ro == 2 && gGameState.CurrTurn % 2 == 0 && !hazMatSuitArtifact.IsWornByMonster(gCharMonster))
			{
				gOut.Print("The toxic chemical fumes damage your lungs and make you dizzy!");

				var combatComponent = gEngine.CreateInstance<ICombatComponent>(x =>
				{
					x.SetNextStateFunc = s => NextState = s;

					x.ActorRoom = gCharRoom;

					x.Dobj = gCharMonster;

					x.OmitArmor = true;
				});

				combatComponent.ExecuteCalculateDamage(1, 1);

				if (gGameState.Die > 0)
				{
					GotoCleanup = true;

					goto Cleanup;
				}
			}

		Cleanup:

			;
		}
	}
}
