using Client.HiMod;
using Client.HiMod.Implementation;
using Client.UniHiMod;
using UnityEngine;
using UnityEngine.UIElements;



namespace Client.UI
{
	public class UI : MonoBehaviour
	{
		private readonly IComponentResolver _resolver;

		private readonly IGui _gui;



		public UI()
		{
			_gui = new Gui();

			var diContainer = new DiContainer();
			diContainer.Register(_gui.CommandRouter);

			_resolver = new ComponentResolver(
				new ComponentRegistry(
					new InEditorApplicationDirectoryStructure()),
				diContainer);
		}



		private void Awake()
		{
			var appController = _resolver.Resolve<IController>(
				new ComponentMetadata(new EntityTypeSubject("Application")));
			_gui.SetRootController(appController);
		}



		private void OnEnable()
		{
			// OnEnable is called after Live Reload when UIDocument's UXML asset is reloaded

			var uiDocument = GetComponent<UIDocument>();

			_gui.SetRootVisualNode(new UITKVisualNode(uiDocument.rootVisualElement));
		}



		private void OnDisable()
		{
		}



		private void Update()
		{
			_gui.Update();
		}
	}
}
