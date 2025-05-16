using System;
using Common.Domain.Game;



namespace Common.GameKind
{
	public interface IGameKindRepository
	{
		IGameKind? Get(Guid id);
	}
}
