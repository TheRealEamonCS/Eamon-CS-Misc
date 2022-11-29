
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Eamon;
using Eamon.Framework.Primitive.Enums;
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
				{ 1, new string[] { "Litry", "Stone" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateArtifactSynonyms(synonym.Key, synonym.Value);
			}
		}

		public override void InitMonsters()
		{
			base.InitMonsters();

			var synonyms = new Dictionary<long, string[]>();

			// Use Armand instead

			if (gCharacter.Gender == Gender.Female)
			{
				var armandMonster = gMDB[1];

				Debug.Assert(armandMonster != null);

				armandMonster.Name = "Armand";

				armandMonster.Desc = "You see a young man named Armand.  He appears to be lost and in need of assistance.  Despite this, he eyes you warily, and your efforts to help may fall on deaf ears.";

				armandMonster.Gender = Gender.Male;

				synonyms.Add(1, new string[] { "young man", "man" });
			}
			else
			{
				synonyms.Add(1, new string[] { "young woman", "woman" });
			}

			foreach (var synonym in synonyms)
			{
				CreateMonsterSynonyms(synonym.Key, synonym.Value);
			}
		}
	}
}
