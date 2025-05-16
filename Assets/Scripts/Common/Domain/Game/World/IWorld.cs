using System.Collections.Generic;



namespace Common.Domain.Game.World
{
	public interface IWorld
	{
		IWorldTimeProgress TimeProgress { get; }

		IReadOnlyList<IPolity> Polities { get; }
	}
}
