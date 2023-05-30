
// StateImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using Eamon.Game.Attributes;
using Eamon.Game.Extensions;
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
			var matches = gCommandParser?.DobjData?.Name != null ? gEngine.UtensilArtifactNames.FindAllIndexOf(uan => uan.StartsWith(gCommandParser.DobjData.Name, StringComparison.OrdinalIgnoreCase) || uan.EndsWith(gCommandParser.DobjData.Name, StringComparison.OrdinalIgnoreCase)) : new int[] { };

			// Can't remove anything from the utensils

			if (gCommandParser != null && gCommandParser.NextCommand is IRemoveCommand && matches.Length > 0 && gCommandParser.IobjArtifact != null && gCommandParser.IobjArtifact.Uid == 4)
			{
				gOut.Print("You can manipulate the individual {0} directly.", gCommandParser.IobjArtifact.GetNoneName());

				gCommandParser.LastItNameStr = gEngine.UtensilArtifactNames[matches[0]];
			}
			else
			{
				base.PrintDontFollowYou();
			}
		}
	}
}
