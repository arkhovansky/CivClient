using System;
using System.Collections.Generic;
using Client.HiMod;
using Client.HiMod.Implementation;
using Common.Domain.Game;



namespace Client.UI.GameKind.GameInstance
{
	public class GameInstanceController : Controller
		, IDisposable
	{
		public static IComponentMetadata Metadata;

		static GameInstanceController()
		{
			Metadata = new ComponentMetadata(new EntityType("GameInstance"),
			                                 new ComponentContextItem("Focus", "Play"));
		}



		protected readonly IGameInstance game;

		protected readonly IComponentResolver resolver;


		protected readonly Stack<Controller> controllerStack;



		public GameInstanceController(IGameInstance game,
		                              ICommandRouter commandRouter,
		                              IComponentResolver resolver
		)
			: base(commandRouter)
		{
			this.game = game;
			this.resolver = resolver;

			AddCommandHandler<StartGameInstanceCommand>(OnStartGameInstanceCommand);

			CreateChild();
		}



		protected void CreateChild()
		{
			switch (game.Phase) {
				case GamePhase.Setup: {
					var spec = new ComponentRole("Setup");
					var child = resolver.Resolve<IController>(spec, game);
					SetChildController(child);

					break;
				}

				case GamePhase.Ready:
					throw new NotImplementedException();

				case GamePhase.Started: {
					var spec = new ComponentOperator("Load");
					var child = resolver.Resolve<IController>(spec, game);

					child.OnComplete += OnGameLoaded;

					SetChildController(child);

					break;
				}

				case GamePhase.Finished: {
					var spec = new ComponentRole("Finished");
					var child = resolver.Resolve<IController>(spec, game);
					SetChildController(child);

					break;
				}

				default:
					throw new ArgumentOutOfRangeException();
			}
		}



		public virtual void Dispose()
		{

		}



		protected virtual void OnStartGameInstanceCommand(StartGameInstanceCommand command)
		{
			//TODO: Need loading?

			StartGame();
		}



		protected virtual void OnGameLoaded()
		{
			StartGame();
		}



		protected virtual void StartGame()
		{
			var spec = new ComponentRole("Play");
			var child = resolver.Resolve<IController>(spec, game);
			SetChildController(child);
		}
	}
}
