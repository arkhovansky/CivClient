using Common.Domain.Meta.GameSpecification;
using Common.Util;



namespace FreeCiv.Common.Domain.Meta
{
	public class AiAbstractSpecification : IAiAbstractSpecification
	{
		public MaybeRandom<AiStrength> Strength { get; set; }
	}
}
