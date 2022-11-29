
// AttackCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class AttackCommand : EamonRT.Game.Commands.AttackCommand, IAttackCommand
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			var weaponArtifact = gADB[ActorMonster.Weapon];

			Debug.Assert(weaponArtifact != null);

			// Tangle of overgrowth

			if (eventType == EventType.BeforeAttackArtifact && DobjArtifact.Uid == 1 && weaponArtifact.GeneralWeapon.Field2 != (long)Weapon.Sword)
			{
				gOut.Print("Only a long-bladed slashing weapon can cut through {0}.", DobjArtifact.GetTheName());

				NextState = gEngine.CreateInstance<IStartState>();

				GotoCleanup = true;
			}
		}
	}
}
