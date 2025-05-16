// using System.Linq;
// using System.Threading.Tasks;
// using Common.Application.Meta;
// using Common.Application.SavedGame.Implementation;
// using Common.Application.SavedGame.Implementation.Models;
// using Common.Application.SavedGame.Interface.Services;
// using Common.Domain.Meta.Persistence;
// using ServerStub.Application.Internal;
//
//
//
// namespace ServerStub.Application
// {
// 	public class SavedGameService : ISavedGameService
// 	{
// 		private readonly ISavedGameReadOnlyRepository _savedGameRepository;
//
//
//
// 		public SavedGameService()
// 		{
// 			_savedGameRepository = new SavedGameRepository_Stub();
// 		}
//
//
//
// 		/*
// 		 * TODO
// 		 */
// 		public Task<SavedGameSnapshotBrief?> GetLastSavedGameSnapshot()
// 		{
// 			SavedGameSnapshotBrief? snapshot = _savedGameRepository.GetAll().First()?.Snapshots?.First();
//
// 			return Task.FromResult(snapshot);
// 		}
// 	}
// }
