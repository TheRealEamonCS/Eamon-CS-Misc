
// CommandImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class CommandImpl : EamonRT.Game.Commands.CommandImpl, ICommandImpl
	{
		public override void PrintNothingPrepContainer(IArtifact artifact, ContainerType containerType, bool showCharOwned)
		{
			if (artifact != null && artifact.Uid == 4)
			{
				gOut.Print("{0} consist of a knife, a fork, and a spoon - just what you'd need to eat a meal!", artifact.GetTheName(true));
			}
			else
			{
				base.PrintNothingPrepContainer(artifact, containerType, showCharOwned);
			}
		}
	}
}
