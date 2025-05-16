namespace Common.Domain.Meta.GameSpecification
{
	public interface IGameSideNameQualifierFormatter
	{
		string Format(IPolityNameQualifier qualifier);
	}



	public interface IGameSideNameQualifierFormatter<TQualifier> : IGameSideNameQualifierFormatter
		where TQualifier : IPolityNameQualifier
	{
		string Format(TQualifier qualifier);
	}



	public class NumeroSign_GameSideNameQualifierFormatter
		: IGameSideNameQualifierFormatter //<Number_PolityNameQualifier>
	{
		public string Format(IPolityNameQualifier qualifier)
		{
			return Format((Number_PolityNameQualifier)qualifier);
		}


		public string Format(Number_PolityNameQualifier qualifier)
		{
			return $"№{qualifier.Number}";
		}
	}
}
