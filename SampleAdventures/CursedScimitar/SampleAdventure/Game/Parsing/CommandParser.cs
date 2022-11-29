
// CommandParser.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Game.Attributes;
using Eamon.Game.Extensions;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Parsing;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Parsing
{
	[ClassMappings]
	public class CommandParser : EamonRT.Game.Parsing.CommandParser, ICommandParser
	{
		public override void CheckPlayerCommand(bool afterFinishParsing)
		{
			Debug.Assert(NextCommand != null);

			if (afterFinishParsing)
			{
				var amuletArtifact = gADB[3];

				Debug.Assert(amuletArtifact != null);

				// Restrict various commands if scimitar is readied weapon and amulet not worn

				if ((NextCommand is IDropCommand || NextCommand is IGiveCommand) && DobjArtifact != null && DobjArtifact.Uid == 2 && ActorMonster.Weapon == 2 && !amuletArtifact.IsWornByCharacter())
				{
					gOut.Print("The malevolent {0} stubbornly sticks to your hand!", DobjArtifact.GetNoneName());

					NextState = gEngine.CreateInstance<IMonsterStartState>();
				}
				else if (NextCommand is IRequestCommand && DobjArtifact != null && DobjArtifact.Uid == 2 && IobjMonster != null && IobjMonster.Weapon == 2 && !amuletArtifact.IsWornByMonster(IobjMonster))
				{
					gOut.Print("The malevolent {0} stubbornly sticks to {1} hand!", DobjArtifact.GetNoneName(), IobjMonster.GetTheName().AddPossessiveSuffix());

					NextState = gEngine.CreateInstance<IMonsterStartState>();
				}
				else
				{
					base.CheckPlayerCommand(afterFinishParsing);
				}
			}
			else
			{
				base.CheckPlayerCommand(afterFinishParsing);
			}
		}
	}
}
