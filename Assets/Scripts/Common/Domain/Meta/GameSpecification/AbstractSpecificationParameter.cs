using Sodium.Frp;



namespace Common.Domain.Meta.GameSpecification
{
	/// <summary>
	/// | IsExplicitlySet | IsFixed | IsProtected |
	/// |-----------------|---------|-------------|
	/// | true            | true    | true        | Explicit + clear protected + set protected on derived + set protected
	/// | true            | true    | false       | Explicit + clear protected + set protected on derived
	/// | true            | false   | true        | After explicit update
	/// | true            | false   | false       | After explicit update + clear protected
	/// | false           | true    | true        | Derived + set protected
	/// | false           | true    | false       | Derived
	/// | false           | false   | true        | Derived + clear protected on some of the explicit + set protected
	/// | false           | false   | false       | Derived + clear protected on some of the explicit
	/// </summary>
	public struct AbstractSpecificationParameterState
	{
		public bool IsExplicitlySet { get; }
		public bool IsDerived => !IsExplicitlySet;

		/// <summary>
		/// Is protected from explicit change.
		/// In UI this corresponds to disabled field.
		/// </summary>
		public bool IsFixed { get; }

		/// <summary>
		/// Is protected from implicit change.
		/// </summary>
		public bool IsProtected { get; }



		public AbstractSpecificationParameterState(bool isExplicitlySet, bool isFixed, bool isProtected)
		{
			IsExplicitlySet = isExplicitlySet;
			IsFixed = isFixed;
			IsProtected = isProtected;
		}
	}



	public struct AbstractSpecificationParameter<TValue>
	{
		public Cell<TValue> Value { get; }

		public Cell<AbstractSpecificationParameterState> State { get; }



		public AbstractSpecificationParameter(Cell<TValue> value, Cell<AbstractSpecificationParameterState> state)
		{
			Value = value;
			State = state;
		}
	}
}
