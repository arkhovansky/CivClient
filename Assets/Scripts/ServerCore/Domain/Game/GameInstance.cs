using System;
using Common.Domain.Game;
using Common.Domain.Meta;
using Common.Domain.Meta.GameSpecification;



namespace ServerCore.Domain.Game
{
	public class GameInstance : IGameInstance
	{
		public Guid Id { get; }

		public IGameKind GameKind { get; }

		public IGameHistory History { get; }

		public GamePhase Phase { get; }

		public IGameAbstractSpecification AbstractSpecification { get; }



		protected internal GameInstance(IGameAbstractSpecification abstractSpecification)
		{
			Phase = GamePhase.Setup;
			AbstractSpecification = abstractSpecification;
		}


		public ILobby GetLobby()
		{
			throw new System.NotImplementedException();
		}
	}
}
