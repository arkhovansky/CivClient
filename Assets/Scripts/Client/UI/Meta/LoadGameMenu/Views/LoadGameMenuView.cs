// using UniMvvm;
// using UnityEngine;
// using UnityEngine.UIElements;
//
//
//
// namespace UI
// {
// 	public class LoadGameMenuView
// 	{
// 		private LoadGameMenu_GamesView _gamesView;
// 		private LoadGameMenu_SnapshotsView _snapshotsView;
// 		private LoadGameMenu_DetailsView _detailsView;
//
//
//
// 		public LoadGameMenuView(VisualElement rootEl, LoadGameMenuVM viewModel)
// 		{
// 			var asset = Resources.Load<VisualTreeAsset>("LoadGameMenu");
//
// 			rootEl.Clear();
// 			asset.CloneTree(rootEl);
//
//
//
// 			var gameAsset = Resources.Load<VisualTreeAsset>("LoadGameMenu_Game");
//
// 			_gamesView = new LoadGameMenu_GamesView(
// 				rootEl.Q<ListView>("gamesList"),
// 				gameAsset,
// 				viewModel.GameListVM);
//
//
// 			var snapshotAsset = Resources.Load<VisualTreeAsset>("LoadGameMenu_Snapshot");
//
// 			_snapshotsView = new LoadGameMenu_SnapshotsView(
// 				rootEl.Q<ListView>("snapshotsList"),
// 				snapshotAsset,
// 				viewModel.SnapshotListVM);
//
//
// 			_detailsView = new LoadGameMenu_DetailsView(
// 				rootEl.Q<VisualElement>("details"),
// 				viewModel.DetailsVM);
//
//
// 			rootEl.Q<Button>("loadButton").BindCommand(viewModel.LoadGameCommand);
// 		}
// 	}
// }
