// using System.Linq;
// using UniRx;
// using UnityEngine.UIElements;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class LoadGameMenu_GamesView
// 	{
// 		private readonly ListView _listView;
//
// 		private readonly SingleSelectionListVM<SavedGameMainInfoVM> _vm;
//
//
//
// 		public LoadGameMenu_GamesView(
// 			ListView listView,
// 			VisualTreeAsset listItemAsset,
// 			SingleSelectionListVM<SavedGameMainInfoVM> vm)
// 		{
// 			_listView = listView;
// 			_vm = vm;
//
//
// 			listView.makeItem = listItemAsset.Instantiate;
//
// 			listView.bindItem = (element, i) => BindItem(element, _vm.List.Value[i]);
//
// 			listView.onSelectedIndicesChange += indices => {
// 				// "indices" should not be empty, but can if widget is not properly implemented
//
// 				int newIndex = indices.DefaultIfEmpty(-1).First();
//
// 				if (newIndex == _vm.SelectedIndex.Value)
// 					return;
//
// 				_vm.SelectedIndex.OnNext(newIndex);
// 			};
//
//
// 			_vm.ThisData.Subscribe(data => {
// 				_listView.itemsSource = data.list.ToList();
// 				_listView.SetSelection(data.selectedIndex);
// 				_listView.RefreshItems();
// 			});
// 		}
//
//
//
// 		private void BindItem(VisualElement element, SavedGameMainInfoVM game)
// 		{
// 			element.Q<Label>("name").text = game.Name;
// 			element.Q<Label>("nation").text = game.Nation;
// 			element.Q<Label>("leader").text = game.Leader;
// 		}
// 	}
// }
