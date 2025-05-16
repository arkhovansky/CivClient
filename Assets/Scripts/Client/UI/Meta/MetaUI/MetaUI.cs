// using Client.HiMod;
// using Common.Domain.Game;
//
//
//
// namespace Client.UI.Meta.MetaUI
// {
// 	public class MetaUIClass : UIComponentClass
// 	{
// 		public string Id => "MetaUI";
//
// 		public IController Controller { get; } = new MetaUIController();
//
// 		public IWidget Widget { get; } = new ScreenWidget {
// 			Id = "MetaUIWidget",
// 			BackgroundScene = "MetaUIBackground"
// 		};
// 	}
//
//
//
// 	public class MetaUI : UIComponent
// 	{
// 		public MetaUI(IGameKind gameKind,
// 		              IMetaUIController controller,
// 		              IMetaUIWidget widget)
// 		{
// 			_controller = controller;
// 		}
//
//
//
// 		public Start()
// 		{
// 			com.Resolve<IStartMenu>
// 		}
//
//
//
// 		private IController _controller;
//
// 		private IWidget _widget;
// 	}
// }
