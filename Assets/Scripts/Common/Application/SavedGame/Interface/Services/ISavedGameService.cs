using System.Threading.Tasks;
using Common.Application.SavedGame.Interface.Models;



namespace Common.Application.SavedGame.Interface.Services
{
	public interface ISavedGameService
	{
		Task<ISavedGameSnapshotBrief?> GetLastSavedGameSnapshot();
	}
}
