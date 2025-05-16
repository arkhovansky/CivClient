namespace Client.HiMod.Implementation
{
	public record ComponentRole(string Value) : IPartialSubjectComponentSpecification;

	public record ComponentOperator(string Value) : IPartialSubjectComponentSpecification;
}
