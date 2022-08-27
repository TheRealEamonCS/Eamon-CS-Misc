
// GoCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class GoCommand : EamonRT.Game.Commands.GoCommand, IGoCommand
	{
		public override void Execute()
		{
			Debug.Assert(DobjArtifact != null);

			// Sinkhole

			if (DobjArtifact.Uid == 1)
			{
				// Note: this could easily be made a death trap

				gOut.Print("That would be most unwise.");

				NextState = Globals.CreateInstance<IMonsterStartState>();
			}
			else
			{
				base.Execute();
			}
		}
	}
}
