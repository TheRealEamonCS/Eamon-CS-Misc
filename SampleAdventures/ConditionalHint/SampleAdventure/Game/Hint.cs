
// Hint.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings]
	public class Hint : Eamon.Game.Hint, IHint
	{
		public override bool Active
		{
			get
			{
				if (gEngine.EnableMutateProperties)
				{
					Debug.Assert(gCharRoom != null);

					switch (Uid)
					{
						case 3:

							var magicMacGuffinArtifact = gADB[1];

							Debug.Assert(magicMacGuffinArtifact != null);

							// Show Hint if Magic MacGuffin either in Room or carried by player and also is open

							return (magicMacGuffinArtifact.IsInRoom(gCharRoom) || magicMacGuffinArtifact.IsCarriedByMonster(gCharMonster)) && magicMacGuffinArtifact.InContainer.IsOpen();

						default:

							return base.Active;
					}
				}
				else
				{
					return base.Active;
				}			
			}

			set
			{
				base.Active = value;
			}
		}
	}
}
