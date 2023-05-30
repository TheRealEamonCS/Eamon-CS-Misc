
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Eamon;
using Eamon.Framework.Args;
using Eamon.Framework;
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

		public override RetCode GetRecordNameList(IList<IGameBase> recordList, IRecordNameListArgs args, StringBuilder buf)
		{
			RetCode rc;

			Debug.Assert(recordList != null);

			var utensilArtifactUids = new long[] { 1, 2, 3 };

			// Strip out knife, fork and spoon Artifacts when utensils Artifact present in list

			if (recordList.FirstOrDefault(r => r is IArtifact a && a.Uid == 4) != null)
			{
				recordList = recordList.Where(r => !(r is IArtifact a) || !utensilArtifactUids.Contains(a.Uid)).ToList();
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
	}
}
