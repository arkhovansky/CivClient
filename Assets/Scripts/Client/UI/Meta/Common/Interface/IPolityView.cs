using UnityEngine.UIElements;



namespace Client.UI.Meta.Common.Interface
{
	public interface IPolityView
	{

	}



	public interface IPolityViewFactory
	{
		IPolityView Create(VisualElement element, IPolityVM vm);
	}
}
