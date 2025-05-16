using System.Collections.Generic;
using Common.Domain.Game.World;
using Common.Domain.Meta.GameSpecification;



namespace Common.Domain.Game
{
	/// <summary>
	/// Game phase.
	/// </summary>
	/// <remarks>Values are ordered according to lifecycle.</remarks>
	public enum GamePhase
	{
		Setup,
		Ready,
		Started,
		Finished
	}



	public interface IGameState
	{
		GamePhase Phase { get; }

		IGameAbstractSpecification AbstractSpecification { get; }
	}

	public interface IReadyGameState : IGameState
	{
		IWorld World { get; }

		IReadOnlyDictionary<IPolity, IParticipant> Players { get; }
	}

	public interface IFinishedGameState : IReadyGameState
	{
		IGameResult Result { get; }
	}
}
