
// Artifact.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework;
using Eamon.Game.Attributes;
using SampleAdventure.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game
{
	[ClassMappings(typeof(IArtifact))]
	public class Artifact : Eamon.Game.Artifact, Framework.IArtifact
	{
		// This custom enum property indicates Artifact material type.  The FieldName attribute integrates the new
		// property into the Eamon CS Helper subsystem.  This kind of integration exists in several completed games
		// specifically for GameState record validation, but the Helpers are much more flexible than that.  EamonDD
		// also uses Helpers to implement all Record processing which is the goal here, where the FieldName attribute
		// exposes MaterialType to EamonDD as a first-class property.  The 610 sort order places the property between
		// ArticleType (600) and Value (620) for Artifact processing.  When adding a new first-class property to a
		// Record of any type (including Room, Monster, Artifact, etc.), you must decide how it should display in
		// EamonDD, then find the FieldName attributes of the nearby properties in the appropriate classes.  Pick a
		// new sort order number for your property that places it (based on your preferences) before, between, or
		// after the existing properties.

		[FieldName(610)]
		public virtual MaterialType MaterialType { get; set; }
	}
}
