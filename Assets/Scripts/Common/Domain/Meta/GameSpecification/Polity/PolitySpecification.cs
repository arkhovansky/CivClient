namespace Common.Domain.Meta.GameSpecification
{
	public interface IPolitySpecification
	{
		IPolityKindSpecification Kind { get; }

		PolityFullNameSpecification Name { get; }
	}



	public class PolitySpecification : IPolitySpecification
	{
		public IPolityKindSpecification Kind { get; set; }

		public PolityFullNameSpecification Name { get; set; }
	}
}
