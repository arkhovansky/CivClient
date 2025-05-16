using System.Collections.Generic;
using Common.Domain.Meta.GameSpecification.Util;
using Common.Util;
using Sodium.Frp;



namespace Common.Domain.Meta.GameSpecification
{
	public interface IPolityCount_AbstractSpecification
		: IMaybeRandom
	{
		ValueOrRange<uint> Count { get; }
	}



	public interface IPolitiesAbstractSpecification
	{
		IList<IPolityAbstractSpecification> ExplicitPolities { get; }

		Cell<IPolityCount_AbstractSpecification> PolityCount { get; }

		IPolityAbstractSpecification? FillerPolity { get; }
	}
}
