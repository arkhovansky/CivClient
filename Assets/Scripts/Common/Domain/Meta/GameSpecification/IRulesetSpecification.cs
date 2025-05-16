using System;



namespace Common.Domain.Meta.GameSpecification
{
	public interface IRulesetSpecification
	{
		Guid Id { get; set; }

		string Name { get; set; }
	}
}
