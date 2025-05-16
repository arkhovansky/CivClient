using System;



namespace Common.Util
{
	public static class MaybeRandom
	{
		public static MaybeRandom<T> Of<T>(T value)
		{
			return new MaybeRandom<T>(value);
		}
	}




	public struct MaybeRandom<T>
	{
		private bool _isExact;
		private T? _value;


		public bool IsExact => _isExact;
		public bool IsRandom => !IsExact;

		public T ExactValue {
			get {
				if (IsRandom)
					throw new NoExactValueException();
				return _value!;
			}
		}


		public static MaybeRandom<T> Random { get; } = new();



		// private MaybeRandom()
		// {
		// 	_isExact = false;
		// }


		public MaybeRandom(T value)
		{
			_isExact = true;
			_value = value;
		}
	}



	public class NoExactValueException : Exception { }
}
