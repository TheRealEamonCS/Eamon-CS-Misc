
// Monster.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Monster : Eamon.Game.Monster, IMonster
	{
		public override long Location
		{
			get
			{
				return base.Location;
			}

			set
			{
				if (gEngine.EnableMutateProperties && base.Location > 0 && base.Location != value)
				{
					var room = gRDB[base.Location] as Framework.IRoom;

					Debug.Assert(room != null);

					if (room.IsDustyFloorRoom())
					{
						room.Traversals++;
					}
				}

				base.Location = value;
			}
		}
	}
}
