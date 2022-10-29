
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
		public override void PrintAttack(IRoom room, IMonster actorMonster, IMonster dobjMonster, IArtifact weapon, long attackNumber, WeaponRevealType weaponRevealType)
		{
			Debug.Assert(room != null && actorMonster != null && dobjMonster != null /* && attackNumber > 0 && Enum.IsDefined(typeof(WeaponRevealType), weaponRevealType) */);

			var room01 = room as Framework.IRoom;

			Debug.Assert(room01 != null);

			if (room01.IsDustyFloorRoom())
			{
				// Set internal variables, but suppress output

				gOut.EnableOutput = false;

				base.PrintAttack(room, actorMonster, dobjMonster, weapon, attackNumber, weaponRevealType);

				gOut.EnableOutput = true;

				var disturbsDustChances = 100 - (Math.Min(room01.Traversals, 4) * 20);

				var disturbsDustDesc = gEngine.RollDice(1, 100, 0) <= disturbsDustChances ? ", stirring up billowing clouds of dust" : "";

				// Now output for real

				gOut.Write("{0}{1} {2} {3}{4}{5}.",
					Environment.NewLine,
					ActorMonsterName,
					AttackDesc,
					DobjMonsterName,
						weapon != null &&
						(weaponRevealType == WeaponRevealType.Always ||
						(weaponRevealType == WeaponRevealType.OnlyIfSeen && weapon.Seen)) ?
							" with " + weapon.GetArticleName() :
							"",
						disturbsDustDesc);
			}
			else
			{
				base.PrintAttack(room, actorMonster, dobjMonster, weapon, attackNumber, weaponRevealType);
			}
		}
	}
}
