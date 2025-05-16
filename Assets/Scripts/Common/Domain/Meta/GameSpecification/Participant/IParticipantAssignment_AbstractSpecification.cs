using Common.Domain.Game;



namespace Common.Domain.Meta.GameSpecification
{
	public interface IParticipantAbstractSpecification
	{
		ParticipantSpecies Species { get; }
	}


	public class HumanParticipantAbstractSpecification : IParticipantAbstractSpecification
	{
		public ParticipantSpecies Species => ParticipantSpecies.Human;

		public IUserIdentity? Identity { get; }
	}


	public class AiParticipantAbstractSpecification : IParticipantAbstractSpecification
	{
		public ParticipantSpecies Species => ParticipantSpecies.AI;

		public IAiAbstractSpecification Ai { get; }
	}



	public interface IUserIdentity
	{

	}



	public interface IParticipantAssignment { }


	public class PlayerAssignment : IParticipantAssignment
	{
		PolityId PolityId { get; }
	}



	public interface IParticipantAssignment_AbstractSpecification
	{
		IParticipantAbstractSpecification Participant { get; }

		IParticipantRole Role { get; }

		IParticipantAssignment Assignment { get; }
	}
}
