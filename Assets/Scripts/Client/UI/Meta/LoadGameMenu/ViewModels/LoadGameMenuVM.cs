// using System;
// // using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using Application;
// using Application.Implementation;
// using Application.Service.Interface;
// using Domain.SavedGame;
// using UI.Common.Commands;
// using UniRx;
//
//
//
// namespace UI
// {
// 	public class LoadGameMenuVM
// 	{
// 		public SingleSelectionListVM<SavedGameMainInfoVM> GameListVM { get; }
// 		public SingleSelectionListVM<SavedGameSnapshotMainInfoVM> SnapshotListVM { get; }
// 		public BehaviorSubject<SavedGameAndSnapshotDetailsVM> DetailsVM { get; }
//
// 		public LoadGameCommand LoadGameCommand { get; }
//
//
//
// 		private IReadOnlyList<SavedGame> _games;
// 		private SavedGame _selectedGame;
// 		// private IObservable<SavedGameSnapshot> _selectedSnapshot;
//
//
//
// 		public LoadGameMenuVM(ISavedGameReadOnlyRepository savedGameRepository, IGameKindMainController controller)
// 		{
// 			_games = GetSavedGamesModel(savedGameRepository);
//
//
// 			var gameList = _games.Select(SavedGameMainInfoVM.FromSavedGame).ToList();
// 			GameListVM = new SingleSelectionListVM<SavedGameMainInfoVM>(
// 				new SingleSelectionListVM<SavedGameMainInfoVM>.Data(gameList, GetDefaultIndex(gameList)));
//
// 			var selectedGame = GameListVM.SelectedIndex
// 				.Select(i => i != -1 ? _games.ElementAt(i) : null)
// 				.DistinctUntilChanged()
// 				.Do(game => _selectedGame = game);
//
//
// 			var snapshotListData = selectedGame.Select(game => {
// 				var snapshotList =
// 					game.Snapshots.Select(SavedGameSnapshotMainInfoVM.FromSavedGameSnapshot).ToList();
// 				int index = GetDefaultIndex(snapshotList);
//
// 				return new SingleSelectionListVM<SavedGameSnapshotMainInfoVM>.Data(snapshotList, index);
// 			});
//
// 			SnapshotListVM = new SingleSelectionListVM<SavedGameSnapshotMainInfoVM>(snapshotListData);
//
// 			var selectedSnapshot = SnapshotListVM.SelectedIndex
// 				.Select(i => i != -1 ? _selectedGame.Snapshots.ElementAt(i) : null)
// 				.DistinctUntilChanged();
//
//
// 			DetailsVM = new BehaviorSubject<SavedGameAndSnapshotDetailsVM>(null);
//
// 			selectedSnapshot
// 				.Select(SavedGameAndSnapshotDetailsVM.FromSavedGameSnapshot)
// 				.Subscribe(DetailsVM);
//
//
// 			LoadGameCommand = new LoadGameCommand(controller);
//
// 			selectedSnapshot
// 				.Where(snapshot => snapshot != null)
// 				.Subscribe(LoadGameCommand.GameSnapshot);
// 		}
//
//
//
// 		/*
// 		 * TODO
// 		 */
// 		private static IReadOnlyList<SavedGame> GetSavedGamesModel(ISavedGameReadOnlyRepository repository)
// 		{
// 			return repository.GetAll();
// 		}
//
//
//
// 		private static int GetDefaultIndex<T>(IReadOnlyCollection<T> list)
// 		{
// 			return list.Count > 0 ? 0 : -1;
// 		}
// 	}
// }
