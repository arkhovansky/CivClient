// using System;
// using UniRx;
// using UnityEngine.UIElements;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class LoadGameMenu_DetailsView
// 	{
// 		private readonly VisualElement _rootEl;
//
//
//
// 		public LoadGameMenu_DetailsView(
// 			VisualElement rootEl,
// 			IObservable<SavedGameAndSnapshotDetailsVM> vm)
// 		{
// 			_rootEl = rootEl;
//
// 			vm.Subscribe(OnVM);
// 		}
//
//
// 		private void OnVM(SavedGameAndSnapshotDetailsVM vm)
// 		{
// 			// snapshot should not be null, but can if snapshots list is not properly implemented
//
// 			Label name = _rootEl.Q<Label>("gameName");
// 			if (!string.IsNullOrWhiteSpace(vm.Game.Name))
// 				name.text = vm.Game.Name;
// 			else
// 				name.text = "";
//
// 			_rootEl.Q<Label>("year").text = vm.Snapshot.Year;
//
// 			_rootEl.Q<Label>("timestamp").text = vm.Snapshot.Timestamp;
//
// 			_rootEl.Q<VisualElement>("autoSaved").style.display =
// 				vm.Snapshot.AutoSaved ? DisplayStyle.Flex : DisplayStyle.None;
// 		}
// 	}
// }
