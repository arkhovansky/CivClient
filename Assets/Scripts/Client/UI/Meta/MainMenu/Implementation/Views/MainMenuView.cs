using Client.UI.Meta.MainMenu.Interface;
using Sodium.Frp;
using UniMvvm;
using UnityEngine;
using UnityEngine.UIElements;



namespace Client.UI.Meta.MainMenu.Implementation.Views
{
	public class MainMenuView : IMainMenuView
	{
		private Cell<bool> continueLastGameBlockDisplay;
		private Cell<bool> lastGameDisplay;



		public MainMenuView(VisualElement element, IMainMenuVM viewModel)
		{
			var asset = Resources.Load<VisualTreeAsset>("MainMenu");

			element.Clear();
			asset.CloneTree(element);


			ViewMapper.Map(element, viewModel);

			continueLastGameBlockDisplay = viewModel.RequestInProgress.Lift(viewModel.LastGameVM,
				(requestPending, game) => requestPending || game != null);
			lastGameDisplay = viewModel.LastGameVM.Map(_ => _ != null);

			// ViewMapper.MapDisplay(element.Q<VisualElement>("continueLastGameBlock"), continueLastGameBlockDisplay);
			// ViewMapper.MapDisplay(element.Q<VisualElement>("lastGame"), lastGameDisplay);
		}
	}
}
