
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Eamon;
using Eamon.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Plugin
{
	public class Engine : EamonRT.Game.Plugin.Engine, Framework.Plugin.IEngine
	{
		StringBuilder Framework.Plugin.IEngine.Buf { get; set; }

		StringBuilder Framework.Plugin.IEngine.Buf01 { get; set; }

		public virtual long MinElevatorRoomUid { get; set; }

		public virtual long MaxElevatorRoomUid { get; set; }

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

			MacroFuncs.Add(2, () =>
			{
				var result = "a button";

				if (GameState != null && GameState.Ro != MinElevatorRoomUid && GameState.Ro != MaxElevatorRoomUid)
				{
					result = "some buttons";
				}

				return result;
			});

			var synonyms = new Dictionary<long, string[]>()
			{
				{ 1, new string[] { "elevator door", "door" } },
				{ 2, new string[] { "panel" } },
				{ 3, new string[] { "button" } },
				{ 4, new string[] { "button" } },
				{ 5, new string[] { "panel" } },
				{ 6, new string[] { "S1", "button" } },
				{ 7, new string[] { "L1", "button" } },
				{ 8, new string[] { "L2", "button" } },
			};

			foreach (var synonym in synonyms)
			{
				CreateArtifactSynonyms(synonym.Key, synonym.Value);
			}
		}

		public Engine()
		{
			((Framework.Plugin.IEngine)this).Buf = new StringBuilder(BufSize);

			((Framework.Plugin.IEngine)this).Buf01 = new StringBuilder(BufSize);

			// Accommodate oversized Room Descs

			RmDescLen = 512;

			StartRoom = 2;

			PoundCharPolicy = PoundCharPolicy.None;

			MinElevatorRoomUid = 1;			// Should be the lowest elevator exit Room Uid

			MaxElevatorRoomUid = 3;       // Should be the highest elevator exit Room Uid

			// The @@001 token in Module description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () => System.IO.Path.DirectorySeparatorChar.ToString());
		}
	}
}
