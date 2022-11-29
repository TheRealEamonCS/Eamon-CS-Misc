
// CombatComponent.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using Eamon.Game.Attributes;
using EamonRT.Framework.Components;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Components
{
	[ClassMappings]
	public class CombatComponent : EamonRT.Game.Components.CombatComponent, ICombatComponent
	{
		public override void AttackHitArtifact()
		{
			base.AttackHitArtifact();

			// Tangle of overgrowth; cap bladed weapon damage at 1D6 (machete excepted)

			if (DobjArtifact.Uid == 1 && ActorWeapon != null && ActorWeapon.Uid != 2 && (D * S) > 6)
			{
				D = 1;

				S = 6;
			}
		}

		public override void CheckArtifactStatus()
		{
			base.CheckArtifactStatus();

			// Tangle of overgrowth

			if (DobjArtifact.Uid == 1 && DobjArtifact.DoorGate.GetKeyUid() != -2)
			{
				gOut.Print("You figure you're about {0}% of the way through it.", (long)Math.Min(100, (((double)(1050 - BreakageStrength) / (double)50) * 100)));
			}
		}
	}
}
