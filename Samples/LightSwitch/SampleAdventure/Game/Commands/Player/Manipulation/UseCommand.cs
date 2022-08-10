
// UseCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class UseCommand : EamonRT.Game.Commands.UseCommand, IUseCommand
	{
		public override void Execute()
		{
			Debug.Assert(DobjArtifact != null);

			// Turn the light switch on or off

			if (DobjArtifact.Uid == 1)
			{
				gGameState.LightSwitchOn = !gGameState.LightSwitchOn;

				gOut.Print("You turn the light switch {0}.", gGameState.LightSwitchOn ? "on" : "off");

				NextState = Globals.CreateInstance<IMonsterStartState>();
			}
			else
			{
				base.Execute();
			}
		}
	}
}
