﻿
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Reflection;
using Eamon;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Plugin
{
	public class Engine : EamonRT.Game.Plugin.Engine, Framework.Plugin.IEngine
	{
		public override RetCode LoadPluginClassMappings()
		{
			RetCode rc;

			rc = base.LoadPluginClassMappings();

			if (rc != RetCode.Success)
			{
				goto Cleanup;
			}

			rc = LoadPluginClassMappings01(Assembly.GetExecutingAssembly());

		Cleanup:

			return rc;
		}

		public override void InitArtifacts()
		{
			base.InitArtifacts();

			var synonyms = new Dictionary<long, string[]>()
			{
				{ 1, new string[] { "bottomless pit", "sink hole", "hole", "pit" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateArtifactSynonyms(synonym.Key, synonym.Value);
			}
		}

		public Engine()
		{
			// The @@001 token in Module description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () => System.IO.Path.DirectorySeparatorChar.ToString());
		}
	}
}
