using System;
using Common.Domain.Meta.GameSpecification;



namespace ServerCore.Domain.GameSpecification
{
	public class RulesetSpecification : IRulesetSpecification
	{
		public Guid Id { get; set; }

		public string Name { get; set; }
	}
}
