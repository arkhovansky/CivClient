// using GeoGrid.Grid;
// using UnityEngine;
//
//
//
// namespace GeoGrid.Map
// {
// 	public class Class1SphericalHexGridMap
// 	{
// 		struct CellMap
// 		{
// 			public Vector3 faceCenter;
//
// 			public Vector3 vertex1, vertex2;
// 		}
//
//
//
// 		GeodesicGridData<CellMap> grid;
//
//
//
// 		public Class1SphericalHexGridMap(Breakdown breakdown,
// 		                                 IVertexProjection vertexProjection)
// 		{
// 			uint nSubdivisions = breakdown.M - 1;
//
// 			var geodesicPolyhedron = new Class1GeodesicPolyhedron(nSubdivisions, vertexProjection);
// 			grid = GetDual(geodesicPolyhedron);
// 		}
// 	}
// }
