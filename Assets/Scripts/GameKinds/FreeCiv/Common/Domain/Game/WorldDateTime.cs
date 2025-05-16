using Common.Domain.Game;
using Common.Domain.Game.World;
using Common.Util;



namespace FreeCiv.Common.Domain.Game
{
	public class WorldDateTime : IWorldDateTime
	{
		public HistoricYear Year { get; set; }
	}
}
