// using System;
// using System.Collections.Generic;
// using Assets.Scripts.ServerCore.Domain.GameSpecification;
// using Common.Application.SavedGame.Implementation;
// using Common.Application.SavedGame.Implementation.Models;
// using Common.Domain.Game;
// using Common.Domain.Game.World;
// using Common.Domain.Meta.GameSpecification;
// using Common.Domain.Meta.Persistence;
// using Common.Util;
// using FreeCiv.Common.Domain.Game;
// using FreeCiv.Common.Domain.Meta;
//
//
//
// namespace ServerStub.Application.Internal
// {
// 	class SavedGameRepository_Stub : ISavedGameReadOnlyRepository
// 	{
// 		private readonly List<SavedGameBrief> _games = new();
//
//
//
// 		public SavedGameRepository_Stub()
// 		{
// 			var terrain = new TerrainAbstractSpecification {
// 				Topology = new MaybeRandom<ITerrainShape>(new CylinderTerrainShape()),
// 				TotalSize = new PlaneProjectedTotalTerrainSizeAbstractSpecification {
// 					SizeClass = new TerrainSizeClass {
// 						Name = "urn:FreeCiv:TerrainSize:Large",
// 						Area = new Range<uint>(4000, 5000)
// 					},
// 					Area = new ValueOrRange<uint>(4500),
// 					Size = new TerrainPlaneProjectionDimensions { Width = 100, Height = 45 }
// 				}
// 			};
//
// 			var nation = new NationSpecification { Name = "France" };
//
// 			var humanGameSideAbstract = new FreeCiv.Common.Domain.Meta.GameSideAbstractSpecification {
// 				Nation = MaybeRandom.Of(nation)
// 			};
// 			var sides = new GameSidesAbstractSpecification {
// 				GameSides = new[] { humanGameSideAbstract },
// 				PlayerCount = new ValueOrRange<uint>(8),
// 				FillerGameSide = new GameSideAbstractSpecification {
// 					Nation = MaybeRandom<NationSpecification>.Random
// 				}
// 			};
//
// 			var world = new WorldAbstractSpecification {
// 				Ruleset = new RulesetSpecification { Name = "civ2civ3" },
// 				Terrain = terrain,
// 				GameSides = sides
// 			};
//
// 			var participants = new ParticipantsAbstractSpecification {
// 				Participants = new[] {
// 					new ThisUserParticipantAbstractSpecification()
// 				},
// 				FillerAi = new AiAbstractSpecification {
// 					Strength = MaybeRandom.Of(new AiStrength {
// 						Name = "urn:4XForge:FreeCiv:Ai:Strength:Normal"
// 					})
// 				}
// 			};
//
// 			var gameSpec = new GameAbstractSpecification {
// 				Name = "Game 01",
// 				World = world,
// 				Participants = participants
// 			};
//
//
//
// 			var humanGameSide = new PolitySpecification {
// 				Kind = new FreeCiv.Common.Domain.Game.PolityKindSpecification {
// 					Nation = nation
// 				},
// 				Name = new QualifiedTypeName_GameSideNameModification(
// 					new Number_PolityNameQualifier(1))
// 			};
//
//
//
// 			var game = new SavedGameBrief {
// 				KindId = new Guid("741690B9-A515-4D96-89CF-B1FB1A353351"),
// 				KindName = "urn:4XForge:GameType:FreeCiv",
// 				Name = "Game 01",
// 				RulesetName = "civ2civ3",
// 				// GameSideNameQualifierFormatter = new NumeroSign_GameSideNameQualifierFormatter(),
// 				// GameSideQualifiedNameFormatter = new Postfix_GameSideQualifiedNameFormatter()
// 			};
//
//
//
// 			var snapshot1 = new SavedGameSnapshotBrief {
// 				Game = game,
// 				WorldTimeProgress = new TurnBasedWorldTimeProgress {
// 					WorldDateTime = new WorldDateTime { Year = new HistoricYear(50) },
// 					Turn = 50
// 				},
// 				ThisPlayerPolity = humanGameSide,
// 				Timestamp = new DateTime(2022, 5, 10, 14, 0, 0)
// 			};
// 			var snapshot2 = new SavedGameSnapshotBrief {
// 				Game = game,
// 				WorldTimeProgress = new TurnBasedWorldTimeProgress {
// 					WorldDateTime = new WorldDateTime { Year = new HistoricYear(500) },
// 					Turn = 100
// 				},
// 				ThisPlayerPolity = humanGameSide,
// 				Timestamp = new DateTime(2022, 5, 10, 16, 0, 0),
// 				PreviousSnapshot = snapshot1
// 			};
// 			var snapshot3 = new SavedGameSnapshotBrief {
// 				Game = game,
// 				WorldTimeProgress = new TurnBasedWorldTimeProgress {
// 					WorldDateTime = new WorldDateTime { Year = new HistoricYear(1000) },
// 					Turn = 200
// 				},
// 				ThisPlayerPolity = humanGameSide,
// 				Comment = "Before war with Italy",
// 				Timestamp = new DateTime(2022, 5, 11, 18, 0, 0),
// 				PreviousSnapshot = snapshot2
// 			};
// 			var snapshot4 = new SavedGameSnapshotBrief {
// 				Game = game,
// 				WorldTimeProgress = new TurnBasedWorldTimeProgress {
// 					WorldDateTime = new WorldDateTime { Year = new HistoricYear(1490) },
// 					Turn = 299
// 				},
// 				ThisPlayerPolity = humanGameSide,
// 				Timestamp = new DateTime(2022, 5, 12, 21, 59, 0),
// 				AutoSaved = true,
// 				PreviousSnapshot = snapshot3
// 			};
// 			var snapshot5 = new SavedGameSnapshotBrief {
// 				Game = game,
// 				WorldTimeProgress = new TurnBasedWorldTimeProgress {
// 					WorldDateTime = new WorldDateTime { Year = new HistoricYear(1500) },
// 					Turn = 300
// 				},
// 				ThisPlayerPolity = humanGameSide,
// 				Timestamp = new DateTime(2022, 5, 12, 22, 0, 0),
// 				PreviousSnapshot = snapshot4
// 			};
//
// 			var snapshots = new List<SavedGameSnapshotBrief> {
// 				snapshot5,
// 				snapshot4,
// 				snapshot3,
// 				snapshot2,
// 				snapshot1
// 			};
//
// 			game.Snapshots = snapshots;
//
// 			_games.Add(game);
//
//
//
// 			// game = new SavedGame { Name = "FFA against all", Nation = "Britain", Leader = "Elizabeth" };
// 			// snapshots = new List<SavedGameSnapshot> {
// 			// 	new() { Game = game, Turn = 10, Year = new Year(-1000), Timestamp = new DateTime(2022, 5, 9, 22, 0, 0) },
// 			// };
// 			// game.Snapshots = snapshots;
// 			// _games.Add(game);
// 		}
//
//
//
// 		public IReadOnlyList<SavedGameBrief> GetAll()
// 		{
// 			return _games;
// 		}
// 	}
// }
