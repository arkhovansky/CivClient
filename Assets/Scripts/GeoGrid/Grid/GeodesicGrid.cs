// using System.Collections;
// using System.Collections.Generic;
// using GeoGrid.Map;
//
//
//
// namespace GeoGrid.Grid
// {
// 	public class GeodesicGridCoordinateData : IGrid
// 	{
// 		public float Radius { get; }
//
// 		public Breakdown Breakdown { get; }
//
// 		public uint CellCount { get; }
//
//
//
// 		private struct Cell
// 		{
// 			public SphericPoint center;
// 			public SphericPoint vertex;
// 		}
//
//
//
// 		private GeodesicGridData<Cell> _data;
//
// 		private SphericPoint _northPole;
// 		private SphericPoint _southPole;
//
// 		// uint chartSize;
//
//
//
// 		public GeodesicGridCoordinateData(uint subdivisionCount, IVertexProjection vertexProjection, float radius = 1)
// 		{
// 			Radius = radius;
//
// 			_data = new GeodesicGridData<Cell>(subdivisionCount);
// 		}
//
//
//
// 	}
// }
