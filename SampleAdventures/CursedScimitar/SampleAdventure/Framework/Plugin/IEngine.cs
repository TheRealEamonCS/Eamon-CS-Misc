
// IEngine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Text;
using Eamon.Framework;

namespace SampleAdventure.Framework.Plugin
{
	/// <inheritdoc />
	public interface IEngine : EamonRT.Framework.Plugin.IEngine
	{
		/// <summary></summary>
		new StringBuilder Buf { get; set; }

		/// <summary></summary>
		new StringBuilder Buf01 { get; set; }

		bool ShouldScimitarStickToHand(IMonster monster);		// Note:  this should probably be a Monster method, but to keep it simple, we'll put it here

		void PrintScimitarSticksToHand(IRoom room, IMonster monster, IArtifact artifact, bool combatFumble = false, bool prependNewLine = false);
	}
}
