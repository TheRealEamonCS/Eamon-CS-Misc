
// IEngine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;

namespace SampleAdventure.Framework.Plugin
{
	public interface IEngine : EamonRT.Framework.Plugin.IEngine
	{
		bool ShouldScimitarStickToHand(IMonster monster);		// Note:  this should probably be a Monster method, but to keep it simple, we'll put it here

		void PrintScimitarSticksToHand(IRoom room, IMonster monster, IArtifact artifact, bool combatFumble = false, bool newLinePrefix = false);
	}
}
