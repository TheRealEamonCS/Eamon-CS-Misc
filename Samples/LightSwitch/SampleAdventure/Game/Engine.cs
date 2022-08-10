
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

			MacroFuncs.Add(1, () =>
			{
				var lightSwitchArtifact = gADB[1];

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
