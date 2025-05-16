// using GeoGrid.Grid;
// using UnityEngine;
//
//
//
// namespace GeoGrid.Map
// {
// 	public class Class1GeodesicPolyhedron
// 	{
// 		uint frequency;
//
// 		IVertexProjection vertexProjection;
//
// 		GeodesicGridData<Vector3> grid;
//
//
//
// 		public Class1GeodesicPolyhedron(uint frequency, IVertexProjection vertexProjection)
// 		{
// 			this.frequency = frequency;
// 			this.vertexProjection = vertexProjection;
//
//
//
// 			grid = new GeodesicGridData<Vector3>(frequency);
// 			var icosahedronPoints = grid.BaseIcosahedronPoints;
//
// 			const float tao = 1.61803399F;
// 			grid[Point(5, 0, 0)] = new Vector3(1, tao, 0);
// 			grid[Point(0, 0, 0)] = new Vector3(0, 1, -tao);
// 			grid[Point(0, frequency, 0)] = new Vector3(0, -1, -tao);
// 			grid[Point(1, 0, 0)] = new Vector3(tao, 0, -1);
// 			grid[Point(1, frequency, 0)] = new Vector3(1, -tao, 0);
// 			grid[Point(2, 0, 0)] = new Vector3(tao, 0, 1);
// 			grid[Point(2, frequency, 0)] = new Vector3(0, -1, tao);
// 			grid[Point(3, 0, 0)] = new Vector3(0, 1, tao);
// 			grid[Point(3, frequency, 0)] = new Vector3(-tao, 0, 1);
// 			grid[Point(4, 0, 0)] = new Vector3(-1, tao, 0);
// 			grid[Point(4, frequency, 0)] = new Vector3(-tao, 0, -1);
// 			grid[Point(5, 0, 1)] = new Vector3(-1, -tao, 0);
//
// 			var rotation = Quaternion.FromToRotation(grid[Point(5, 0, 0)], Vector3.up);
//
// 			foreach (var point in icosahedronPoints) {
// 				grid[point] = (rotation * grid[point]).normalized;
// 			}
//
//
// 			for (uint chart = 0; chart < 5; ++chart) {
// 				BreakDownFace1(chart, 0);
// 				BreakDownFace2(chart, 0);
// 				BreakDownFace1(chart, 1);
// 				BreakDownFace2(chart, 1);
// 			}
// 		}
//
//
//
// 		void BreakDownFace1(uint chart, uint chunk) {
// 			uint baseX = chunk * frequency;
//
// 			var vX = grid[Point(chart, baseX + frequency, frequency)];
// 			var vY = grid[Point(chart, baseX, 0)];
// 			var vZ = grid[Point(chart, baseX, frequency)];
//
// 			for (uint y = 1; y < frequency; ++y) {
// 				for (uint x = baseX; x <= baseX + y; ++x) {
// 					var bX = (float) x / frequency;
// 					var bY = (float) y / frequency;
// 					//var bZ = 1 - bX - bY;
//
// 					grid[Point(chart, x, y)] = vertexProjection.project(vX, vY, vZ, bX, bY);
// 				}
// 			}
// 		}
//
//
//
// 		void BreakDownFace2(uint chart, uint chunk) {
// 			uint baseX = chunk * frequency;
//
// 			var vX = grid[Point(chart, baseX, 0)];
// 			var vY = grid[Point(chart, baseX + frequency, frequency)];
// 			var vZ = grid[Point(chart, baseX + frequency, 0)];
//
// 			for (uint y = 1; y < frequency; ++y) {
// 				for (uint x = baseX; x <= baseX + y; ++x) {
// 					var bX = (float) x / frequency;
// 					var bY = (float) y / frequency;
// 					//var bZ = 1 - bX - bY;
//
// 					grid[Point(chart, x, y)] = vertexProjection.project(vX, vY, vZ, bX, bY);
// 				}
// 			}
// 		}
//
//
//
// 		void DivideY(uint chart, uint x, uint y1, uint y2) {
// 			var v1 = grid[Point(chart, x, y1)];
// 			var v2 = grid[Point(chart, x, y2)];
//
// 			for (uint y = 1; y < frequency; ++y) {
// 				grid[Point(chart, x, y)] = vertexProjection.project()
// 			}
// 	}
// }
