using System;
using Common.Domain.Meta;
using Common.Domain.Meta.GameSpecification;



namespace Common.Domain.Game
{
	public interface IGameInstance
	{
		Guid Id { get; }

		IGameKind GameKind { get; }

		IGameHistory History { get; }


		GamePhase Phase { get; }

		IGameAbstractSpecification AbstractSpecification { get; }



		ILobby GetLobby();

	}
}
