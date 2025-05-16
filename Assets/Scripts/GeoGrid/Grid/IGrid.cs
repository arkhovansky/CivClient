using System.Collections.Generic;



namespace GeoGrid.Grid
{
	public interface IGrid
	{
		Breakdown Breakdown { get; }

		uint CellCount { get; }

		IEnumerator<Point> Points { get; }
	}
}
