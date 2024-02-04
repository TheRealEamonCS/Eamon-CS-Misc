
// Globals.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using Eamon.Framework.DataStorage.Generic;
using Eamon.Framework.Portability;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Parsing;

namespace SampleAdventure.Game.Plugin
{
#pragma warning disable IDE1006 // Naming Styles

	public static class Globals
	{
		public static Framework.Plugin.IEngine gEngine
		{
			get
			{
				return (Framework.Plugin.IEngine)EamonRT.Game.Plugin.Globals.gEngine;
			}
			set
			{
				EamonRT.Game.Plugin.Globals.gEngine = value;
			}
		}

		public static ITextWriter gOut
		{
			get
			{
				return EamonRT.Game.Plugin.Globals.gOut;
			}
		}

		public static IRecordDb<Eamon.Framework.IRoom> gRDB
		{
			get
			{
				return (IRecordDb<Eamon.Framework.IRoom>)EamonRT.Game.Plugin.Globals.gRDB;
			}
		}

		public static IRecordDb<Eamon.Framework.IArtifact> gADB
		{
			get
			{
				return (IRecordDb<Eamon.Framework.IArtifact>)EamonRT.Game.Plugin.Globals.gADB;
			}
		}

		public static IRecordDb<Eamon.Framework.IEffect> gEDB
		{
			get
			{
				return (IRecordDb<Eamon.Framework.IEffect>)EamonRT.Game.Plugin.Globals.gEDB;
			}
		}

		public static IRecordDb<Eamon.Framework.IMonster> gMDB
		{
			get
			{
				return (IRecordDb<Eamon.Framework.IMonster>)EamonRT.Game.Plugin.Globals.gMDB;
			}
		}

		public static Eamon.Framework.IGameState gGameState
		{
			get
			{
				return (Eamon.Framework.IGameState)EamonRT.Game.Plugin.Globals.gGameState;
			}
		}

		public static Eamon.Framework.ICharacter gCharacter
		{
			get
			{
				return (Eamon.Framework.ICharacter)EamonRT.Game.Plugin.Globals.gCharacter;
			}
		}

		public static Eamon.Framework.IMonster gCharMonster
		{
			get
			{
				return (Eamon.Framework.IMonster)EamonRT.Game.Plugin.Globals.gCharMonster;
			}
		}

		// This global "macro" exposes the corresponding property of a Command or CommandParser object but casts
		// it to a game-specific interface so that new properties and methods defined and implemented by the game
		// are easily accessible.  There may be similar macros for ActorRoom, IobjArtifact, DobjMonster, IobjMonster,
		// etc., but this game only needs gDobjArtifact.  These macros are only required when game-specific properties
		// or methods exist in corresponding subclassed interfaces.

		public static Framework.IArtifact gDobjArtifact(object obj)
		{
			if (obj is ICommandParser commandParser)
			{
				return (Framework.IArtifact)commandParser?.DobjArtifact;
			}
			else if (obj is ICommand command)
			{
				return (Framework.IArtifact)command?.DobjArtifact;
			}
			else
			{
				return null;
			}
		}
	}

#pragma warning restore IDE1006 // Naming Styles
}
