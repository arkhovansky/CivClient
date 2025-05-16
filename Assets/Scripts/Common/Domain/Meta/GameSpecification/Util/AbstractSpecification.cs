namespace Common.Domain.Meta.GameSpecification.Util
{
	public interface IMaybeRandom
	{
		bool IsRandom { get; }
	}



	public interface IMaybeCustom
	{
		bool IsCustom { get; }
	}



	public enum AbstractSpecificationSpecialValue
	{
		Random,
		Custom
	}
}
