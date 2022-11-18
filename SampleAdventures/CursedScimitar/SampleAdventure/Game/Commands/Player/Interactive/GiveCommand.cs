
// GiveCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class GiveCommand : EamonRT.Game.Commands.GiveCommand, IGiveCommand
	{
		public override void Execute()
		{
			Debug.Assert(IobjMonster != null);

			base.Execute();

			// Amulet

			if (DobjArtifact != null && DobjArtifact.Uid == 3 && DobjArtifact.IsCarriedByMonster(IobjMonster))
			{
				gOut.Print("{0} wears {1}.", IobjMonster.GetTheName(true, true, false, false, true), DobjArtifact.GetArticleName());

				DobjArtifact.SetWornByMonster(IobjMonster);
			}
		}
	}
}
