
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
		// This method is required for all commands that support direct objects.  The
		// method name must follow the pattern FinishParsing[CommandName], so the
		// reflective CommandParser lookup of the method is successful.

		public virtual void FinishParsingKissCommand()
		{
			// The lack of parameters to ResolveRecord causes default behavior - recognizing
			// both monsters and artifacts.  You'd have to supply the proper values for the
			// parameters to recognize just one but not the other.  A simple call to
			// ResolveRecord is all that's needed for the majority of new commands.
			//
			// These FinishParsing methods can get much more complicated, depending on how you
			// want the object resolution to work.  To understand the complexity, you can look
			// at the commands built into the CommandParser in EamonRT.  When creating non-
			// standard FinishParsing methods, it's best to find something vaguely comparable
			// and use that as the starting implementation.  If you try to build one of these
			// methods but get stuck and need assistance, please feel free to contact me.

			ResolveRecord();
		}
	}
}
