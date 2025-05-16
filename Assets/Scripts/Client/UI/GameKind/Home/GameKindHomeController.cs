using Client.HiMod;
using Client.HiMod.Implementation;



namespace Client.UI.GameKind.Home
{
	public class GameKindHomeController : Controller
	{
		public static IComponentMetadata Metadata;

		static GameKindHomeController()
		{
			Metadata = new ComponentMetadata(new RoleSubject("Home", new EntityType("GameKind")),
			                                 new ComponentContextItem("Focus", "Play"));
		}



		protected readonly IComponentResolver resolver;



		public GameKindHomeController(ICommandRouter commandRouter,
		                              IComponentResolver resolver)
			: base(commandRouter)
		{
			this.resolver = resolver;

			CreateChildren();
		}



		protected void CreateChildren()
		{
			var spec = new ComponentRole("Menu");
			var child = resolver.Resolve<IController>(spec);
			AddActiveChild(child);
		}
	}
}
