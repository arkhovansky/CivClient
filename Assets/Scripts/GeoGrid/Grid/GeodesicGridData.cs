// using System.Collections;
// using System.Collections.Generic;
//
//
//
// namespace GeoGrid.Grid
// {
// 	public class GeodesicGridData<Cell> : IGrid
// 	{
// 		private struct InternalCellData
// 		{
// 			public SphericPoint center;
// 			public SphericPoint vertex;
//
// 			public bool isPentagonCenter;
// 		}
//
//
//
// 		class CellsEnumerable : IEnumerable<Cell>
// 		{
// 			public CellsEnumerable(GeodesicGridData<Cell> grid) {
// 				this.grid = grid;
// 			}
//
//
// 			public IEnumerator<Cell> GetEnumerator() {
// 				return new CellsEnumerator(grid);
// 			}
//
// 			IEnumerator IEnumerable.GetEnumerator() {
// 				return GetEnumerator();
// 			}
//
//
// 			GeodesicGridData<Cell> grid;
// 		}
//
//
//
// 		class CellsEnumerator : IEnumerator<Cell>
// 		{
// 			public Cell Current {
// 				get {
// 					return new Cell {
// 						IsPentagon = grid.IsPentagon(point),
// 						Data = grid.data[point.X, point.Y]
// 					};
// 				}
// 			}
//
// 			object IEnumerator.Current {
// 				get {
// 					return Current;
// 				}
// 			}
//
// 			public bool MoveNext() {
// 				if (point.Index == grid.CellCount)
// 					return false;
//
// 				point.Index++;
// 				return true;
// 			}
//
// 			public void Reset() {
// 				point = new Point(0);
// 			}
//
// 			public void Dispose() {}
//
//
//
// 			public CellsEnumerator(GeodesicGridData<Cell> grid) {
// 				this.grid = grid;
//
// 				Reset();
// 			}
//
//
//
// 			GeodesicGridData<Cell> grid;
//
// 			Point point;
// 		}
//
//
//
// 		public IEnumerable<Cell> Cells => new CellsEnumerable(this);
//
//
// 		public Breakdown Breakdown { get; }
//
// 		public uint CellCount { get; }
//
//
//
// 		private Cell[,,] _data;
//
// 		private InternalCellData[,,] _vertexData;
//
// 		private SphericPoint _northPole;
// 		private SphericPoint _southPole;
//
// 		// uint chartSize;
//
//
//
// 		public GeodesicGridData(uint subdivisionCount)
// 			: this(new Breakdown(subdivisionCount + 1, 0))
// 		{}
//
//
// 		private GeodesicGridData(Breakdown breakdown) {
// 			Breakdown = breakdown;
//
// 			_data = new Cell[2 * Breakdown.M, 2 * Breakdown.M, 5];
// 			_vertexData = new InternalCellData[2 * Breakdown.M, 2 * Breakdown.M, 5];
// 			// _northPoleVertexData =
//
// 			// chartSize = 2 * Breakdown.M * Breakdown.M;
// 			CellCount = GetCellCount(Breakdown);
// 		}
//
//
// 		public GeodesicGridData(IGrid grid)
// 			: this(grid.Breakdown)
// 		{}
//
//
//
// 		bool IsPentagon(Point point) {
// 			if (point.chart == 5) {
// 				return true;
// 			}
// 			else {
// 				return point.x == 0 && (point.y == 0 || point.y == Breakdown.M);
// 			}
// 		}
//
//
//
// 		static uint GetCellCount(Breakdown breakdown) {
// 			uint T = breakdown.M*breakdown.M + breakdown.M*breakdown.N + breakdown.N*breakdown.N;
// 			return 10*T + 2;
// 		}
//
//
//
// 		//ArrayIndex ArrayIndexFrom(Point point) {
// 		//	ArrayIndex arrayIndex;
//
// 		//	arrayIndex.Chart = point.Index / chartSize;
//
// 		//	var indexInChart = point.Index % chartSize;
// 		//	arrayIndex.Y = indexInChart / (2 * GP.M);
// 		//	arrayIndex.X = indexInChart % (2 * GP.M);
//
// 		//	return arrayIndex;
// 		//}
// 	}
// }
