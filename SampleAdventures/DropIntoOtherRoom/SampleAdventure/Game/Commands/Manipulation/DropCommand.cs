
// DropCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class DropCommand : EamonRT.Game.Commands.DropCommand, IDropCommand
	{
		public override void ProcessArtifact(IArtifact artifact)
		{
			Debug.Assert(artifact != null);

			base.ProcessArtifact(artifact);

			// Drop on pedestal

			if (ActorRoom.Uid == 2)
			{
				if (ActorRoom.IsViewable())
				{
					gOut.Print("{0}{1} fall{2} to the floor below.", Environment.NewLine, artifact.GetTheName(true), artifact.EvalPlural("s", ""));
				}

				artifact.SetInRoomUid(1);
			}
		}
	}
}
