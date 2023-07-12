
// CommandParser.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Parsing;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Parsing
{
	[ClassMappings]
	public class CommandParser : EamonRT.Game.Parsing.CommandParser, ICommandParser
	{
		public virtual void FinishParsingPushCommand()
		{
			ResolveRecord(false);
		}
	}
}
