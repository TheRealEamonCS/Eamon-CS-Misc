﻿
// Globals.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Framework.DataStorage.Generic;

namespace SampleAdventure.Game.Plugin
{
#pragma warning disable IDE1006 // Naming Styles

	/// <inheritdoc cref="EamonRT.Game.Plugin.Globals"/>
	public static class Globals
	{
		/// <inheritdoc cref="EamonRT.Game.Plugin.Globals.gEngine"/>
		public static Framework.Plugin.IEngine gEngine
		{
			get
			{
				return (Framework.Plugin.IEngine)EamonRT.Game.Plugin.Globals.gEngine;
			}
			set
			{
				EamonRT.Game.Plugin.Globals.gEngine = value;
			}
		}

		/// <inheritdoc cref="EamonRT.Game.Plugin.Globals.gADB"/>
		public static IRecordDb<IArtifact> gADB
		{
			get
			{
				return EamonRT.Game.Plugin.Globals.gADB;
			}
		}

		/// <inheritdoc cref="EamonRT.Game.Plugin.Globals.gCharMonster"/>
		public static IMonster gCharMonster
		{
			get
			{
				return EamonRT.Game.Plugin.Globals.gCharMonster;
			}
		}

		/// <inheritdoc cref="EamonRT.Game.Plugin.Globals.gCharRoom"/>
		public static IRoom gCharRoom
		{
			get
			{
				return EamonRT.Game.Plugin.Globals.gCharRoom;
			}
		}
	}

#pragma warning restore IDE1006 // Naming Styles
}
