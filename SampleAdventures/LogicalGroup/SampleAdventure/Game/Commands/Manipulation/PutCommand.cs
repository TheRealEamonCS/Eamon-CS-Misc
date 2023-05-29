
// PutCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.States;
using System.Diagnostics;
using System;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class PutCommand : EamonRT.Game.Commands.PutCommand, IPutCommand
	{
		public override void ExecuteForPlayer()
		{
			Debug.Assert(DobjArtifact != null && IobjArtifact != null);

			// Can't put anything into the utensils

			if (IobjArtifact.Uid == 4)
			{
				gOut.Print("If you did that, it would no longer be a set of {0}.", IobjArtifact.GetNoneName());

				NextState = gEngine.CreateInstance<IMonsterStartState>();
			}
			else
			{
				base.ExecuteForPlayer();
			}
		}
	}
}
