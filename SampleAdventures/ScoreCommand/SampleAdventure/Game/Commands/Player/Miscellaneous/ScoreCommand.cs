
// ScoreCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Linq;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	// Demonstrates a simple verb-only command.

	[ClassMappings]
	public class ScoreCommand : EamonRT.Game.Commands.Command, Framework.Commands.IScoreCommand
	{
		public override void Execute()
		{
			// This command is "out-of-band," so don't process start of round light source
			// burn down, etc.

			gEngine.ShouldPreTurnProcess = false;

			// This simple example uses number of rooms explored to calculate the score; you
			// could greatly expand it to include artifacts/monsters found and/or manipulated
			// in various ways, events triggered, etc.  There's no limit to what you can do
			// when calculating the player's score.  Also the percent complete is easily
			// changed to a points system if preferred.

			var rooms = gEngine.Database.RoomTable.Records.Where(r => r.Zone == 2).ToList();

			var seenCount = rooms.Count(r => r.Seen);

			gOut.Print("{0}/{1} tomb rooms explored.", seenCount, rooms.Count);

			var percent = (long)Math.Round(((double)seenCount / (double)rooms.Count) * 100);

			gOut.Print("{0}% of your quest is complete.", percent);

			if (NextState == null)
			{
				NextState = gEngine.CreateInstance<IStartState>();
			}
		}

		public ScoreCommand()
		{
			SortOrder = 440;

			IsNew = true;

			IsSentenceParserEnabled = false;

			IsDarkEnabled = true;

			Name = "ScoreCommand";

			Verb = "score";

			Type = CommandType.Miscellaneous;
		}
	}
}
