// using System.Linq;
// using UniRx;
// using UnityEngine.UIElements;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class LoadGameMenu_SnapshotsView
// 	{
// 		private readonly ListView _listView;
//
// 		private readonly SingleSelectionListVM<SavedGameSnapshotMainInfoVM> _vm;
//
//
//
// 		public LoadGameMenu_SnapshotsView(
// 			ListView listView,
// 			VisualTreeAsset listItemAsset,
// 			SingleSelectionListVM<SavedGameSnapshotMainInfoVM> vm)
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
// 		private void BindItem(VisualElement element, SavedGameSnapshotMainInfoVM snapshot)
// 		{
// 			element.Q<Label>("year").text = snapshot.Year;
// 			element.Q<Label>("timestamp").text = snapshot.Timestamp;
//
// 			var comment = element.Q<Label>("comment");
// 			comment.text = snapshot.Comment;
// 			comment.style.display =
// 				!string.IsNullOrWhiteSpace(snapshot.Comment) ? DisplayStyle.Flex : DisplayStyle.None;
//
// 			element.Q<VisualElement>("autoSaved").style.display =
// 				snapshot.AutoSaved ? DisplayStyle.Flex : DisplayStyle.None;
// 		}
// 	}
// }
