
// KissCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using EamonRT.Framework.States;
using System.Diagnostics;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	// Demonstrates a command that accepts a direct object (both monster and artifact).

	[ClassMappings]
	public class KissCommand : EamonRT.Game.Commands.Command, Framework.Commands.IKissCommand
	{
		public override void Execute()
		{
			Debug.Assert(DobjArtifact != null || DobjMonster != null);

			var stat = gEngine.GetStat(Stat.Charisma);

			Debug.Assert(stat != null);

			// Kiss monster

			if (DobjMonster != null)
			{
				if (DobjMonster.Uid == 1 && DobjMonster.Reaction >= Friendliness.Neutral && gCharacter.GetStat(Stat.Charisma) >= stat.MaxValue)
				{
					if (!gGameState.AmandaArmandKissed)
					{
						gOut.Print("You suddenly lean in and kiss {0}.  {1} seems surprised but receptive for some unknown reason!", DobjMonster.GetTheName(), DobjMonster.EvalGender("He", "She", "It"));

						gOut.Print("{0} smiles at you.", DobjMonster.GetTheName(true));

						DobjMonster.Friendliness = Friendliness.Friend;

						DobjMonster.Reaction = Friendliness.Friend;

						gGameState.AmandaArmandKissed = true;
					}
					else
					{
						gOut.Print("{0} has had quite enough of that!", DobjMonster.GetTheName(true));
					}
				}
				else
				{
					gOut.Print("{0} vigorously rebuffs your amorous advances!  Oh, the embarrassment!", DobjMonster.GetTheName(true));
				}

				goto Cleanup;
			}

			// Kiss artifact

			if (DobjArtifact.Uid == 1 && gCharacter.GetStat(Stat.Charisma) < stat.MaxValue)
			{
				gOut.Print("You lean in and kiss {0}.  The stone glows as a strange warmth courses through your body.  You feel like something's changed but can't quite put your finger on it.", DobjArtifact.GetTheName());

				gCharacter.SetStat(Stat.Charisma, stat.MaxValue);
			}
			else
			{
				gOut.Print("You kiss {0}, but nothing happens.", DobjArtifact.GetTheName());
			}

		Cleanup:

			if (NextState == null)
			{
				NextState = gEngine.CreateInstance<IMonsterStartState>();
			}
		}

		public KissCommand()
		{
			SortOrder = 440;

			IsNew = true;

			Name = "KissCommand";

			Verb = "kiss";

			Type = CommandType.Interactive;
		}
	}
}
