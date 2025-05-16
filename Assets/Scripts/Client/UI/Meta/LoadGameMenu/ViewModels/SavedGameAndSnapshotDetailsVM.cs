// using Common.Domain.Meta;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class SavedGameAndSnapshotDetailsVM
// 	{
// 		public SavedGameDetailsVM Game { get; private set; }
// 		public SavedGameSnapshotDetailsVM Snapshot { get; private set; }
//
//
// 		public static SavedGameAndSnapshotDetailsVM FromSavedGameSnapshot(SavedGameSnapshotBrief snapshot)
// 		{
// 			return new SavedGameAndSnapshotDetailsVM {
// 				Game = SavedGameDetailsVM.FromSavedGame(snapshot.Game),
// 				Snapshot = SavedGameSnapshotDetailsVM.FromSavedGameSnapshot(snapshot)
// 			};
// 		}
// 	}
// }
