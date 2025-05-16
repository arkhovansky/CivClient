using System;
using System.Reflection;
using Common.Domain.Game;



namespace Common.GameKind
{
	public class GameKind : IGameKind
	{
		public Guid Id { get; }


		public string Name { get; }

		public Assembly Assembly { get; }
	}
}
