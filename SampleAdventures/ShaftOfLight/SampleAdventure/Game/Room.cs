
// Room.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
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
				// Computer Center always lit if shaft of light present

				if (Globals.EnableMutateProperties && Uid == 2)
				{
					var shaftOfLightArtifact = gADB[2];

					Debug.Assert(shaftOfLightArtifact != null);

					return shaftOfLightArtifact.IsInRoom(this) ? LightLevel.Light : base.LightLvl;
				}
				else
				{
					return base.LightLvl;
				}
			}

			set
			{
				base.LightLvl = value;
			}
		}
	}
}
