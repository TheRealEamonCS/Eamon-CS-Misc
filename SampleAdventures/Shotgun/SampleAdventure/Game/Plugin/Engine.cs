
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

			// The @@002 token in shotgun shells description will be replaced by a string returned from MacroFunc with key == 2

			MacroFuncs.Add(2, () =>
			{
				var shotgunShellsArtifact = ADB[1];

				Debug.Assert(shotgunShellsArtifact != null);

				return string.Format("{0} shotgun shell{1}", GetStringFromNumber(shotgunShellsArtifact.Field1, false, Buf01), shotgunShellsArtifact.Field1 != 1 ? "s" : "");
			});

			var synonyms = new Dictionary<long, string[]>()
			{
				{ 1, new string[] { "shells", "bullets", "shell", "bullet" } },
				{ 2, new string[] { "gun" } },
				{ 3, new string[] { "bin" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateArtifactSynonyms(synonym.Key, synonym.Value);
			}
		}

		public override void InitMonsters()
		{
			base.InitMonsters();

			var synonyms = new Dictionary<long, string[]>()
			{
				{ 1, new string[] { "jemmas" } },
				{ 2, new string[] { "androids", "android" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateMonsterSynonyms(synonym.Key, synonym.Value);
			}
		}

		public Engine()
		{
			// The @@001 token in Module description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () => System.IO.Path.DirectorySeparatorChar.ToString());
		}
	}
}
