using Client.HiMod;
using UnityEngine.UIElements;



namespace Client.UniHiMod
{
	public class UITKVisualNode : IVisualNode
	{
		public VisualElement Element { get; }



		public UITKVisualNode(VisualElement element)
		{
			Element = element;
		}
	}
}
