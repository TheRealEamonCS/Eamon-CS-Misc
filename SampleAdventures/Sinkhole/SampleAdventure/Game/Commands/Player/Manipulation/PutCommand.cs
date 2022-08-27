
// PutCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Primitive.Enums;
using System.Diagnostics;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class PutCommand : EamonRT.Game.Commands.PutCommand, IPutCommand
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			// Put anything in sinkhole destroys it

			if (eventType == EventType.AfterPutArtifact && IobjArtifact.Uid == 1)
			{
				if (ActorRoom.IsLit())
				{
					gOut.Print("{0} plummet{1} into the depths of the sinkhole!", DobjArtifact.GetTheName(true), DobjArtifact.EvalPlural("s", ""));
				}

				DobjArtifact.SetInLimbo();
			}
		}

		public override void Execute()
		{
			Debug.Assert(DobjArtifact != null && IobjArtifact != null);

			if (IobjArtifact.Uid == 1)
			{
				gEngine.ConvertTreasureToContainer(IobjArtifact);
			}

			base.Execute();

			if (IobjArtifact.Uid == 1)
			{
				gEngine.ConvertContainerToTreasure(IobjArtifact);
			}
		}
	}
}
