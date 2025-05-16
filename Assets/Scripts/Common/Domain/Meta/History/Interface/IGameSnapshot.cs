using System;
using Common.Domain.Game;



namespace Common.Domain.Meta.History.Interface
{
	public interface IGameSnapshot
	{
		// Identity

		IGameInstance GameInstance { get; }

		IGameHistoryMoment? HistoryMoment { get; }


		// Game state

		IGameState GameState { get; }


		// Meta-data

		string? Comment { get; }

		DateTime Timestamp { get; }
	}
}
