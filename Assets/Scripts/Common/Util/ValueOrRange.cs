using System;



namespace Common.Util
{
	public struct ValueOrRange<T>
	{
		private readonly Range<T> _range;


		public bool IsValue => !IsRange;
		public bool IsRange { get; }

		public T Value {
			get {
				if (IsRange)
					throw new InvalidCastException(); //TODO

				return _range.Min;
			}
		}

		public Range<T> Range {
			get {
				if (!IsRange)
					throw new InvalidCastException(); //TODO

				return _range;
			}
		}


		public ValueOrRange(T value) {
			IsRange = false;
			_range.Min = value;
			_range.Max = default;
		}

		public ValueOrRange(T min, T max) {
			IsRange = true;
			_range.Min = min;
			_range.Max = max;
		}

		public ValueOrRange(Range<T> range) {
			IsRange = true;
			_range = range;
		}
	}



	public static class ValueOrRange
	{
		public static ValueOrRange<T> Of<T>(T value)
			=> new ValueOrRange<T>(value);

		public static ValueOrRange<T> Of<T>(T min, T max)
			=> new ValueOrRange<T>(min, max);

		public static ValueOrRange<T> Of<T>(Range<T> range)
			=> new ValueOrRange<T>(range);
	}
}
