// using Domain.SavedGame;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class SavedGameSnapshotDetailsVM
// 	{
// 		public string Turn { get; private set; }
// 		public string Year { get; private set; }
//
// 		public string Comment { get; private set; }
//
// 		// public IReadOnlyList<PlayerVM> Players { get; private set; }
//
// 		//public PlayerVM ThisPlayer { get; private set; }
//
// 		public string Timestamp { get; private set; }
//
// 		public bool AutoSaved { get; private set; }
//
//
//
// 		public static SavedGameSnapshotDetailsVM FromSavedGameSnapshot(SavedGameSnapshot snapshot)
// 		{
// 			return new SavedGameSnapshotDetailsVM {
// 				Year = snapshot.Year.ToString(),
// 				Turn = snapshot.Turn.ToString(),
// 				Comment = snapshot.Comment,
// 				// Players = snapshot.Players.Map(PlayerVM.FromPlayer),
// 				Timestamp = snapshot.Timestamp.ToString(),
// 				AutoSaved = snapshot.AutoSaved
// 			};
// 		}
// 	}
// }
