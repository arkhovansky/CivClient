using Common.Domain.Meta.GameSpecification.Util;
using Common.Util;
using Sodium.Frp;



namespace Common.Domain.Meta.GameSpecification
{
	public interface IPerPolitySpace_AbstractSpecification
		: IMaybeRandom
	{
		ValueOrRange<uint> PerPolityArea { get; }
	}



	public interface IPerPolitySpace_AbstractSpecification_Static
	{
		IPerPolitySpace_AbstractSpecification CreateDefault();

		Stream<IPerPolitySpace_AbstractSpecification> Map(Cell<ITerrainArea_AbstractSpecification> terrainArea,
		                                                  Cell<IPolityCount_AbstractSpecification> polityCount);
	}



	public class PerPolitySpaceClass
	{
		public string Name { get; }

		public Range<uint> Area { get; }
	}


	public interface IPerPolitySpaceClass_AbstractSpecification
		: IMaybeRandom, IMaybeCustom
	{
		PerPolitySpaceClass Class { get; }
	}



	public interface IWorldClass
	{
		string Name { get; }
	}



	public interface IWorldClass_AbstractSpecification
		: IMaybeRandom, IMaybeCustom
	{
		IWorldClass Class { get; }
	}



	public interface IWorldClassifier
	{
		Cell<IWorldClass_AbstractSpecification> MapWorldClass(
			ITerrainAbstractSpecification terrain,
			IPolitiesAbstractSpecification polities,
			Cell<IPerPolitySpace_AbstractSpecification> perPolitySpace);
	}



	public interface IWorldAbstractSpecification
	{
		Cell<IRulesetSpecification?> Ruleset { get; }

		ITerrainAbstractSpecification Terrain { get; }

		IPolitiesAbstractSpecification Polities { get; }

		Cell<IPerPolitySpace_AbstractSpecification> PerPolitySpace { get; }
		// Cell<IPerPolitySpaceClass_AbstractSpecification?> PerPolitySpaceClass { get; }

		// Cell<IWorldClass_AbstractSpecification?> Class { get; }
	}



	public interface IWorldAbstractSpecificationFactory
	{
		// IWorldSizeClass_AbstractSpecification CreateDefault_WorldSizeClass_AbstractSpecification();
		//
		// Stream<IWorldSizeClass_AbstractSpecification> Map_WorldSizeClass_AbstractSpecification(
		// 	Cell<ITerrainSizeClass_AbstractSpecification> terrainSizeClass,
		// 	Cell<IPolityCount_AbstractSpecification> polityCount,
		// 	IWorldSizeClasses worldSizeClasses);


		ITerrainAbstractSpecification CreateTerrainAbstractSpecification(
			Cell<IPolityCount_AbstractSpecification> polityCount,
			Cell<IPerPolitySpace_AbstractSpecification> perPolitySpace
			/*ITerrainClassifier terrainClassifier*/);


		IPolitiesAbstractSpecification CreatePolitiesAbstractSpecification(
			Cell<ITerrainArea_AbstractSpecification> terrainArea,
			Cell<IPerPolitySpace_AbstractSpecification> perPolitySpace);


		IPerPolitySpace_AbstractSpecification_Static PerPolitySpace_AbstractSpecification { get; }
	}
}
