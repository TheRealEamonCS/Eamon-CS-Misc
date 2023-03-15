
// CombatComponent.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Components;
using EamonRT.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Components
{
	[ClassMappings]
	public class CombatComponent : EamonRT.Game.Components.CombatComponent, ICombatComponent
	{
		public override void AttackFumbleWeaponDropped()
		{
			// If scimitar is readied weapon and amulet not worn

			if (ActorMonster.Weapon == 2 && gEngine.ShouldScimitarStickToHand(ActorMonster))
			{
				gEngine.PrintScimitarSticksToHand(ActorRoom, ActorMonster, ActorWeapon, true, true);

				CombatState = CombatState.EndAttack;

				GotoCleanup = true;
			}
			else
			{
				base.AttackFumbleWeaponDropped();
			}
		}
	}
}
