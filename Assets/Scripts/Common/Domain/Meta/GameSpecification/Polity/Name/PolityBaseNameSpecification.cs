namespace Common.Domain.Meta.GameSpecification
{
	public interface IPolityBaseNameSpecification
	{
	}



	public class CustomName_PolityBaseNameSpecification : IPolityBaseNameSpecification
	{
		public string CustomName { get; }


		public CustomName_PolityBaseNameSpecification(string customName)
		{
			CustomName = customName;
		}
	}



	public class PresetName_PolityBaseNameSpecification : IPolityBaseNameSpecification
	{
		public IPolityNameQualifier NameQualifier { get; }


		public PresetName_PolityBaseNameSpecification(IPolityNameQualifier qualifier)
		{
			NameQualifier = qualifier;
		}
	}
}
