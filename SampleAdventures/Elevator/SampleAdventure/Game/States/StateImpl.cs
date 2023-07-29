
// StateImpl.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class StateImpl : EamonRT.Game.States.StateImpl, IStateImpl
	{
		public override void PrintObjBlocksTheWay(IArtifact artifact)
		{
			Debug.Assert(artifact != null);

			// Elevator

			if (artifact.Uid == 1)
			{
				gOut.Print("{0} door blocks the way!", artifact.GetTheName(true));
			}
			else
			{
				base.PrintObjBlocksTheWay(artifact);
			}
		}
	}
}
