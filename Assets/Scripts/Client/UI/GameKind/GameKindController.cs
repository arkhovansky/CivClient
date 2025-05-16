using System;
using System.Collections.Generic;
using Client.HiMod;
using Client.HiMod.Implementation;
using Common.Domain.Game;
using Common.Domain.Meta.History.Interface;



namespace Client.UI.GameKind
{
	public class GameKindController : Controller
		, IDisposable
	{
		public static IComponentMetadata Metadata;

		static GameKindController()
		{
			Metadata = new ComponentMetadata(new EntityType("GameKind"),
			                                 new ComponentContextItem("Focus", "Play"));
		}



		// public CellSink<string?> BackgroundScene { get; } // = "GameKindBackground", "MetaUIBackground";



		protected readonly IComponentResolver resolver;

		// protected readonly SceneLayer bgSceneLayer;

		protected readonly ControllerStack controllerStack;





		public GameKindController(
			ICommandRouter commandRouter,
			IComponentResolver resolver
		)
			: base(commandRouter)
		{
			this.resolver = resolver;

			controllerStack = new ControllerStack(this);


			// bgSceneLayer = new SceneLayer(MetaUIBackgroundScene);
			// gui.PushSceneLayer(bgSceneLayer);


			AddCommandHandler<PlayNewGameInstanceCommand>(OnPlayNewGameInstanceCommand);
			AddCommandHandler<BrowseGameInstancesCommand>(OnBrowseGameInstancesCommand);
			AddCommandHandler<PlayGameInstanceCommand>(OnPlayGameInstanceCommand);

			// AddEventHandler<GameQuitEvent>(OnGameQuit);


			InstantiateHomeController();
		}



		public virtual void Dispose()
		{
			// gui.PopSceneLayer();
		}



		protected void InstantiateHomeController()
		{
			var spec = new ComponentRole("Home");
			var controller = resolver.Resolve<IController>(spec);
			controllerStack.Push(controller, ControllerStack.ControllerDisposition.Fixed);
		}



		protected virtual void OnPlayNewGameInstanceCommand(PlayNewGameInstanceCommand command)
		{
			// IController controller = controllerStack.Peek();
			//
			// if (controller is INewGameController)
			// 	return;
			//
			// if (controller is not IHomeScreenController) {
			// 	if (controller.CanExitSilently) {
			// 		controllerStack.Pop();
			// 	}
			// 	// else
			// }


			// 1. Create GameInstance -> gameInstance
			// 2. Play gameInstance

			var creationController = resolver.Resolve<IOperationController>(
				new OperationSubject("Create", "GameInstance"));

			var gameInstanceController = resolver.Resolve<IController>(
				new EntityType("GameInstance"),
				new Parameter(creationController.Promise));

			controllerStack.Push(gameInstanceController);
			controllerStack.Push(creationController);
		}



		protected virtual void OnBrowseGameInstancesCommand(BrowseGameInstancesCommand command)
		{
			//

			var controller = resolver.Resolve<IController>(new CollectionSubject("GameInstance"));
			controllerStack.Push(controller, ControllerStack.ControllerDisposition.Transitional);
		}



		protected virtual void OnPlayGameInstanceCommand(PlayGameInstanceCommand command)
		{
			//

			// var snapshot = command.GameSnapshot;

			var controller = resolver.Resolve<IController>(new EntityType("GameInstance"),
			                                               new Parameter(command.GameInstance));
			controllerStack.Push(controller, ControllerStack.ControllerDisposition.Fixed);
		}
	}
}
