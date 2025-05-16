using Common.Domain.Meta.GameSpecification.Util;
using Common.Util;



namespace Common.Domain.Meta.GameSpecification {
	public class TerrainSizeClass
	{
		public string Name { get; }
		public Range<uint> Area { get; }
	}


	public interface ITerrainSizeClasses
	{
		TerrainSizeClass? Find(ValueOrRange<uint> area);
	}



	public interface ITerrainSizeClass_AbstractSpecification
		: IMaybeRandom, IMaybeCustom
	{
		TerrainSizeClass Class { get; }
	}
}
