// using System;
// using Client.UI.Meta.Common.Commands;
// using Common.Domain.Meta;
// using Common.GameKind;
// using Sodium.Frp;
// using UniMvvm;
//
//
//
// namespace Client.UI.Meta.MainMenu.ViewModels
// {
// 	public class ContinueLastGameVM
// 	{
// 		public LoadGameCommand ContinueLastGameCommand { get; }
// 		// public ButtonVM ContinueLastGameButton { get; }
//
// 		public Cell<BLastGameVM?> LastGameVM { get; }
//
//
//
// 		private IGameKindRepository _gameKindRepository;
//
//
//
// 		public ContinueLastGameVM(
// 			IPromise<SavedGameSnapshotBrief?> pLastGameSnapshot,
// 			IGameKindRepository gameKindRepository,
// 			IGameKindMainController controller)
// 		{
// 			_gameKindRepository = gameKindRepository;
//
// 			// Visible = pLastGameSnapshot.Then.Map(_ => _ != null).Hold(true);
//
// 			ContinueLastGameCommand = new LoadGameCommand(pLastGameSnapshot.Then.Hold(null), controller);
// 			// ContinueLastGameButton = new ButtonVM(ContinueLastGameCommand);
//
// 			// LastGameBlockVM = new LastGameBlockVM(pLastGameSnapshot, sThrobberVisible, gameTypeRepository);
//
// 			LastGameVM = pLastGameSnapshot.Then.Map(LastGameVM_From_LastGameSnapshot).Hold(null);
// 		}
//
//
//
// 		private BLastGameVM? LastGameVM_From_LastGameSnapshot(SavedGameSnapshotBrief? snapshot)
// 		{
// 			if (snapshot == null)
// 				return null;
//
// 			IGameKind? gameType = _gameKindRepository.Get(snapshot.Game.TypeId);
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
