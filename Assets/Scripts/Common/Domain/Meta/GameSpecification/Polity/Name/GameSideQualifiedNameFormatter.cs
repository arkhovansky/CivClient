namespace Common.Domain.Meta.GameSpecification
{
	public interface IGameSideQualifiedNameFormatter
	{
		string Format(string unqualifiedName, string qualifier);
	}



	public class Prefix_GameSideQualifiedNameFormatter : IGameSideQualifiedNameFormatter
	{
		public string Format(string unqualifiedName, string qualifier)
		{
			//TODO i18n
			return $"{qualifier} {unqualifiedName}";
		}
	}



	public class Postfix_GameSideQualifiedNameFormatter : IGameSideQualifiedNameFormatter
	{
		public string Format(string unqualifiedName, string qualifier)
		{
			//TODO i18n
			return $"{unqualifiedName} {qualifier}";
		}
	}



	public class ParenthesisedPostfix_GameSideQualifiedNameFormatter : IGameSideQualifiedNameFormatter
	{
		public string Format(string unqualifiedName, string qualifier)
		{
			//TODO i18n
			return $"{unqualifiedName} ({qualifier})";
		}
	}
}
