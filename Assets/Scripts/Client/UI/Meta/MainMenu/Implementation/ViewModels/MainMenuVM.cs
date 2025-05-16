// using Client.UI.Meta.Common.Commands;
// using Client.UI.Meta.MainMenu.Implementation.Commands;
// using Client.UI.Meta.MainMenu.Interface;
// using Common.Application.SavedGame.Interface.Models;
// using Common.Application.SavedGame.Interface.Services;
// using Sodium.Frp;
// using UniMvvm;
//
//
//
// namespace Client.UI.Meta.MainMenu.Implementation.ViewModels
// {
// 	public class MainMenuVM : IMainMenuVM
// 	{
//
// 		public Cell<ILastGameVM?> LastGameVM { get; }
//
// 		public ICommand ContinueLastGameCommand { get; }
//
// 		public ICommand NewGameCommand { get; }
//
// 		public ICommand LoadGameCommand { get; }
//
// 		public Cell<bool> RequestInProgress { get; }
//
//
//
// 		private ILastGameVMFactory _lastGameVMFactory;
//
// 		private IPromise<ISavedGameSnapshotBrief?> _pLastGameSnapshot;
//
//
//
// 		public MainMenuVM(
// 			ISavedGameService savedGameService,
// 			ILastGameVMFactory lastGameVMFactory,
// 			IGameKindMainController controller)
// 		{
// 			_lastGameVMFactory = lastGameVMFactory;
//
// 			_pLastGameSnapshot = savedGameService.GetLastSavedGameSnapshot().ToPromise();
//
// 			RequestInProgress = _pLastGameSnapshot.Then.MapTo(false).Hold(true);
//
// 			// ContinueLastGameVM = new ContinueLastGameVM(_pLastGameSnapshot, gameTypeRepository, controller);
// 			ContinueLastGameCommand = new LoadGameCommand(_pLastGameSnapshot.Then.Hold(null), controller);
// 			LastGameVM = _pLastGameSnapshot.Then.Map(LastGameVM_From_GameSnapshot).Hold(null);
//
// 			NewGameCommand = new GoToNewGameDialogCommand(controller);
//
// 			LoadGameCommand =
// 				new GoToLoadGameDialogCommand(_pLastGameSnapshot.Then.Map(_ => _ != null), controller);
// 		}
//
//
//
// 		private ILastGameVM? LastGameVM_From_GameSnapshot(ISavedGameSnapshotBrief? snapshot)
// 		{
// 			if (snapshot == null)
// 				return null;
//
// 			return _lastGameVMFactory.Create(snapshot);
// 		}
//
//
//
// 		// private ILastGameVM? LastGameVM_From_LastGameSnapshot(SavedGameSnapshotBrief? snapshot)
// 		// {
// 		// 	if (snapshot == null)
// 		// 		return null;
// 		//
// 		// 	IGameKind? gameType = _gameKindRepository.Get(snapshot.Game.KindId);
// 		// 	if (gameType == null)
// 		// 		throw new Exception(); //TODO
// 		//
// 		// 	Func<SavedGameSnapshotBrief, ILastGameVM> fromLastGameSnapshot =
// 		// 		gameType.Assembly.GetImplementingClass<ILastGameVMFactory>(
// 		// 			"LastGameVM", "FromLastGameSnapshot");
// 		//
// 		// 	return fromLastGameSnapshot(snapshot);
// 		// }
// 	}
// }
