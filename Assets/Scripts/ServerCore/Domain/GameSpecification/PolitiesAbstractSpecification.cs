// using System.Collections.Generic;
// using Common.Domain.Meta.GameSpecification;
// using Common.Util;
//
//
//
// namespace ServerCore.Domain.GameSpecification
// {
// 	public class PolitiesAbstractSpecification : IPolitiesAbstractSpecification
// 	{
// 		public IList<IPolityAbstractSpecification> ExplicitGameSides { get; }
//
// 		public ValueOrRange<uint>? GameSideCount { get; }
//
// 		public IPolityAbstractSpecification? FillerGameSide { get; }
//
//
//
// 		public PolitiesAbstractSpecification(ValueOrRange<uint>? gameSideCount,
// 		                                      IPolityAbstractSpecification? fillerGameSide = null)
// 		{
// 			ExplicitGameSides = new List<IPolityAbstractSpecification>();
// 			GameSideCount = gameSideCount;
// 			FillerGameSide = fillerGameSide;
// 		}
// 	}
// }
