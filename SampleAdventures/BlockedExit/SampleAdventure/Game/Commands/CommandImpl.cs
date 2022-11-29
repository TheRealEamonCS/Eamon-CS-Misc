
// CommandImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class CommandImpl : EamonRT.Game.Commands.CommandImpl, ICommandImpl
	{
		public override void PrintBrokeIt(IArtifact artifact)
		{
			Debug.Assert(artifact != null);

			// Tangle of overgrowth

			if (artifact.Uid == 1)
			{
				PrintDontNeedTo();
			}
			else
			{
				base.PrintBrokeIt(artifact);
			}
		}
	}
}
