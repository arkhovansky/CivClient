// using Client.UI.Meta.NewGameDialog.Interface;
// using Client.UI.Meta.NewGameDialog.Interface.ViewModels;
// using Common.Domain.Meta;
// using Common.Domain.Meta.GameSpecification;
//
//
//
// namespace Client.UI.Meta.NewGameDialog.Implementation.ViewModels
// {
// 	public class NewGameDialogVM : INewGameDialogVM
// 	{
// 		public IGameAttributesVM GameAttributesVM { get; }
//
// 		public IWorldAndPlayersVM WorldAndPlayersVM { get; }
//
// 		public IThisPlayerVM ThisPlayerVM { get; }
//
//
//
// 		public NewGameDialogVM(ILobby lobby, IGameKindMainController controller, INewGameDialogVMFactory factory)
// 		{
// 			IGameAbstractSpecification gameSpec = lobby.GameSpecification;
//
// 			GameAttributesVM = factory.CreateGameAttributesVM(gameSpec.Attributes, controller, factory);
//
// 			WorldAndPlayersVM = factory.CreateWorldAndPlayersVM(gameSpec.World, controller, factory);
//
// 			ThisPlayerVM = factory.CreateThisPlayerVM(gameSpec.World, gameSpec.Participants, controller, factory);
// 		}
// 	}
// }
