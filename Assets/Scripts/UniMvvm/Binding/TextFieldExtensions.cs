using Sodium.Frp;
using UnityEngine.UIElements;



namespace UniMvvm
{
	public static class TextFieldExtensions
	{
		public static void BindViewModel<T>(this TextField control, IEditableField<T> viewModel) where T : struct
		{
			viewModel.Value.ListenWeak(v => control.value = v is not null ? v.ToString() : string.Empty);


			control.RegisterValueChangedCallback(evt => {
				viewModel.Save(evt.newValue);
			});
		}




	}
}
