
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Diagnostics;
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

			// The @@001 token in light switch description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () =>
			{
				var lightSwitchArtifact = ADB[1];

				Debug.Assert(lightSwitchArtifact != null);

				return lightSwitchArtifact.Field1 == 1 ? ", which is turned on." : ", which is turned off.";
			});

			var synonyms = new Dictionary<long, string[]>()
			{
				{ 1, new string[] { "switch" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateArtifactSynonyms(synonym.Key, synonym.Value);
			}
		}
	}
}
