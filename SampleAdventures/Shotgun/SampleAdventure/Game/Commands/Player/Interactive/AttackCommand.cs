
// AttackCommand.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Diagnostics;
using Eamon.Framework.Primitive.Enums;
using Eamon.Game.Attributes;
using EamonRT.Framework.Commands;
using EamonRT.Framework.Primitive.Enums;
using static SampleAdventure.Game.Plugin.PluginContext;

namespace SampleAdventure.Game.Commands
{
	[ClassMappings]
	public class AttackCommand : EamonRT.Game.Commands.AttackCommand, IAttackCommand
	{
		public override void ProcessEvents(EventType eventType)
		{
			base.ProcessEvents(eventType);

			// ATTACK using shotgun

			if (eventType == EventType.AfterAttackNonEnemyCheck && ActorMonster.Weapon == 2)
			{
				var shotgunShellsArtifact = gADB[1];

				Debug.Assert(shotgunShellsArtifact != null);

				if (shotgunShellsArtifact.IsCarriedByContainerUid(2))
				{
					gOut.Print("You chamber a shell, take aim and squeeze the trigger... KA-BLAM!!!");

					// One less shotgun shell remaining

					shotgunShellsArtifact.Field1--;

					shotgunShellsArtifact.Weight--;

					if (shotgunShellsArtifact.Field1 == 1)
					{
						shotgunShellsArtifact.IsPlural = false;

						shotgunShellsArtifact.ArticleType = ArticleType.A;
					}
					else if (shotgunShellsArtifact.Field1 == 0)
					{
						shotgunShellsArtifact.SetInLimbo();
					}
				}
				else 
				{ 
					gOut.Print("You pump the shotgun, take aim and squeeze the trigger... click!");

					GotoCleanup = true;
				}
			}
		}
	}
}
