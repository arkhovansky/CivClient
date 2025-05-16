// using Domain.SavedGame;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class SavedGameSnapshotMainInfoVM
// 	{
// 		public string Turn { get; private set; }
// 		public string Year { get; private set; }
//
// 		public string Comment { get; private set; }
//
// 		public string Timestamp { get; private set; }
// 		public bool AutoSaved { get; private set; }
//
//
//
// 		// public SavedGameSnapshotMainInfoVM(string year, string turn, string comment, string timestamp, bool autoSaved)
// 		// {
// 		// 	Year = year;
// 		// 	Turn = turn;
// 		// 	Comment = comment;
// 		// 	Timestamp = timestamp;
// 		// 	AutoSaved = autoSaved;
// 		// }
//
//
// 		public static SavedGameSnapshotMainInfoVM FromSavedGameSnapshot(SavedGameSnapshot snapshot)
// 		{
// 			return new SavedGameSnapshotMainInfoVM {
// 				Turn = snapshot.Turn.ToString(),
// 				Year = snapshot.Year.ToString(),
// 				Comment = snapshot.Comment,
// 				Timestamp = snapshot.Timestamp.ToString(),
// 				AutoSaved = snapshot.AutoSaved
// 			};
// 		}
// 	}
// }
