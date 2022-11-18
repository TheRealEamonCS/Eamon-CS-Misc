
// ComponentImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using EamonRT.Framework.Components;
using EamonRT.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Components
{
	[ClassMappings]
	public class ComponentImpl : EamonRT.Game.Components.ComponentImpl, IComponentImpl
	{
		public override void PrintWeaponDropped(IRoom room, IMonster monster, IArtifact weapon, WeaponRevealType weaponRevealType)
		{
			Debug.Assert(room != null && monster != null && weapon != null);

			var amuletArtifact = gADB[3];

			Debug.Assert(amuletArtifact != null);

			// If scimitar is readied weapon and amulet not worn

			if (weapon.Uid == 2 && ((monster.IsCharacterMonster() && !amuletArtifact.IsWornByCharacter()) || (!monster.IsCharacterMonster() && !amuletArtifact.IsWornByMonster(monster))))
			{
				gOut.Write("{0}  {1} {2} {3}{4}!",
					Environment.NewLine,
					monster.IsCharacterMonster() ? "You" :
					room.EvalLightLevel("The offender", monster.GetTheName(true, true, false, false, true)),
					monster.IsCharacterMonster() ? "nearly drop" : "nearly drops",
					monster.IsCharacterMonster() || room.IsLit() ?
						(
							(weaponRevealType == WeaponRevealType.Never ||
							(weaponRevealType == WeaponRevealType.OnlyIfSeen && !weapon.Seen)) ?
								weapon.GetArticleName() :
								weapon.GetTheName()
						) :
						"a weapon",
					monster.IsCharacterMonster() || room.IsLit() ?
						string.Format
						(
							" but {0} to {1} hand",
							weapon.EvalPlural("it stubbornly sticks", "they stubbornly stick"),
							monster.IsCharacterMonster() ? "your" : monster.EvalGender("his", "her", "its")
						) :
						""
					);

				gEngine.ScimitarRecovered = true;
			}
			else
			{
				base.PrintWeaponDropped(room, monster, weapon, weaponRevealType);
			}
		}
	}
}
