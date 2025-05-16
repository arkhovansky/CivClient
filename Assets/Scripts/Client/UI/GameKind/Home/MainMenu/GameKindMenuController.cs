using Client.HiMod;
using Client.HiMod.Implementation;



namespace Client.UI.GameKind.Home.MainMenu
{
	public class GameKindMenuController : Controller
	{
		public static IComponentMetadata Metadata;

		static GameKindMenuController()
		{
			Metadata = new ComponentMetadata(new RoleSubject("Menu", new EntityType("GameKind")),
			                                 new ComponentContextItem("Focus", "Play"));
		}



		public IVisualAsset visualAsset { get; }



		public GameKindMenuController(ICommandRouter commandRouter)
			: base(commandRouter)
		{

		}



		public void Start()
		{

		}



		public override void SetVisualNode(IVisualNode visualNode)
		{
			gui.
		}
	}
}
