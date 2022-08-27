
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

			// The @@001 token in Room 2 description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () =>
			{
				var hazMatSuitArtifact = gADB[1];

				Debug.Assert(hazMatSuitArtifact != null);

				return !hazMatSuitArtifact.IsWornByCharacter() ? "And you have forgotten to wear your Haz-Mat suit!" : "";
			});

			var synonyms = new Dictionary<long, string[]>()
			{
				{ 1, new string[] { "haz mat suit", "suit" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateArtifactSynonyms(synonym.Key, synonym.Value);
			}
		}
	}
}
