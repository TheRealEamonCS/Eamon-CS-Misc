
// LightCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class LightCommand : EamonRT.Game.Commands.LightCommand, ILightCommand
	{
		public override void Execute()
		{
			Debug.Assert(DobjArtifact != null);

			// For light switch redirect to UseCommand

			if (DobjArtifact.Uid == 1)
			{
				var command = Globals.CreateInstance<IUseCommand>();

				CopyCommandData(command);

				NextState = command;
			}
			else
			{
				base.Execute();
			}
		}
	}
}
