// using System;
// using Common.Domain.Meta;
// using Common.GameType;
// using Sodium.Frp;
// using UniMvvm;
//
//
//
// namespace Client.UI.Meta.MainMenu.ViewModels
// {
// 	public class LastGameBlockVM : VisualElementVM
// 	{
// 		public Cell<BLastGameVM?> LastGameVM { get; }
//
//
//
// 		private IGameTypeRepository _gameTypeRepository;
//
//
//
// 		public LastGameBlockVM(
// 			IPromise<SavedGameSnapshotBrief?> pLastGameSnapshot,
// 			Stream<bool> sThrobberVisible,
// 			IGameTypeRepository gameTypeRepository)
// 		{
// 			ThrobberVisible = sThrobberVisible.Hold(false);
//
// 			LastGameVM = pLastGameSnapshot.Then.Map(LastGameVM_From_LastGameSnapshot).Hold(null);
//
// 			_gameTypeRepository = gameTypeRepository;
// 		}
//
//
//
// 		private BLastGameVM? LastGameVM_From_LastGameSnapshot(SavedGameSnapshotBrief? snapshot)
// 		{
// 			if (snapshot == null)
// 				return null;
//
// 			IGameType? gameType = _gameTypeRepository.Get(snapshot.Game.TypeId);
// 			if (gameType == null)
// 				throw new Exception(); //TODO
//
// 			Func<SavedGameSnapshotBrief, BLastGameVM> fromLastGameSnapshot =
// 				gameType.Assembly.GetConversionFactoryMethodDelegate<SavedGameSnapshotBrief, BLastGameVM>(
// 					"LastGameVM", "FromLastGameSnapshot");
//
// 			return fromLastGameSnapshot(snapshot);
// 		}
// 	}
// }
