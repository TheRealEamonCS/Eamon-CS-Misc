﻿
// IEngine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

namespace SampleAdventure.Framework.Plugin
{
	public interface IEngine : EamonRT.Framework.Plugin.IEngine
	{
		string MuralData { get; set; }
	}
}