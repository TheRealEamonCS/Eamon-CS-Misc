
// MonsterMemberActionState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class MonsterMemberActionState : EamonRT.Game.States.MonsterMemberActionState, IMonsterMemberActionState
	{
		public override void MonsterMemberMiscActionCheck04()
		{
			// base.MonsterMemberMiscActionCheck04();

			var amuletArtifact = gADB[3];

			Debug.Assert(amuletArtifact != null);

			if (amuletArtifact.IsCarriedByMonster(LoopMonster))
			{
				gOut.Print("{0} wears {1}.", LoopMonster.GetTheName(true, true, false, false, true), amuletArtifact.GetArticleName());

				amuletArtifact.SetWornByMonster(LoopMonster);

				GotoCleanup = true;
			}
		}
	}
}
