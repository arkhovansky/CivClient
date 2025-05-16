using System.Collections.Generic;



namespace Common.Domain.Meta.GameSpecification
{
	public interface IParticipantsAbstractSpecification
	{
		IReadOnlyList<IParticipantAssignment_AbstractSpecification> ExplicitAssignments { get; }

		IAiAbstractSpecification? FillerAi { get; }
	}
}
