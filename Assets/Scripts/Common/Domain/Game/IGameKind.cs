using System;



namespace Common.Domain.Game
{
	public interface IGameKind
	{
		Guid Id { get; }

		string Name { get; }
	}
}
