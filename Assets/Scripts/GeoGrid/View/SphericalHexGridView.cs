// using System.Collections.Generic;
// using GeoGrid.Grid;
// using GeoGrid.Map;
// using UnityEngine;
//
//
//
// namespace GeoGrid.View
// {
// 	public class SphericalHexGridView
// 	{
// 		readonly IGrid grid;
//
// 		readonly GameObject root;
//
// 		Class1SphericalHexGridMap<Vector3> map;
//
// 		GeodesicGridData<TileCell> cells;
//
//
//
// 		public SphericalHexGridView(IGrid grid,
// 		                            Class1SphericalHexGridMap<Vector3> map,
// 		                            GameObject root)
// 		{
// 			this.grid = grid;
// 			this.map = map;
// 			this.root = root;
//
// 			cells = new GeodesicGridData<TileCell>(grid);
//
// 			Build();
// 		}
//
//
//
// 		void Build() {
// 			foreach (var point in grid.Points) {
// 				var cell = InstantiateCell(point);
//
// 				Vector3 worldPoint = map[point];
//
// 				cell.transform.parent = root.transform;
// 				cell.transform.localScale = Vector3.one;
// 				cell.transform.localPosition = worldPoint;
//
// 				cells[point] = cell;
// 			}
//
// 		}
// 	}
// }
