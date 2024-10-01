
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Eamon;
using Eamon.Framework;
using Eamon.Framework.Args;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Plugin
{
	// This Sample Adventure implements the concept of a logical group - a set of related Artifacts
	// represented by a higher-level Artifact when they all share the same Location.  Although this
	// logic is somewhat complex, it may be refactored later to adopt a simpler approach if one is
	// discovered.  Regardless, the code can be generalized within a game to accommodate multiple
	// logical groups if necessary.
	//
	// The whole idea of Group Artifacts (as a complement to Group Monsters) and logical groups (as
	// represented here) would be an attractive addition to the EamonRT game engine.  But both the
	// design and implementation would be challenging.  This may be put on the work list at some
	// point, but for now, at least this reference implementation is available.

	public class Engine : EamonRT.Game.Plugin.Engine, Framework.Plugin.IEngine
	{
		public virtual string[] UtensilArtifactNames { get; set; }

		public virtual long[] UtensilArtifactUids { get; set; }

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

		public override RetCode GetRecordNameList(IList<IGameBase> recordList, IRecordNameListArgs args, StringBuilder buf)
		{
			RetCode rc;

			Debug.Assert(recordList != null);

			// Strip out knife, fork and spoon Artifacts when utensils Artifact present in list

			if (recordList.FirstOrDefault(r => r is IArtifact a && a.Uid == 4) != null)
			{
				recordList = recordList.Where(r => !(r is IArtifact a) || !UtensilArtifactUids.Contains(a.Uid)).ToList();
			}

			rc = base.GetRecordNameList(recordList, args, buf);

			return rc;
		}

		public virtual void SplitUtensils()
		{
			var knifeArtifact = ADB[1];

			Debug.Assert(knifeArtifact != null);

			var forkArtifact = ADB[2];

			Debug.Assert(forkArtifact != null);

			var spoonArtifact = ADB[3];

			Debug.Assert(spoonArtifact != null);

			var utensilsArtifact = ADB[4];

			Debug.Assert(utensilsArtifact != null);

			if (!utensilsArtifact.IsInLimbo())
			{
				knifeArtifact.Location = utensilsArtifact.Location;

				forkArtifact.Location = utensilsArtifact.Location;

				spoonArtifact.Location = utensilsArtifact.Location;
			}
		}

		public virtual void CoalesceUtensils()
		{
			var knifeArtifact = ADB[1];

			Debug.Assert(knifeArtifact != null);

			var forkArtifact = ADB[2];

			Debug.Assert(forkArtifact != null);

			var spoonArtifact = ADB[3];

			Debug.Assert(spoonArtifact != null);

			var utensilsArtifact = ADB[4];

			Debug.Assert(utensilsArtifact != null);

			if (knifeArtifact.Location == forkArtifact.Location && forkArtifact.Location == spoonArtifact.Location)
			{
				if (utensilsArtifact.IsInLimbo())
				{
					utensilsArtifact.Location = knifeArtifact.Location;
				}

				knifeArtifact.SetCarriedByContainer(utensilsArtifact);

				forkArtifact.SetCarriedByContainer(utensilsArtifact);

				spoonArtifact.SetCarriedByContainer(utensilsArtifact);
			}
			else
			{
				utensilsArtifact.SetInLimbo();
			}
		}

		public Engine()
		{
			UtensilArtifactNames = new string[] { "knife", "fork", "spoon" };

			UtensilArtifactUids = new long[] { 1, 2, 3 };

			// The @@001 token in Module description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () => System.IO.Path.DirectorySeparatorChar.ToString());
		}
	}
}
