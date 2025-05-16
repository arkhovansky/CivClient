using Common.Util;



namespace Common.Domain.Meta.GameSpecification
{
	public class WorldSizeClass : IWorldClass
	{
		public string Name { get; }

		public TerrainSizeClass TerrainSizeClass { get; }

		public ValueOrRange<uint> PolityCount { get; }
	}


	public interface IWorldSizeClasses
	{
		WorldSizeClass? Find(TerrainSizeClass terrainSizeClass, ValueOrRange<uint> polityCount);
	}
}
