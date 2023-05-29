
// StateImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class StateImpl : EamonRT.Game.States.StateImpl, IStateImpl
	{
		public override void PrintDontFollowYou()
		{
			// Can't remove anything from the utensils

			if (gCommandParser != null && gCommandParser.NextCommand is IRemoveCommand && gCommandParser.IobjArtifact != null && gCommandParser.IobjArtifact.Uid == 4)
			{
				gOut.Print("You can manipulate the individual {0} directly.", gCommandParser.IobjArtifact.GetNoneName());
			}
			else
			{
				base.PrintDontFollowYou();
			}
		}
	}
}
