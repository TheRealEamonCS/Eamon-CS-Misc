
// UseCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using Eamon.Framework.Primitive.Enums;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

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
				var computerCenterRoom = gRDB[2];

				Debug.Assert(computerCenterRoom != null);

				// Since light switch is a Treasure, just use Field1

				DobjArtifact.Field1 = DobjArtifact.Field1 == 0 ? 1 : 0;

				// The light switch controls the Computer Center's light level

				computerCenterRoom.LightLvl = DobjArtifact.Field1 == 1 ? LightLevel.Light : LightLevel.Dark;

				gOut.Print("You turn the light switch {0}.", DobjArtifact.Field1 == 1 ? "on" : "off");

				NextState = gEngine.CreateInstance<IMonsterStartState>();
			}
			else
			{
				base.Execute();
			}
		}
	}
}
