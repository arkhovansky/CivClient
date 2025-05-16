using Common.Domain.Meta.GameSpecification;



namespace Client.UI.Meta.Common.Interface
{
	public interface IPolityVM
	{
		IPolitySpecification Polity { get; }
	}



	public interface IPolityVMFactory
	{
		IPolityVM Create(IPolitySpecification politySpec);
	}
}
