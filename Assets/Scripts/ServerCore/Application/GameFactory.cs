// using Common.Domain.Game;
// using Common.Domain.Meta.GameSpecification;
// using ServerCore.Domain.Game;
// using ServerCore.Domain.GameSpecification;
//
//
//
// namespace ServerCore.Application
// {
// 	public abstract class GameFactory : IGameFactory
// 	{
// 		public virtual IGameInstance CreateGame()
// 		{
// 			return new GameInstance(CreateGameAbstractSpecification());
// 		}
//
//
// 		public virtual IGameAbstractSpecification CreateGameAbstractSpecification()
// 		{
// 			return new GameAbstractSpecification(CreateWorldAbstractSpecification(),
// 			                                     CreateParticipantsAbstractSpecification());
// 		}
//
//
// 		public virtual IWorldAbstractSpecification CreateWorldAbstractSpecification()
// 		{
// 			return new WorldAbstractSpecification(null,
// 			                                      CreateTerrainAbstractSpecification(),
// 			                                      CreateGameSidesAbstractSpecification());
// 		}
//
//
// 		public abstract ITerrainAbstractSpecification CreateTerrainAbstractSpecification();
//
// 		public abstract IPolitiesAbstractSpecification CreateGameSidesAbstractSpecification();
//
// 		public abstract IParticipantsAbstractSpecification CreateParticipantsAbstractSpecification();
// 	}
// }
