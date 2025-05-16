// using System;
// using System.Linq;
// using Common.Application.SavedGame.Interface.Models;
// using Common.Domain.Game;
// using Common.Domain.Game.World;
// using Common.Domain.Meta.GameSpecification;
// using Common.Domain.Meta.History.Interface;
//
//
//
// namespace Common.Application.SavedGame.Implementation.Models
// {
// 	public class SavedGameSnapshotBrief : ISavedGameSnapshotBrief
// 	{
// 		// Identity
//
// 		public ISavedGameBrief Game { get; }
//
// 		public IGameHistoryMoment? HistoryMoment { get; }
//
//
// 		// Game state
//
// 		public GamePhase GamePhase { get; }
//
// 		public IWorldTimeProgress? WorldTimeProgress { get; }
//
// 		// public GameSnapshotMap? Map { get; }
//
//
// 		public IPolitySpecification ThisPlayerPolity { get; }
//
// 		// public bool ThisPlayerPolityChanged { get; }
//
//
// 		// Meta-data
//
// 		public string? Comment { get; }
//
// 		public DateTime Timestamp { get; }
//
// 		// public bool AutoSaved { get; }
//
//
//
// 		public SavedGameSnapshotBrief(ISavedGameBrief game, IGameSnapshot snapshot, IUserIdentity? thisUserIdentity)
// 		{
// 			Game = game;
// 			HistoryMoment = snapshot.HistoryMoment;
//
// 			GamePhase = snapshot.GameState.Phase;
//
// 			if ((int)GamePhase >= (int)GamePhase.Started)
// 				WorldTimeProgress = ((IReadyGameState)snapshot.GameState).World.TimeProgress;
//
// 			ThisPlayerPolity = snapshot.ThisPlayerPolity;
//
// 			Comment = snapshot.Comment;
// 			Timestamp = snapshot.Timestamp;
// 		}
//
//
// 		protected IPolitySpecification GetThisPlayerPolity(IGameState state, IUserIdentity? thisUserIdentity)
// 		{
// 			if (state.Phase == GamePhase.Setup) {
// 				var assignment = state.AbstractSpecification.Participants.ExplicitAssignments.Where(it =>
// 					it.Participant is HumanParticipantAbstractSpecification human && Equals(human.Identity, thisUserIdentity)).
//
// 			}
// 		}
// 	}
// }
