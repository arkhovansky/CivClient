using System;
using Sodium.Frp;



namespace Common.Util
{
	public static class SodiumExtensions
	{
		public static Stream<(T, T)> CombineCurrentOrHeld<T>(Cell<T> c1, Cell<T> c2)
		{
			return Combine2StreamsAndCells(c1.Updates(), c1, c2.Updates(), c2);
		}


		public static Stream<(T, T)> Combine2StreamsAndCells<T>(
			Stream<T> s1, Cell<T> c1, Stream<T> s2, Cell<T> c2)
		{
			var sTuples1 = s1.Map(x => new ValueTuple<T?, T?>(x, default));
			var sTuples2 = s2.Map(x => new ValueTuple<T?, T?>(default, x));
			var sCombinedStreams = sTuples1.Merge(sTuples2, (t1, t2) => {
				return (Merge(t1.Item1, t2.Item1),
				        Merge(t1.Item2, t2.Item2));
			});

			return sCombinedStreams.Snapshot(c1, c2, (t, cv1, cv2) => {
				return t.Item1 is not null && t.Item2 is not null ? ((T)t.Item1, (T)t.Item2) :
				       t.Item1 is not null ? ((T)t.Item1, cv2) :
				       (cv1, (T)t.Item2!);
			});
		}


		private static T? Merge<T>(T? a, T? b)
		{
			// One argument is null, other is not
			return a ?? b;
		}


		// private static T ValueOfMaybe<T>(T? notNull) where T : struct => notNull!.Value;
		// private static T ValueOfMaybe<T>(T? notNull) where T : class => notNull!;
	}
}
