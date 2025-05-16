namespace Common.Domain.Meta.GameSpecification
{
	public interface IPolityNameQualifier
	{
	}



	public class Number_PolityNameQualifier : IPolityNameQualifier
	{
		public uint Number { get; }


		public Number_PolityNameQualifier(uint number)
		{
			Number = number;
		}
	}



	public class Color_PolityNameQualifier : IPolityNameQualifier
	{
		public string ColorName { get; }


		public Color_PolityNameQualifier(string colorName)
		{
			ColorName = colorName;
		}
	}
}
