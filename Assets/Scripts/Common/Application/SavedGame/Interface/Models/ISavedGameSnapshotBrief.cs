using System;
using Common.Domain.Game;
using Common.Domain.Game.World;
using Common.Domain.Meta.GameSpecification;
using Common.Domain.Meta.History.Interface;



namespace Common.Application.SavedGame.Interface.Models
{
	public interface ISavedGameSnapshotBrief
	{
		// Identity

		ISavedGameBrief Game { get; }

		IGameHistoryMoment? HistoryMoment { get; }


		// Game state

		GamePhase GamePhase { get; }

		IWorldTimeProgress? WorldTimeProgress { get; }

		// GameSnapshotMap? Map { get; }


		IPolitySpecification ThisPlayerPolity { get; }

		// bool ThisPlayerPolityChanged { get; }


		// Meta-data

		string? Comment { get; }

		DateTime Timestamp { get; }

		// bool AutoSaved { get; }
	}
}
