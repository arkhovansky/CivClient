namespace Common.Util
{
	public struct Range<T>
	{
		public T Min;
		public T Max;


		public Range(T min, T max)
		{
			this.Min = min;
			this.Max = max;
		}
	}



	public static class Range
	{
		public static Range<T> Of<T>(T min, T max)
			=> new Range<T>(min, max);
	}
}
