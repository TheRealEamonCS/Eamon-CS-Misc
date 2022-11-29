
// ComponentImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using EamonRT.Framework.Components;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Components
{
	[ClassMappings]
	public class ComponentImpl : EamonRT.Game.Components.ComponentImpl, IComponentImpl
	{
		public override void PrintAlreadyBrokeIt(IArtifact artifact)
		{
			Debug.Assert(artifact != null);

			// Tangle of overgrowth

			if (artifact.Uid == 1)
			{
				gOut.Print("You've already cleared a path through {0}.", artifact.GetTheName());
			}
			else
			{
				base.PrintAlreadyBrokeIt(artifact);
			}
		}

		public override void PrintSmashesToPieces(IRoom room, IArtifact artifact, bool spillContents)
		{
			Debug.Assert(artifact != null);

			// Tangle of overgrowth

			if (artifact.Uid == 1)
			{
				gOut.Print("The path opens up as you cut through the last of {0}.", artifact.EvalPlural("it", "them"));
			}
			else
			{
				base.PrintSmashesToPieces(room, artifact, spillContents);
			}
		}
	}
}
