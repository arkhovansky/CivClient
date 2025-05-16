using Client.HiMod;
using Client.HiMod.Implementation;
using Client.UniHiMod;



namespace Client.UI.Application
{
	public class ApplicationController : ApplicationController_Base
	{
		public static IComponentMetadata Metadata;

		static ApplicationController()
		{
			Metadata = new ComponentMetadata(new EntityType("Application"));
		}



		public ApplicationController(ICommandRouter commandRouter, IComponentResolver resolver)
			: base(commandRouter)
		{
			CreateChild(resolver);
		}



		private void CreateChild(IComponentResolver resolver)
		{
			// IControllerMetadata spec = settings.Get<IControllerMetadata>("Application.UI.StartPage");
			var spec = new ComponentMetadata(new EntityInstance("GameKind", "FreeCiv"),
			                                 new ComponentContextItem("Focus", "Play"));
			var child = resolver.Resolve<IController>(spec);

			// child.InjectCommand<ExitApplicationCommand>();

			SetChild(child);
		}



		public override void SetVisualNode(IVisualNode visualNode)
		{
			Child.SetVisualNode(visualNode);
		}
	}
}
