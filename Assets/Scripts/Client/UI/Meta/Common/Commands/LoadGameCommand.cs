// using System;
// using Common.Application.SavedGame.Interface.Models;
// using Sodium.Frp;
// using UniMvvm;
//
//
//
// namespace Client.UI.Meta.Common.Commands
// {
// 	public class LoadGameCommand : Command
// 	{
// 		public Cell<ISavedGameSnapshotBrief?> GameSnapshot { get; }
//
//
// 		private readonly IGameKindMainController _controller;
//
//
//
// 		public LoadGameCommand(Cell<ISavedGameSnapshotBrief?> snapshot, IGameKindMainController controller)
// 			: base(snapshot.Map(_ => _ != null))
// 		{
// 			_controller = controller;
// 			GameSnapshot = snapshot;
// 		}
//
//
//
// 		public override void Execute()
// 		{
// 			ISavedGameSnapshotBrief? snapshot = GameSnapshot.Sample();
//
// 			if (snapshot == null)
// 				throw new InvalidOperationException("Game snapshot is null");
//
// 			_controller.LoadGame(snapshot);
// 		}
// 	}
// }
