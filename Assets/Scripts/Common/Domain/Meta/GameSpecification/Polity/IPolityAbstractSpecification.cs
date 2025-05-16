using System.Drawing;



namespace Common.Domain.Meta.GameSpecification
{
	public interface IPolityAbstractSpecification
	{
		uint Id { get; }

		IPolityKindAbstractSpecification Kind { get; }

		PolityFullNameSpecification Name { get; }

		//TODO: does belong here?
		Color? Color { get; }
	}
}
