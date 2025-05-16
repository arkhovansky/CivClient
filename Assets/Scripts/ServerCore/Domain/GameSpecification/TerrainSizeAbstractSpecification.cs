// using System;
// using Common.Domain.GameSpecification;
// using Common.Domain.GameSpecification.Util;
// using Common.Util;
// using Sodium.Frp;
//
//
//
// namespace ServerCore.Domain.GameSpecification
// {
// 	public class TerrainSizeAbstractSpecification : ITerrainSizeAbstractSpecification
// 	{
// 		public Cell<ITerrainSizeClass_AbstractSpecification> SizeClass { get; }
//
// 		public Cell<ITerrainArea_AbstractSpecification> Area { get; }
//
//
//
// 		protected readonly Stream<ITerrainSizeClass_AbstractSpecification> sSizeClass;
// 		protected readonly StreamLoop<ITerrainArea_AbstractSpecification> sArea;
// 		protected readonly StreamLoop<ITerrainPlaneProjectionDimensions_AbstractSpecification?> sPlaneProjectionDimensions;
//
//
//
// 		public TerrainSizeAbstractSpecification(
// 			Stream<IWorldSizeClass_AbstractSpecification> sWorldSizeClass,
// 			Cell<ITerrainPlaneProjectionDimensions_AbstractSpecification?> planeProjectionDimensions,
// 			ITerrainSizeClasses terrainSizeClasses,
// 			IWorldAbstractSpecificationFactory factory)
// 		{
// 			sArea = Stream.CreateLoop<ITerrainArea_AbstractSpecification>();
// 			sPlaneProjectionDimensions = Stream.CreateLoop<ITerrainPlaneProjectionDimensions_AbstractSpecification?>();
//
// 			sSizeClass = TerrainSizeClass_AbstractSpecification.Map(sWorldSizeClass, sArea, terrainSizeClasses);
// 			SizeClass = sSizeClass.Hold(
// 				new TerrainSizeClass_AbstractSpecification(AbstractSpecificationSpecialValue.Random));
//
// 			sArea.Loop(Area.Map(sSizeClass, sPlaneProjectionDimensions));
// 			Area = sArea.Hold(new Area(ValueOrRange.Of(0u)));
//
// 			sPlaneProjectionDimensions.Loop(PlaneProjectionDimensions.Map(
// 				                               Area, planeProjectionAspectRatio));
// 		}
// 	}
//
//
//
// 	public class TerrainSizeClass_AbstractSpecification : ITerrainSizeClass_AbstractSpecification
// 	{
// 		private readonly TerrainSizeClass? _sizeClass;
//
// 		public TerrainSizeClass Class {
// 			get {
// 				if (_sizeClass == null) throw new InvalidOperationException();
// 				return _sizeClass;
// 			}
// 		}
//
// 		public bool IsRandom { get; }
//
// 		public bool IsCustom { get; }
//
//
//
// 		public TerrainSizeClass_AbstractSpecification(TerrainSizeClass sizeClass)
// 		{
// 			_sizeClass = sizeClass;
// 		}
//
//
// 		public TerrainSizeClass_AbstractSpecification(AbstractSpecificationSpecialValue specialValue)
// 		{
// 			switch (specialValue) {
// 				case AbstractSpecificationSpecialValue.Random:
// 					IsRandom = true;
// 					break;
// 				case AbstractSpecificationSpecialValue.Custom:
// 					IsCustom = true;
// 					break;
// 				default:
// 					throw new ArgumentOutOfRangeException(nameof(specialValue), specialValue, null);
// 			}
// 		}
//
//
//
// 		protected internal static Stream<ITerrainSizeClass_AbstractSpecification> Map(
// 			Stream<IWorldSizeClass_AbstractSpecification> sWorldSizeClass,
// 			Stream<ITerrainArea_AbstractSpecification> sArea,
// 			ITerrainSizeClasses terrainSizeClasses)
// 		{
// 			var sFromWorldSizeClass = sWorldSizeClass.Filter(_ => !_.IsCustom).Map(From_WorldSizeClass);
// 			var sFromArea = sArea.Map(_ => From_Area(_, terrainSizeClasses));
// 			return sFromWorldSizeClass.OrElse(sFromArea);
// 		}
//
//
//
// 		protected static ITerrainSizeClass_AbstractSpecification From_WorldSizeClass(
// 			IWorldSizeClass_AbstractSpecification worldSizeClass)
// 		{
// 			if (worldSizeClass.IsCustom) throw new ArgumentException();
//
// 			return worldSizeClass.IsRandom
// 				? new TerrainSizeClass_AbstractSpecification(AbstractSpecificationSpecialValue.Random)
// 				: new TerrainSizeClass_AbstractSpecification(worldSizeClass.SizeClass.TerrainSizeClass);
// 		}
//
//
// 		protected static ITerrainSizeClass_AbstractSpecification From_Area(
// 			ITerrainArea_AbstractSpecification area,
// 			ITerrainSizeClasses terrainSizeClasses)
// 		{
// 			if (area.IsRandom)
// 				return new TerrainSizeClass_AbstractSpecification(AbstractSpecificationSpecialValue.Random);
//
// 			TerrainSizeClass? sizeClass = terrainSizeClasses.FindByArea(area.Area);
//
// 			return sizeClass != null
// 				? new TerrainSizeClass_AbstractSpecification(sizeClass)
// 				: new TerrainSizeClass_AbstractSpecification(AbstractSpecificationSpecialValue.Custom);
// 		}
// 	}
//
//
//
// 	public class Area : ITerrainArea_AbstractSpecification
// 	{
// 		private readonly ValueOrRange<uint>? _area;
//
// 		public ValueOrRange<uint> Area {
// 			get {
// 				if (_area == null) throw new InvalidOperationException();
// 				return _area;
// 			}
// 		}
//
// 		public bool IsRandom { get; }
//
//
//
// 		public Area(ValueOrRange<uint> area)
// 		{
// 			_area = area;
// 		}
//
//
// 		public Area(AbstractSpecificationSpecialValue specialValue)
// 		{
// 			if (specialValue == AbstractSpecificationSpecialValue.Random)
// 				IsRandom = true;
// 			else
// 				throw new ArgumentOutOfRangeException(nameof(specialValue), specialValue, null);
// 		}
//
//
//
// 		protected internal static Stream<ITerrainArea_AbstractSpecification> Map(
// 			Stream<ITerrainSizeClass_AbstractSpecification> sSizeClass,
// 			Stream<ITerrainPlaneProjectionDimensions_AbstractSpecification?> sPlaneProjectionDimensions)
// 		{
// 			var sFromSizeClass = sSizeClass.Filter(_ => !_.IsCustom).Map(From_SizeClass);
// 			var sFromPlaneProjectionDimensions =
// 				sPlaneProjectionDimensions.Filter(_ => _ is { IsRandom: false }).Map(From_PlaneProjectionDimensions);
//
// 			return sFromSizeClass.OrElse(sFromPlaneProjectionDimensions);
// 		}
//
//
//
// 		protected static ITerrainArea_AbstractSpecification From_SizeClass(
// 			ITerrainSizeClass_AbstractSpecification sizeClass)
// 		{
// 			if (sizeClass.IsCustom)
// 				throw new ArgumentException();
//
// 			if (sizeClass.IsRandom)
// 				return new Area(AbstractSpecificationSpecialValue.Random);
//
// 			return new Area(ValueOrRange.Of(sizeClass.Class.Area));
// 		}
//
//
// 		protected static ITerrainArea_AbstractSpecification From_PlaneProjectionDimensions(
// 			ITerrainPlaneProjectionDimensions_AbstractSpecification? dimensions)
// 		{
// 			if (dimensions == null)
// 				throw new ArgumentException();
// 			if (dimensions.IsRandom)
// 				throw new ArgumentException();
//
// 			var dim = dimensions.Dimensions;
//
// 			var area = dim.IsValue
// 				? ValueOrRange.Of(dim.Value.Area)
// 				: ValueOrRange.Of(dim.Range.Min.Area, dim.Range.Max.Area);
//
// 			return new Area(area);
// 		}
// 	}
// }
