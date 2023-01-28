
// ArtifactHelper.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System;
using System.Diagnostics;
using System.Text;
using Eamon.Framework.Helpers;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using Eamon.Game.Extensions;
using Eamon.Game.Utilities;
using SampleAdventure.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Helpers
{
	// This game demonstrates the first-class Artifact property MaterialType.  There are examples of new anonymous
	// properties added to various classes throughout the Eamon CS codebase, but they are for in-game processing.
	// There is no need to expose stuff like counters, which are initialized to 0 and then used to EamonDD.  But
	// MaterialType is different; it is desirable to integrate it fully into EamonDD since it stores critical data
	// about the nature of an Artifact.  You can see the behavior for yourself if you load this SampleAdventure in
	// EamonDD and process some Artifacts!
	//
	// By using the FieldName attribute (see Artifact.cs), the MaterialType property is integrated into the Eamon CS
	// Helper subsystem.  Helpers are used by Eamon CS - and especially EamonDD - to facilitate Record processing.
	// If you inspect the datafiles for different games you will see that EamonDD is capable of processing base-
	// level Record classes (like Eamon.Game.Room), and any subclass thereof.  The editor is said to be
	// polymorphic.  But it is also reflective:  EamonDD synthesizes method names using hardcoded prefixes
	// combined with various FieldName-decorated property names.  It then invokes these methods dynamically in
	// the order specified by the FieldName attribute's sort order number.
	//
	// In many games, you may see Helper subclasses that only contain methods named with the pattern
	// Validate[PropertyName].  These methods allow the game engine to validate new anonymous properties, typically
	// added to GameState.  Some additional method prefixes must be used to create a first-class property.  If you
	// wish to create one of your own the best thing to do is choose an existing property that closely resembles
	// your new property, then use its methods as a starting point.  If you need assistance with this task, please
	// let me know.  As for MaterialType, the minimum number of methods required for full EamonDD integration is
	// demonstrated (and described) below.

	[ClassMappings]
	public class ArtifactHelper : Eamon.Game.Helpers.ArtifactHelper, IArtifactHelper
	{
		// Override the Record property of the parent class to gain access to MaterialType property.

		public virtual new Framework.IArtifact Record
		{
			get
			{
				return (Framework.IArtifact)base.Record;
			}

			set
			{
				if (base.Record != value)
				{
					base.Record = value;
				}
			}
		}

		// Methods of the pattern GetPrintedName[PropertyName] print the property name during Record processing in EamonDD.

		public virtual string GetPrintedNameMaterialType()
		{
			return "Material Type";
		}

		// Methods of the pattern Validate[PropertyName] perform Record validation in various Eamon CS programs.

		public virtual bool ValidateMaterialType()
		{
			return Enum.IsDefined(typeof(MaterialType), Record.MaterialType);
		}

		// Methods of the pattern PrintDesc[PropertyName] print the brief and/or full descriptions for the property during Record processing in EamonDD.

		public virtual void PrintDescMaterialType()
		{
			var fullDesc = "Enter the material type of the Artifact.";

			var briefDesc = new StringBuilder(gEngine.BufSize);

			var matTypeValues = EnumUtil.GetValues<MaterialType>();

			for (var j = 0; j < matTypeValues.Count; j++)
			{
				briefDesc.AppendFormat("{0}{1}={2}", j != 0 ? "; " : "", (long)matTypeValues[j], matTypeValues[j].ToString());
			}

			gEngine.AppendFieldDesc(FieldDesc, Buf01, fullDesc, briefDesc.ToString());
		}

		// Methods of the pattern List[PropertyName] list the property and its value during Record processing in EamonDD.

		public virtual void ListMaterialType()
		{
			if (FullDetail)
			{
				var listNum = NumberFields ? ListNum++ : 0;

				if (LookupMsg)
				{
					gOut.Write("{0}{1}{2}",
						Environment.NewLine,
						gEngine.BuildPrompt(27, '.', listNum, GetPrintedName("MaterialType"), null),
						gEngine.BuildValue(51, ' ', 8, (long)Record.MaterialType, null, Record.MaterialType.ToString()));
				}
				else
				{
					gOut.Write("{0}{1}{2}", Environment.NewLine, gEngine.BuildPrompt(27, '.', listNum, GetPrintedName("MaterialType"), null), (long)Record.MaterialType);
				}
			}
		}

		// Methods of the pattern Input[PropertyName] allow user input of a validated value for the property during Record processing in EamonDD.

		public virtual void InputMaterialType()
		{
			var fieldDesc = FieldDesc;

			var materialType = Record.MaterialType;

			while (true)
			{
				Buf.SetFormat(EditRec ? "{0}" : "", (long)materialType);

				PrintFieldDesc("MaterialType", EditRec, EditField, fieldDesc);

				gOut.Write("{0}{1}", Environment.NewLine, gEngine.BuildPrompt(27, '\0', 0, GetPrintedName("MaterialType"), "0"));

				var rc = gEngine.In.ReadField(Buf, gEngine.BufSize01, null, '_', '\0', true, "1", null, gEngine.IsCharDigit, null);

				Debug.Assert(gEngine.IsSuccess(rc));

				Record.MaterialType = (MaterialType)Convert.ToInt64(Buf.Trim().ToString());

				if (ValidateField("MaterialType"))
				{
					break;
				}

				fieldDesc = FieldDesc.Brief;
			}

			gOut.Print("{0}", gEngine.LineSep);
		}
	}
}
