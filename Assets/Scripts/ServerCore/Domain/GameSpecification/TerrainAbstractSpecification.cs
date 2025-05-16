// using System;
// using System.Collections.Generic;
// using Common.Domain.Meta.GameSpecification;
// using Common.Domain.Meta.GameSpecification.Util;
// using Common.Util;
// using Sodium.Frp;
//
//
//
// namespace ServerCore.Domain.GameSpecification
// {
// 	public class TerrainAbstractSpecification : ITerrainAbstractSpecification
// 	{
// 		public Cell<ITerrainShape_AbstractSpecification> Shape => shape;
//
// 		public AbstractSpecificationParameter<ITerrainArea_AbstractSpecification> Area { get; }
//
// 		// ITerrainShapeSizeDerivedParameters_AbstractSpecification? ShapeSizeDerivedParameters { get; protected set; }
//
// 		// public Cell<ITerrainSizeClass_AbstractSpecification>? SizeClass => sizeClassSink;
//
//
//
// 		protected readonly ITerrainAbstractSpecificationFactory factory;
//
// 		protected readonly CellLoop<ITerrainShape_AbstractSpecification> shape;
// 		protected readonly StreamSink<ITerrainShape_AbstractSpecification> sShapeSink;
//
// 		protected readonly StreamSink<ITerrainArea_AbstractSpecification> sAreaSink;
// 		protected readonly StreamSink<bool> sAreaProtectedSink;
// 		protected readonly Cell<bool> areaProtected;
//
// 		// protected readonly CellSink<ITerrainSizeClass_AbstractSpecification>? sizeClassSink;
//
//
//
// 		public TerrainAbstractSpecification(
// 			AbstractSpecificationParameter<IPolityCount_AbstractSpecification> polityCount,
// 			AbstractSpecificationParameter<IPerPolitySpace_AbstractSpecification> perPolitySpace,
// 			// ITerrainClassifier terrainClassifier,
// 			ITerrainAbstractSpecificationFactory factory)
// 		{
// 			this.factory = factory;
//
//
// 			shape = Cell.CreateLoop<ITerrainShape_AbstractSpecification>();
// 			// dimensions = Cell.CreateLoop<ITerrainPlaneProjectionDimensions_AbstractSpecification?>();
// 			// aspectRatio = Cell.CreateLoop<ITerrainPlaneProjectionAspectRatio_AbstractSpecification?>();
//
// 			sShapeSink = Stream.CreateSink<ITerrainShape_AbstractSpecification>();
// 			// var sShapeFromMembers = factory.Shape.Map(aspectRatio.Updates(), shape);
// 			shape.Loop(sShapeSink/*.OrElse(sShapeFromMembers)*/.Hold(factory.Shape.CreateDefault()));
//
//
// 			sAreaSink = Stream.CreateSink<ITerrainArea_AbstractSpecification>();
// 			var sAreaFromPolityCountAndSpace = factory.Area.Map(polityCount.Value, perPolitySpace.Value);
// 			var sAreaDerived = sAreaFromPolityCountAndSpace;
// 			var area = sAreaSink.OrElse(sAreaDerived).Hold(factory.Area.CreateDefault());
//
// 			sAreaProtectedSink = Stream.CreateSink<bool>();
// 			Cell<AbstractSpecificationParameterState> areaState;
// 			{
// 				var sExplicitlySetFromExplicit = sAreaSink.MapTo(true);
// 				var sExplicitlySetFromDerived = sAreaDerived.MapTo(false);
// 				var sExplicitlySet = sExplicitlySetFromExplicit.OrElse(sExplicitlySetFromDerived);
// 				var isExplicitlySet = sExplicitlySet.Hold(false);
//
// 				var sProtectedFromExplicitUpdate = sAreaSink.MapTo(true);
// 				var sProtected = sAreaProtectedSink.OrElse(sProtectedFromExplicitUpdate);
// 				areaProtected = sProtected.Hold(false);
//
// 				var polityCount_Protected = polityCount.State.Map(_ => _.IsProtected);
// 				var perPolitySpace_Protected = perPolitySpace.State.Map(_ => _.IsProtected);
// 				Stream<(bool, bool)> sOtherProtected =
// 					SodiumExtensions.CombineCurrentOrHeld(polityCount_Protected, perPolitySpace_Protected);
// 				var sFixed = sOtherProtected.Map(t => t.Item1 && t.Item2);
// 				var isFixed = sFixed.Hold(false);
//
// 				areaState = isExplicitlySet.Lift(areaProtected, isFixed,
// 				                                 (e, p, f) => new AbstractSpecificationParameterState(e, p, f));
// 			}
//
// 			Area = new AbstractSpecificationParameter<ITerrainArea_AbstractSpecification>(area, areaState);
//
//
// 			// sDimensionsSink = Stream.CreateSink<ITerrainPlaneProjectionDimensions_AbstractSpecification?>();
// 			// var sDimensionsFromMembers = factory.PlaneProjectionDimensions.Map(Area, aspectRatio);
// 			// dimensions.Loop(sDimensionsSink.OrElse(sDimensionsFromMembers).Hold(null));
// 			//
// 			// var sAspectRatioFromShape = shape.Updates().Map(AspectRatioFromShape);
// 			// var sAspectRatioFromDimensions = factory.PlaneProjectionAspectRatio.Map(dimensions.Updates());
// 			// aspectRatio.Loop(sAspectRatioFromShape.OrElse(sAspectRatioFromDimensions)
// 			// 	                 .Hold(factory.PlaneProjectionAspectRatio.CreateDefault()));
//
// 			// sizeClassSink = terrainClassifier.MapSizeClass(Area);
// 		}
//
//
//
// 		public void SetShape(ITerrainShape_AbstractSpecification newShapeSpec)
// 		{
// 			var curShapeSpec = Shape.Sample();
//
// 			if (newShapeSpec.Equals(curShapeSpec))
// 				return;
//
// 			if (newShapeSpec.IsRandom) {
// 				sShapeSink.Send(newShapeSpec);
// 				return;
// 			}
//
// 			ITerrainShapeWithAbstractParameters curShapeWithParams = curShapeSpec.ShapeWithAbstractParameters;
// 			ITerrainShapeWithAbstractParameters newShapeWithParams = newShapeSpec.ShapeWithAbstractParameters;
//
// 			if (newShapeWithParams.Shape == curShapeWithParams.Shape) {
// 				IReadOnlyList<string> updatedFixedParams =
// 					AbstractSpecificationParameters.GetUpdatedFixedParameters(
// 						newShapeWithParams.Parameters, curShapeWithParams.Parameters);
//
// 				if (updatedFixedParams.Count > 0)
// 					throw new FixedParameterUpdateError(updatedFixedParams);
// 			}
//
// 			sShapeSink.Send(newShapeSpec);
//
//
// 			// ShapeSizeDerivedParameters = newShapeSpec.Definite?.Shape.CreateShapeSizeDerivedParameters();
// 			//
// 			// if (ShapeSizeDerivedParameters != null) {
// 			// 	ShapeSizeDerivedParameters
// 			// }
// 		}
//
//
//
// 		public void SetArea(ITerrainArea_AbstractSpecification newAreaSpec)
// 		{
// 			var curAreaSpec = Area.Value.Sample();
// 			var curAreaState = Area.State.Sample();
//
// 			if (newAreaSpec.Equals(curAreaSpec))
// 				return;
//
// 			if (curAreaState.IsFixed)
// 				throw new FixedParameterUpdateError(k_SpecificationParameter_TerrainArea);
//
// 			sAreaSink.Send(newAreaSpec);
// 		}
//
//
//
// 		public void SetAreaIsProtected(bool isProtected)
// 		{
// 			if (isProtected == areaProtected.Sample())
// 				return;
//
// 			sAreaProtectedSink.Send(isProtected);
// 		}
//
//
//
// 		protected ITerrainPlaneProjectionAspectRatio_AbstractSpecification? AspectRatioFromShape(
// 			ITerrainShape_AbstractSpecification shape)
// 		{
// 			if (shape.IsRandom) {
// 				return factory.PlaneProjectionAspectRatio.Create(
// 					AbstractSpecificationSpecialValue.Random);
// 			}
//
// 			if (shape.Shape is ITerrainShapeWithAspectRatio arShape)
// 				return arShape.AspectRatio;
//
// 			return null;
// 		}
// 	}
//
//
//
// 	public class TerrainShape_AbstractSpecification : ITerrainShape_AbstractSpecification
// 	{
// 		private readonly ValueOrRange<uint>? _area;
//
// 		public ValueOrRange<uint> Area {
// 			get {
// 				if (_area == null) throw new InvalidOperationException();
//
// 				return _area;
// 			}
// 		}
//
// 		public bool IsRandom { get; }
//
//
//
// 		public TerrainShape_AbstractSpecification(ValueOrRange<uint> area)
// 		{
// 			_area = area;
// 		}
//
//
// 		public TerrainShape_AbstractSpecification(AbstractSpecificationSpecialValue specialValue)
// 		{
// 			if (specialValue == AbstractSpecificationSpecialValue.Random)
// 				IsRandom = true;
// 			else
// 				throw new ArgumentOutOfRangeException(nameof(specialValue), specialValue, null);
// 		}
// 	}
//
//
//
// 	public class TerrainShape_AbstractSpecification_Static : ITerrainShape_AbstractSpecification_Static
// 	{
// 		public ITerrainShape_AbstractSpecification CreateDefault()
// 			=> new TerrainShape_AbstractSpecification(AbstractSpecificationSpecialValue.Random);
//
//
//
// 		public Stream<ITerrainShape_AbstractSpecification> Map(
// 			Stream<ITerrainPlaneProjectionAspectRatio_AbstractSpecification?> sAspectRatio,
// 			Cell<ITerrainShape_AbstractSpecification> cShape)
// 		{
// 			return sAspectRatio.Filter(_ => _ != null).Snapshot(cShape, (aspectRatio, shape) => {
// 				if (!shape.IsRandom && shape.Shape is ITerrainShapeWithAspectRatio arShape)
// 					return arShape.WithAspectRatio(aspectRatio);
// 				else  // Should not happen
// 					return shape;
// 			}).Calm();
// 		}
// 	}
//
//
//
// 	public class TerrainArea_AbstractSpecification : ITerrainArea_AbstractSpecification
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
// 		public TerrainArea_AbstractSpecification(ValueOrRange<uint> area)
// 		{
// 			_area = area;
// 		}
//
//
// 		public TerrainArea_AbstractSpecification(AbstractSpecificationSpecialValue specialValue)
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
// 			Cell<ITerrainPlaneProjectionDimensions_AbstractSpecification?> planeProjectionDimensions)
// 		{
// 			return planeProjectionDimensions.Updates()
// 				.Filter(_ => _ is { IsRandom: false }).Map(From_PlaneProjectionDimensions);
// 		}
//
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
// 			return new TerrainArea_AbstractSpecification(area);
// 		}
// 	}
//
//
//
// 	public class PlaneProjectedTerrain_ShapeSizeParameters_AbstractSpecification
// 		: ITerrainShapeSizeDerivedParameters_AbstractSpecification
// 	{
// 		public Cell<ITerrainPlaneProjectionDimensions_AbstractSpecification?> PlaneProjectionDimensions
// 			=> dimensions;
//
//
//
// 		protected readonly CellLoop<ITerrainPlaneProjectionDimensions_AbstractSpecification?> dimensions;
// 		protected readonly StreamSink<ITerrainPlaneProjectionDimensions_AbstractSpecification?> sDimensionsSink;
//
// 		protected readonly CellLoop<ITerrainPlaneProjectionAspectRatio_AbstractSpecification?> aspectRatio;
//
//
//
// 		protected internal PlaneProjectedTerrain_ShapeSizeParameters_AbstractSpecification(
// 			Cell<ITerrainShape_AbstractSpecification> cShape,
// 			Cell<ITerrainArea_AbstractSpecification> cArea)
// 		{
//
// 		}
// 	}
//
//
//
// 	public class TerrainPlaneProjectionDimensions_AbstractSpecification
// 		: ITerrainPlaneProjectionDimensions_AbstractSpecification
// 	{
// 		private readonly ValueOrRange<TerrainPlaneProjectionDimensions>? _dimensions;
//
// 		public ValueOrRange<TerrainPlaneProjectionDimensions> Dimensions {
// 			get {
// 				if (_dimensions == null) throw new InvalidOperationException();
//
// 				return _dimensions.Value;
// 			}
// 		}
//
//
// 		public bool IsRandom { get; }
//
//
//
// 		protected internal TerrainPlaneProjectionDimensions_AbstractSpecification(
// 			ValueOrRange<TerrainPlaneProjectionDimensions> dimensions)
// 		{
// 			_dimensions = dimensions;
// 		}
//
//
// 		protected internal TerrainPlaneProjectionDimensions_AbstractSpecification(
// 			AbstractSpecificationSpecialValue specialValue)
// 		{
// 			if (specialValue == AbstractSpecificationSpecialValue.Random)
// 				IsRandom = true;
// 			else
// 				throw new ArgumentOutOfRangeException(nameof(specialValue), specialValue, null);
// 		}
//
//
//
// 		protected internal static Stream<ITerrainPlaneProjectionDimensions_AbstractSpecification?> Map(
// 			Cell<ITerrainArea_AbstractSpecification> area,
// 			Cell<ITerrainPlaneProjectionAspectRatio_AbstractSpecification?> aspectRatio)
// 		{
// 			var sFromArea = area.Updates().Snapshot(aspectRatio, From_AreaAndAspectRatio);
// 			var sFromAspectRatio = aspectRatio.Updates().Snapshot(area, From_AspectRatioAndArea);
//
// 			return sFromArea.OrElse(sFromAspectRatio);
// 		}
//
//
//
// 		protected static ITerrainPlaneProjectionDimensions_AbstractSpecification? From_AreaAndAspectRatio(
// 			ITerrainArea_AbstractSpecification areaSpec,
// 			ITerrainPlaneProjectionAspectRatio_AbstractSpecification? aspectRatio)
// 		{
// 			if (aspectRatio == null)
// 				return null;
//
// 			if (areaSpec.IsRandom)
// 				return new TerrainPlaneProjectionDimensions_AbstractSpecification(
// 					AbstractSpecificationSpecialValue.Random);
//
// 			var area = areaSpec.Area;
//
// 			var dimensions = area.IsValue
// 				? ValueOrRange.Of(CalcDimensions(area.Value, aspectRatio.AspectRatio))
// 				: ValueOrRange.Of(CalcDimensions(area.Range, aspectRatio.AspectRatio));
//
// 			return new TerrainPlaneProjectionDimensions_AbstractSpecification(dimensions);
// 		}
//
//
// 		protected static ITerrainPlaneProjectionDimensions_AbstractSpecification? From_AspectRatioAndArea(
// 			ITerrainPlaneProjectionAspectRatio_AbstractSpecification? aspectRatio,
// 			ITerrainArea_AbstractSpecification areaSpec)
// 		{
// 			return From_AreaAndAspectRatio(areaSpec, aspectRatio);
// 		}
//
//
//
// 		protected static TerrainPlaneProjectionDimensions CalcDimensions(uint area, float aspectRatio)
// 		{
// 			uint width = (uint) Math.Round(Math.Sqrt(area * aspectRatio));
// 			uint height = (uint) Math.Round(Math.Sqrt(area / aspectRatio));
//
// 			return new TerrainPlaneProjectionDimensions(width, height);
// 		}
//
// 		protected static Range<TerrainPlaneProjectionDimensions> CalcDimensions(Range<uint> area, float aspectRatio)
// 		{
// 			uint minWidth = (uint) Math.Ceiling(Math.Sqrt(area.Min * aspectRatio));
// 			uint minHeight = (uint) Math.Ceiling(Math.Sqrt(area.Min / aspectRatio));
// 			uint maxWidth = (uint) Math.Floor(Math.Sqrt(area.Max * aspectRatio));
// 			uint maxHeight = (uint) Math.Floor(Math.Sqrt(area.Max / aspectRatio));
//
// 			return Common.Util.Range.Of(new TerrainPlaneProjectionDimensions(minWidth, minHeight),
// 			                            new TerrainPlaneProjectionDimensions(maxWidth, maxHeight));
// 		}
// 	}
// }
