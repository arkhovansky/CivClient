namespace Common.Domain.Meta.GameSpecification
{
	public interface IGameAbstractSpecification
	{
		string? Name { get; }

		IWorldAbstractSpecification World { get; }

		IParticipantsAbstractSpecification Participants { get; }
	}
}
