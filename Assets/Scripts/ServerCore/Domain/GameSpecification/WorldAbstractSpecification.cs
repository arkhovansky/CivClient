using System;
using Codice.Client.BaseCommands;
using Common.Domain.Meta.GameSpecification;
using Common.Domain.Meta.GameSpecification.Util;
using Sodium.Frp;



namespace ServerCore.Domain.GameSpecification
{
	public class WorldAbstractSpecification : IWorldAbstractSpecification
	{
		public Cell<IRulesetSpecification?> Ruleset => ruleset;

		public ITerrainAbstractSpecification Terrain { get; }

		public IPolitiesAbstractSpecification Polities { get; }

		public Cell<IPerPolitySpace_AbstractSpecification> PerPolitySpace => perPolitySpace;
		// public Cell<IPerPolitySpaceClass_AbstractSpecification?> PerPolitySpaceClass { get; }

		// public Cell<IWorldClass_AbstractSpecification>? Class { get; }



		protected readonly CellSink<IRulesetSpecification?> ruleset;

		protected readonly CellLoop<IPerPolitySpace_AbstractSpecification> perPolitySpace;
		protected readonly StreamSink<IPerPolitySpace_AbstractSpecification> sPerPolitySpaceSink;



		public WorldAbstractSpecification(IWorldClassifier worldClassifier,
		                                  IWorldAbstractSpecificationFactory factory)
		{
			perPolitySpace = Cell.CreateLoop<IPerPolitySpace_AbstractSpecification>();
			var polityCount = Cell.CreateLoop<IPolityCount_AbstractSpecification>();

			ruleset = Cell.CreateSink<IRulesetSpecification?>(null);

			Terrain = factory.CreateTerrainAbstractSpecification(
				polityCount, perPolitySpace /*, worldClassifier.TerrainClassifier*/);

			Polities = factory.CreatePolitiesAbstractSpecification(Terrain.Area, perPolitySpace);

			sPerPolitySpaceSink = Stream.CreateSink<IPerPolitySpace_AbstractSpecification>();
			var sPerPolitySpaceFromMembers =
				factory.PerPolitySpace_AbstractSpecification.Map(Terrain.Area, polityCount);
			perPolitySpace.Loop(sPerPolitySpaceSink.OrElse(sPerPolitySpaceFromMembers)
				                    .Hold(factory.PerPolitySpace_AbstractSpecification.CreateDefault()));

			// Class = worldClassifier.MapWorldClass(Terrain, Polities, perPolitySpace);
			// PerPolitySpaceClass = worldClassifier.MapPerPolitySpaceClass(perPolitySpace);
		}
	}



	public class WorldClass_AbstractSpecification : IWorldClass_AbstractSpecification
	{
		private readonly IWorldClass? _class;

		public IWorldClass Class {
			get {
				if (_class == null) throw new InvalidOperationException();
				return _class;
			}
		}

		public bool IsRandom { get; }

		public bool IsCustom { get; }



		protected internal WorldClass_AbstractSpecification(IWorldClass @class)
		{
			_class = @class;
		}


		protected internal WorldClass_AbstractSpecification(AbstractSpecificationSpecialValue specialValue)
		{
			switch (specialValue) {
				case AbstractSpecificationSpecialValue.Random:
					IsRandom = true;
					break;
				case AbstractSpecificationSpecialValue.Custom:
					IsCustom = true;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(specialValue), specialValue, null);
			}
		}
	}



	// public class WorldClassifier : IWorldClassifier
	// {
	// 	protected readonly IWorldSizeClasses sizeClasses;
	//
	//
	//
	// 	public WorldClassifier(IWorldSizeClasses sizeClasses)
	// 	{
	// 		this.sizeClasses = sizeClasses;
	// 	}
	//
	//
	//
	// 	public Cell<IWorldClass_AbstractSpecification> MapWorldClass(
	// 		ITerrainAbstractSpecification terrain,
	// 		IPolitiesAbstractSpecification polities,
	// 		Cell<IPerPolitySpace_AbstractSpecification> perPolitySpace)
	// 	{
	// 		return MapWorldClass(terrain.SizeClass, polities.PolityCount);
	// 	}
	//
	//
	// 	protected Cell<IWorldClass_AbstractSpecification> MapWorldClass(
	// 		Cell<ITerrainSizeClass_AbstractSpecification> terrainSizeClass,
	// 		Cell<IPolityCount_AbstractSpecification> polityCount)
	// 	{
	// 		var sFromTerrainSizeClass = terrainSizeClass.Updates()
	// 			.Snapshot(polityCount, MapWorldClass);
	// 		var sFromPolityCount = polityCount.Updates()
	// 			.Snapshot(terrainSizeClass, (pc, tsc) => MapWorldClass(tsc, pc));
	//
	// 		return sFromTerrainSizeClass.OrElse(sFromPolityCount).Hold(null);
	// 	}
	//
	//
	// 	protected IWorldClass_AbstractSpecification MapWorldClass(
	// 		ITerrainSizeClass_AbstractSpecification terrainSizeClass,
	// 		IPolityCount_AbstractSpecification polityCount)
	// 	{
	// 		if (terrainSizeClass.IsCustom)
	// 			return new WorldClass_AbstractSpecification(AbstractSpecificationSpecialValue.Custom);
	//
	// 		if (terrainSizeClass.IsRandom) {
	// 			var specialValue = polityCount.IsRandom ?
	// 				AbstractSpecificationSpecialValue.Random : AbstractSpecificationSpecialValue.Custom;
	// 			return new WorldClass_AbstractSpecification(specialValue);
	// 		}
	//
	// 		WorldSizeClass? sizeClass = sizeClasses.Find(terrainSizeClass.Class, polityCount.Count);
	//
	// 		if(sizeClass == null)
	// 			return new WorldClass_AbstractSpecification(AbstractSpecificationSpecialValue.Custom);
	//
	// 		return new WorldClass_AbstractSpecification(sizeClass);
	// 	}
	// }
}
