// using System;
// using System.Collections.Generic;
// using Client.HiMod;
// using Client.UI.Meta.Common.Commands;
// using Common.Application.Meta;
// using Common.Domain.Game;
// using Common.Domain.Meta.History.Interface;
// using Sodium.Frp;
// using UniMvvm;
// using UnityEngine.UIElements;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class GameMetaController : IGameMetaController
// 		, IDisposable
// 	{
// 		public CellSink<string?> MetaUIBackgroundScene { get; } // = "MetaUIBackground";
//
//
//
// 		protected readonly IGameKind _gameKind;
//
// 		protected readonly VisualElement _rootVisualElement;
//
// 		protected readonly SceneLayer bgSceneLayer;
//
// 		protected readonly Stack<FsmControllerState> stateStack;
//
//
//
//
//
// 		public GameMetaController(
// 			IGameKind gameKind,
// 			VisualElement rootVisualElement,
// 			IComponentResolver,
// 			IGameSnapshot? snapshot)
// 		{
// 			_gameKind = gameKind;
// 			_rootVisualElement = rootVisualElement;
//
//
// 			fsm = new _StateMachine()
// 				.AddState()
// 				.AddState(new GameState());
//
// 			AddCommandHandler<GoToNewGameUICommand>();
//
//
// 			if (snapshot == null)
// 				fsm.Push(new NewGameState());
// 			else
// 				fsm.Push(new GameLoadingState(snapshot));
// 		}
//
//
//
// 		public void Dispose()
// 		{
// 		}
//
//
//
// 		protected class NewGameState : FsmControllerState
// 		{
// 			public NewGameState(IGameInstance? gameInstance, IController parent)
// 			{
//
// 			}
//
// 			public void Enter() {
// 				Controller = com.Resolve<INewGameController>(_gameKind)
// 					.WithParameter(typeof(IGameKind), _gameKind)
// 					.WithParameter(typeof(VisualElement), _rootVisualElement);
// 					.WithParameter(typeof(IGameInstance), _game);
// 				com.Attach(Controller, _parent);
//
// 				Controller.Start();
// 			}
//
// 			public void Exit() {
// 				com.Detach(Controller);
// 				Controller.Dispose();
// 				HomeScreen = null;
// 			}
// 		}
//
//
//
// 		protected class GameLoadingState : FsmControllerState
// 		{
// 			public IGameSnapshot GameSnapshot;
//
// 			public GameLoadingState(IGameSnapshot snapshot, IController parent) {
// 				GameSnapshot = snapshot;
// 			}
//
// 			public void Enter() {
// 				var loader = com.Resolve<IGameLoader>(_gameKind)
// 					.WithParameter(typeof(IGameKind), _gameKind)
// 					.WithParameter(typeof(IGameSnapshot), gameSnapshot);
//
// 				Controller = com.Resolve<IGameLoadingScreen>(_gameKind)
// 					.WithParameter(typeof(IGameKind), _gameKind)
// 					.WithParameter(typeof(IGameLoader), loader);
// 				com.Attach(Controller, _parent);
//
// 				Controller.Start();
// 			}
//
// 			public void Exit() {
// 				com.Detach(Controller);
// 				Controller.Dispose();
// 			}
// 		}
//
//
//
// 		public void Start()
// 		{
//
// 		}
//
//
//
// 		protected void OnGoToNewGameUICommand()
// 		{
// 			if (fsm.State is NewGameState)
// 				return true;
//
// 			if (fsm.State is not HomeScreenState) {
// 				if (fsm.State.Controller.CanExitSilently) {
// 					fsm.Pop();
// 				}
// 				// else
// 			}
//
// 			fsm.Push(nameof(NewGameState));
// 		}
//
//
//
// 		protected void OnGoToLoadGameUICommand()
// 		{
// 			if (fsm.currentState is LoadGameState)
// 				return true;
//
// 			//
//
// 			fsm.Push(nameof(LoadGameState));
// 		}
//
//
//
// 		protected void OnLoadGameCommand(LoadGameCommand command)
// 		{
// 			// if (fsm.State.Controller.CanExitSilently)
//
// 			var snapshot = command.GameSnapshot;
// 			fsm.To(new GameState(snapshot));
// 		}
//
//
//
// 		protected void OnGameQuit()
// 		{
// 			if (fsm.State is not GameState)
// 				throw new InvalidOperationException();
//
// 			fsm.Pop();
// 		}
//
//
//
//
// 		// {
// 		// 	switch (command) {
// 		// 		case LoadGameCommand: {
// 		// 			// if (fsm.currentState is GameLoadingState) {
// 		// 			// 	if (((LoadGameCommand)command).GameSnapshot.Id == fsm.currentState.Controller.GameSnapshot.Id)
// 		// 			// 		return true;
// 		// 			//
// 		// 			// 	return false; //TODO: Return error instead?
// 		// 			// }
// 		//
// 		// 			var snapshot = ((LoadGameCommand)command).GameSnapshot;
// 		// 			if (snapshot.GamePhase == GamePhase.Setup)
// 		// 				fsm.To(new NewGameState(snapshot));
// 		// 			else
// 		// 				fsm.To(new GameLoadingState(snapshot));
// 		//
// 		// 			return true;
// 		// 		}
// 		//
// 		// 		case StartGameCommand: {
// 		// 			var gameId = ((StartGameCommand)command).GameId;
// 		// 			fsm.To(new GameState(gameId));
// 		//
// 		// 			return true;
// 		// 		}
// 		//
// 		// 		default:
// 		// 			return false;
// 		// 	}
// 		// }
//
//
//
// 		public void StartNewGame()
// 		{
// 			// IGameCreator gameCreator = new GameCreator();
// 			// Game game = gameCreator.CreateGame(_gameSpecification);
// 			//
// 			// //TODO: UnloadSceneOptions
// 			// AsyncOperation op = SceneManager.UnloadSceneAsync(k_StartMenuScene);
// 			//
// 			// CreateGameScene(game);
//
// 		}
//
//
//
// 		// private void CreateGameScene(Game game)
// 		// {
// 		// 	//TODO: CreateSceneParameters
// 		// 	Scene scene = SceneManager.CreateScene(k_GameScene);
// 		// 	SceneManager.SetActiveScene(scene);
// 		//
// 		// }
//
//
//
// 		public void LoadGame(ISavedGameSnapshot gameSnapshot)
// 		{
// 			_metaUI.Delete();
// 			_metaUI = null;
//
// 			_loadingScreen = Components.Instantiate("LoadingScreen", this);
// 			var gameLoadingProcess = _gameLoader.CreateLoadingProcess(gameSnapshot);
// 			_loadingScreen.SetModel(gameLoadingProcess);
//
// 			_game = await gameLoadingProcess.Run();
//
// 			_loadingScreen.Delete();
// 			_loadingScreen = null;
//
// 			_gameUI = Components.Instantiate("GameUI", this);
// 			_gameUI.SetModel(_game);
// 		}
// 	}
// }
