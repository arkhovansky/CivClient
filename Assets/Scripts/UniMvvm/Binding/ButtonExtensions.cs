using Sodium.Frp;
using UnityEngine.UIElements;



namespace UniMvvm
{
	public static class ButtonExtensions
	{
		public static void BindCommand(this Button button, ICommand command)
		{
			command.Enabled.ListenWeak(button.SetEnabled);

			button.RegisterCallback<ClickEvent>(_ => command.Execute());
		}



		// public static void BindViewModel(this Button button, ButtonVM vm)
		// {
		// 	((VisualElement)button).BindViewModel(vm);
		//
		// 	button.RegisterCallback<ClickEvent>(_ => vm.OnPress());
		// }
	}
}
