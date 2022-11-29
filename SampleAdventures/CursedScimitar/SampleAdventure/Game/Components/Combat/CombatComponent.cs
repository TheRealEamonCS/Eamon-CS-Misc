
// CombatComponent.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Components;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Components
{
	[ClassMappings]
	public class CombatComponent : EamonRT.Game.Components.CombatComponent, ICombatComponent
	{
		public override void ExecuteAttack()
		{
			gEngine.ScimitarRecovered = false;

			base.ExecuteAttack();

			// If scimitar is fumbled weapon and amulet not worn

			if (gEngine.ScimitarRecovered)
			{
				if (ActorMonster.IsCharacterMonster())
				{
					ActorWeapon.SetCarriedByCharacter();
				}
				else
				{
					ActorWeapon.SetCarriedByMonster(ActorMonster);
				}

				ActorWeapon.AddStateDesc(ActorWeapon.GetReadyWeaponDesc());

				ActorMonster.Weapon = ActorWeapon.Uid;
			}
		}
	}
}
