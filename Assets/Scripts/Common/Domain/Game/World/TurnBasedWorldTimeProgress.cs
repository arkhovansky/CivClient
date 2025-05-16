namespace Common.Domain.Game.World
{
	public class TurnBasedWorldTimeProgress : IWorldTimeProgress
	{
		public IWorldDateTime WorldDateTime { get; }

		public uint Turn { get; }



		public TurnBasedWorldTimeProgress(IWorldDateTime worldDateTime, uint turn)
		{
			WorldDateTime = worldDateTime;
			Turn = turn;
		}
	}
}
