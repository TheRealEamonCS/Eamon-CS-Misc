
// ExamineCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Primitive.Enums;
using SampleAdventure.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class ExamineCommand : EamonRT.Game.Commands.ExamineCommand, IExamineCommand
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			// Describe Artifact's material type

			if (eventType == EventType.AfterPrintArtifactFullDesc)
			{
				// Use DobjArtifact for base-level properties and methods; gDobjArtifact allows easy access to new
				// properties and methods defined and implemented by the game.  See Globals.cs for more details.  In
				// practice, you could standardize and use the global macro since everything is available through it,
				// but here both are being used for illustrative purposes.

				gOut.Print("After scrutinizing {0}, you realize {1} made of {2}.",
					DobjArtifact.GetTheName(false),
					DobjArtifact.EvalPlural("it is", "they are"),
					gDobjArtifact(this).MaterialType == MaterialType.None ? "an unidentified material" : gDobjArtifact(this).MaterialType.ToString().ToLower());
			}
		}
	}
}
