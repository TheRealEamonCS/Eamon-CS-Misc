
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Diagnostics;
using System.Reflection;
using Eamon;
using Eamon.Framework;
using Eamon.Game.Extensions;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Plugin
{
	public class Engine : EamonRT.Game.Plugin.Engine, Framework.Plugin.IEngine
	{
		public override RetCode LoadPluginClassMappings()
		{
			RetCode rc;

			rc = base.LoadPluginClassMappings();

			if (rc != RetCode.Success)
			{
				goto Cleanup;
			}

			rc = LoadPluginClassMappings01(Assembly.GetExecutingAssembly());

		Cleanup:

			return rc;
		}

		public virtual bool ShouldScimitarStickToHand(IMonster monster)
		{
			Debug.Assert(monster != null);

			var amuletArtifact = ADB[3];

			Debug.Assert(amuletArtifact != null);

			return monster.Weapon == 2 && !amuletArtifact.IsWornByMonster(monster);
		}

		public virtual void PrintScimitarSticksToHand(IRoom room, IMonster monster, IArtifact artifact, bool combatFumble = false, bool newLinePrefix = false)
		{
			Debug.Assert(room != null && artifact != null);

			var isCharacterMonster = monster == null || monster.IsCharacterMonster();

			Out.Print("{0}The malevolent {1} stubbornly sticks to {2} hand!", 
				newLinePrefix ? Environment.NewLine : "", 
				isCharacterMonster || room.IsLit() ? artifact.GetNoneName() : "weapon", 
				room.IsLit() ?
					(!isCharacterMonster ? monster.GetTheName().AddPossessiveSuffix() : "your") :
					(!isCharacterMonster && combatFumble ? "the offender's" : !isCharacterMonster ? "the entity's" : "your"));
		}
	}
}
