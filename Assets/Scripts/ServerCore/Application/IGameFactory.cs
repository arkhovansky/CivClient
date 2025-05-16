using Common.Domain.Game;
using Common.Domain.Meta.GameSpecification;



namespace ServerCore.Application
{
	public interface IGameFactory
	{
		IGameInstance CreateGame();

		IGameAbstractSpecification CreateGameAbstractSpecification();

		IWorldAbstractSpecification CreateWorldAbstractSpecification();

		ITerrainAbstractSpecification CreateTerrainAbstractSpecification();

		IPolitiesAbstractSpecification CreateGameSidesAbstractSpecification();

		IParticipantsAbstractSpecification CreateParticipantsAbstractSpecification();
	}
}
