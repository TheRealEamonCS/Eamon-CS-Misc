
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Diagnostics;
using Eamon.Framework;
using Eamon.Game.Attributes;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game
{
	[ClassMappings(typeof(IEngine))]
	public class Engine : EamonRT.Game.Engine, EamonRT.Framework.IEngine
	{
		public override void InitArtifacts()
		{
			base.InitArtifacts();

			// The @@001 token in Shotgun Shells description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () =>
			{
				var shotgunShellsArtifact = gADB[1];

				Debug.Assert(shotgunShellsArtifact != null);

				return string.Format("{0} shotgun shell{1}", shotgunShellsArtifact.Field1, shotgunShellsArtifact.Field1 != 1 ? "s" : "");
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
	}
}
