
// IEngine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;

namespace SampleAdventure.Framework.Plugin
{
	public interface IEngine : EamonRT.Framework.Plugin.IEngine
	{
		bool ShouldScimitarStickToHand(IMonster monster);

		void PrintScimitarSticksToHand(IRoom room, IMonster monster, IArtifact artifact, bool combatFumble = false, bool newLinePrefix = false);
	}
}
