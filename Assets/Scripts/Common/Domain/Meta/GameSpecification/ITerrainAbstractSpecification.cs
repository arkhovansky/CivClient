using System.Collections.Generic;
using Common.Domain.Meta.GameSpecification.Util;
using Common.Util;
using Sodium.Frp;



namespace Common.Domain.Meta.GameSpecification
{
	public interface ITerrainPlaneProjectionAspectRatio_AbstractSpecification
		: IMaybeRandom
	{
		float AspectRatio { get; }
	}


	public interface ITerrainPlaneProjectionAspectRatio_AbstractSpecification_Static
	{
		ITerrainPlaneProjectionAspectRatio_AbstractSpecification?
			Create(AbstractSpecificationSpecialValue specialValue);
	}



	public interface ITerrainShape { }


	public interface ITerrainShapeWithAspectRatio : ITerrainShape
	{
		ITerrainPlaneProjectionAspectRatio_AbstractSpecification AspectRatio { get; }
	}


	public class RectangleTerrainShape : ITerrainShapeWithAspectRatio
	{
		public ITerrainPlaneProjectionAspectRatio_AbstractSpecification AspectRatio { get; }
	}

	public class CylinderTerrainShape : ITerrainShapeWithAspectRatio
	{
		public ITerrainPlaneProjectionAspectRatio_AbstractSpecification AspectRatio { get; }
	}

	public class TorusTerrainShape : ITerrainShapeWithAspectRatio
	{
		public ITerrainPlaneProjectionAspectRatio_AbstractSpecification AspectRatio { get; }
	}

	public class SphereTerrainShape : ITerrainShape
	{
	}



	public interface ITerrainShapeWithAbstractParameters
	{
		ITerrainShape Shape { get; }

		// IDictionary<string, IParameter_AbstractSpecification> Parameters { get; }
	}



	public interface ITerrainShape_AbstractSpecification
		: IMaybeRandom
	{
		ITerrainShapeWithAbstractParameters Shape { get; }
	}



	public interface ITerrainShape_AbstractSpecification_Static
	{
		ITerrainShape_AbstractSpecification CreateDefault();

		Stream<ITerrainShape_AbstractSpecification> Map(
			Cell<ITerrainPlaneProjectionDimensions_AbstractSpecification?> planeProjectionDimensions,
			Cell<ITerrainShape_AbstractSpecification> shape);
	}




	public interface ITerrainArea_AbstractSpecification
		: IMaybeRandom
	{
		ValueOrRange<uint> Area { get; }
	}



	public interface ITerrainArea_AbstractSpecification_Static
	{
		ITerrainArea_AbstractSpecification CreateDefault();

		Stream<ITerrainArea_AbstractSpecification> Map(
			Cell<ITerrainPlaneProjectionDimensions_AbstractSpecification?> planeProjectionDimensions);
	}



	public interface ITerrainShapeSizeDerivedParameters_AbstractSpecification { }



	public struct TerrainPlaneProjectionDimensions
	{
		public uint Width { get; }
		public uint Height { get; }

		public uint Area => Width * Height;


		public TerrainPlaneProjectionDimensions(uint width, uint height) {
			Width = width;
			Height = height;
		}
	}


	public interface ITerrainPlaneProjectionDimensions_AbstractSpecification
		: IMaybeRandom
	{
		ValueOrRange<TerrainPlaneProjectionDimensions> Dimensions { get; }
	}



	public interface ITerrainPlaneProjectionDimensions_AbstractSpecification_Static
	{
		Stream<ITerrainPlaneProjectionDimensions_AbstractSpecification?> Map(
			Cell<ITerrainArea_AbstractSpecification> area,
			Cell<ITerrainPlaneProjectionAspectRatio_AbstractSpecification?> aspectRatio);
	}




	public interface ITerrainAbstractSpecification
	{
		Cell<ITerrainShape_AbstractSpecification> Shape { get; }

		Cell<ITerrainArea_AbstractSpecification> Area { get; }

		ITerrainShapeSizeDerivedParameters_AbstractSpecification? ShapeSizeDerivedParameters { get; }


		// Cell<ITerrainSizeClass_AbstractSpecification>? SizeClass { get; }
	}



	public interface ITerrainAbstractSpecificationFactory
	{
		ITerrainShape_AbstractSpecification_Static Shape { get; }

		ITerrainArea_AbstractSpecification_Static Area { get; }

		ITerrainPlaneProjectionDimensions_AbstractSpecification_Static
			PlaneProjectionDimensions { get; }

		ITerrainPlaneProjectionAspectRatio_AbstractSpecification_Static
			PlaneProjectionAspectRatio { get; }
	}
}
