
// ExamineCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Diagnostics;
using System.Text;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class ExamineCommand : EamonRT.Game.Commands.ExamineCommand, IExamineCommand
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			// Mural - please see Engine.cs for more info on this (and credits)

			if (eventType == EventType.AfterPrintArtifactFullDesc && DobjArtifact.Uid == 1)
			{
				gOut.Print("Gazing at the mural, you can't help but feel a sense of awe:");

				gOut.Print("{0}", gEngine.LineSep);

				gOut.Write("{0}Press any key to continue: ", Environment.NewLine);

				gEngine.Buf.Clear();

				var rc = gEngine.In.ReadField(gEngine.Buf, gEngine.BufSize02, null, ' ', '\0', true, null, gEngine.ModifyCharToNull, null, gEngine.IsCharAny);

				Debug.Assert(gEngine.IsSuccess(rc));

				gOut.Print("{0}", gEngine.LineSep);

				gOut.Print("{0}", Encoding.UTF8.GetString(Convert.FromBase64String(gEngine.MuralData)));
			}
		}
	}
}
