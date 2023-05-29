
// ProcessPlayerInputState.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Game.Attributes;
using EamonRT.Framework.States;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.States
{
	[ClassMappings]
	public class ProcessPlayerInputState : EamonRT.Game.States.ProcessPlayerInputState, IProcessPlayerInputState
	{
		public override void Execute()
		{
			gEngine.SplitUtensils();

			base.Execute();
		}
	}
}
