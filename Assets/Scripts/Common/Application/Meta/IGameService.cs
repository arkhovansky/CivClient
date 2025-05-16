using System;
using System.Threading.Tasks;
using Common.Domain.Game;



namespace Common.Application.Meta
{
	public interface IGameService
	{
		Task<IGameInstance> CreateGame(Guid kindId);
	}
}
