namespace Common.Domain.Meta.GameSpecification
{
	public interface IPolityFullNameSpecification
	{
		IPolityBaseNameSpecification BaseName { get; }

		IPolityNameQualifier? Qualifier { get; }
	}



	public class PolityFullNameSpecification : IPolityFullNameSpecification
	{
		public IPolityBaseNameSpecification BaseName { get; }

		public IPolityNameQualifier? Qualifier { get; }



		public PolityFullNameSpecification(IPolityBaseNameSpecification baseName, IPolityNameQualifier? qualifier)
		{
			BaseName = baseName;
			Qualifier = qualifier;
		}
	}
}
