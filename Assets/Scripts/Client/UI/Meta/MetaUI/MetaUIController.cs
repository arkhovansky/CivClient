// using Common.Application.Meta;
// using Common.Application.SavedGame.Interface.Models;
// using Common.Application.SavedGame.Interface.Services;
// using Common.Domain.Game;
// using Common.GameKind;
// using UnityEngine.SceneManagement;
// using UnityEngine.UIElements;
//
//
//
// namespace Client.UI.Meta
// {
// 	enum UIState
// 	{
// 		Initial,
// 		MainMenu,
// 		NewGameDialog,
// 		LoadGameMenu,
// 		Game
// 	}
//
// 	static class UIStateExtensions
// 	{
// 		public static bool InStartMenu(this UIState state)
// 		{
// 			return state is UIState.MainMenu or UIState.NewGameDialog or UIState.LoadGameMenu;
// 		}
// 	}
//
//
//
// 	public class MetaUIController : IMetaUIController
// 	{
// 		public string BackgroundScene { get; set; } = "MetaUIBackground";
//
//
//
// 		private readonly VisualElement _rootVisualElement;
//
// 		private readonly ISavedGameService _savedGameService;
//
// 		private readonly IGameService _gameService;
//
// 		private object _view;
//
// 		private UIState _state = UIState.Initial;
//
//
//
// 		public MetaUIController(
// 			IGameKind gameKind,
// 			VisualElement rootVisualElement,
// 			ISavedGameService savedGameService,
// 			IGameService gameService)
// 		{
// 			_rootVisualElement = rootVisualElement;
// 			_savedGameService = savedGameService;
// 			_gameService = gameService;
// 		}
//
//
//
// 		public void Start()
// 		{
// 			SceneManager.LoadScene(BackgroundScene, LoadSceneMode.Additive);
//
// 			curentComponent = com.Resolve<IStartMenu>(_gameKind)
// 				.WithParameter(typeof(IGameKind), _gameKind)
// 				.WithParameter(typeof(VisualElement), _rootVisualElement);
// 			com.Attach(currentComponent, this);
// 		}
//
//
//
// 		public void GoToNewGameDialog()
// 		{
// 			// IGameInstance gameInstance = await _gameService.CreateGame();
// 			// ILobby lobby = await game.CreateLobby();
// 			//
// 			// var viewModel = new NewGameDialogVM(lobby, this);
// 			// _view = new NewGameDialogView(_rootVisualElement, viewModel);
// 			//
// 			// _state = UIState.NewGameDialog;
// 		}
//
//
//
// 		public void GoToLoadGameMenu()
// 		{
// 			// var savedGameRepository = new SavedGameRepository_Stub();
// 			// var viewModel = new LoadGameMenuVM(savedGameRepository, this);
// 			// // _viewModel = viewModel;
// 			// _view = new LoadGameMenuView(_rootVisualElement, viewModel);
// 			//
// 			// _state = UIState.LoadGameMenu;
// 		}
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
// 		//
// 		//
// 		// }
//
//
//
// 		public void LoadGame(ISavedGameSnapshotBrief gameSnapshot)
// 		{
// 			throw new System.NotImplementedException();
// 		}
// 	}
// }
