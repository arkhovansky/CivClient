using Common.Domain.Meta.GameSpecification;
using Common.Util;



namespace FreeCiv.Common.Domain.Game
{
	public class PolityKindAbstractSpecification : IPolityKindAbstractSpecification
	{
		public MaybeRandom<NationSpecification> Nation { get; set; }
	}
}
