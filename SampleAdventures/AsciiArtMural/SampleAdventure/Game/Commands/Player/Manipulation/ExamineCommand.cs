
// ExamineCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Diagnostics;
using System.Text;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class ExamineCommand : EamonRT.Game.Commands.ExamineCommand, IExamineCommand
	{
		public override void Execute()
		{
			Debug.Assert(DobjArtifact != null || DobjMonster != null);

			base.Execute();

			// Mural - please see Engine.cs for more info on this (and credits)

			if (DobjArtifact != null && DobjArtifact.Uid == 1)
			{
				gOut.Print("Gazing at the mural, you can't help but feel a sense of awe:");

				gOut.Print("{0}", gEngine.LineSep);

				gOut.Write("{0}Press any key to continue: ", Environment.NewLine);

				gEngine.Buf.Clear();

				var rc = gEngine.In.ReadField(gEngine.Buf, gEngine.BufSize02, null, ' ', '\0', true, null, gEngine.ModifyCharToNull, null, gEngine.IsCharAny);

				Debug.Assert(gEngine.IsSuccess(rc));

				gEngine.Thread.Sleep(150);

				gOut.Print("{0}", gEngine.LineSep);

				gOut.Print("{0}", Encoding.UTF8.GetString(Convert.FromBase64String(gEngine.MuralData)));
			}
		}
	}
}
