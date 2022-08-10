
// Room.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Room : Eamon.Game.Room, IRoom
	{
		public override LightLevel LightLvl 
		{ 
			get
			{
				// The light switch controls the Computer Center's light level

				return Globals.EnableGameOverrides && gGameState != null && gGameState.LightSwitchOn && Uid == 2 ? LightLevel.Light : base.LightLvl;
			}

			set
			{
				base.LightLvl = value;
			}
		}
	}
}
