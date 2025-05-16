using Common.Domain.Meta.GameSpecification;



namespace ServerCore.Domain.GameSpecification
{
	public class GameAbstractSpecification : IGameAbstractSpecification
	{
		public string? Name { get; set; }

		public IWorldAbstractSpecification World { get; set; }

		public IParticipantsAbstractSpecification Participants { get; set; }



		protected internal GameAbstractSpecification(
			IWorldAbstractSpecification world,
			IParticipantsAbstractSpecification participants)
		{
			World = world;
			Participants = participants;
		}
	}
}
