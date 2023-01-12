
// IArtifact.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using SampleAdventure.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Framework
{
	public interface IArtifact : Eamon.Framework.IArtifact
	{
		MaterialType MaterialType { get; set; }
	}
}
