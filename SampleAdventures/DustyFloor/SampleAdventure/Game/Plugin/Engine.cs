
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

			// The @@001 token in dusty floor description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () =>
			{
				var dustyFloorArtifact = ADB[1];

				Debug.Assert(dustyFloorArtifact != null);

				var result = "";

				var room = dustyFloorArtifact.GetInRoom() as Framework.IRoom;

				if (room != null)
				{
					switch (room.Traversals)
					{
						case 0:
							result = "The dust on the floor is thick and undisturbed.";
							break;
						case 1:
							result = "The dust on the floor shows faint signs of disturbance.";
							break;
						case 2:
							result = "You can make out faint tracks in the dust on the floor.";
							break;
						case 3:
							result = "The dust on the floor shows signs of heavy traffic through the area.";
							break;
						default:
							result = "You can make out clear trails through the dust on the floor, running between the room exits.";
							break;
					}
				}

				return result;
			});

			var synonyms = new Dictionary<long, string[]>()
			{
				{ 1, new string[] { "floor" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateArtifactSynonyms(synonym.Key, synonym.Value);
			}
		}
	}
}
