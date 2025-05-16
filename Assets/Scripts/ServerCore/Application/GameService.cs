// using System;
// using System.Threading.Tasks;
// using Common.Application.Meta;
// using Common.Domain.Game;
// using Common.GameKind;
//
//
//
// namespace ServerCore.Application
// {
// 	public class GameService : IGameService
// 	{
// 		private IGameKindRepository _gameKinds;
//
//
//
// 		public GameService(IGameKindRepository gameKinds)
// 		{
// 			_gameKinds = gameKinds;
// 		}
//
//
//
// 		public async Task<IGameInstance> CreateGame(Guid kindId)
// 		{
// 			IGameKind? kind = _gameKinds.Get(kindId);
//
// 			IGameInstance gameInstance = gameKind.CreateGame();
//
// 			await _games.Add(gameInstance);
// 			//_games.Save();
//
// 			return gameInstance;
// 		}
// 	}
// }
