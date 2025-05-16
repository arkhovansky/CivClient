// using UI.MainMenu.ViewModels;
// using UniMvvm;
// using UnityEngine.UIElements;
//
//
//
// namespace UI.MainMenu.Views
// {
// 	public class ContinueLastGameView
// 	{
// 		public ContinueLastGameView(VisualElement element, ContinueLastGameVM? vm)
// 		{
// 			if (vm != null) {
// 				ViewMapper.Map(element, vm.LastGameVM);
// 				// element.Q<Label>("gameName").text = vm.LastSavedGameSnapshotVM.GameName;
// 				// element.Q<Label>("nation").text = vm.LastSavedGameSnapshotVM.Nation;
// 				// element.Q<Label>("leader").text = vm.LastSavedGameSnapshotVM.Leader;
// 				// element.Q<Label>("turn").text = vm.LastSavedGameSnapshotVM.Turn;
// 				// element.Q<Label>("year").text = vm.LastSavedGameSnapshotVM.Year;
//
// 				element.style.display = DisplayStyle.Flex;
//
// 				element.Q<Button>("continueLastGameButton").BindCommand(vm.ContinueLastGameCommand);
// 			}
// 			else {
// 				element.style.display = DisplayStyle.None;
// 			}
// 		}
// 	}
// }
