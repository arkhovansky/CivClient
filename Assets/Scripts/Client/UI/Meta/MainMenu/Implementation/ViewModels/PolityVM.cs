using Client.UI.Meta.Common.Interface;
using Common.Domain.Meta.GameSpecification;



namespace Client.UI.Meta.MainMenu.Implementation.ViewModels
{
	public class PolityVM : IPolityVM
	{
		public IPolitySpecification Polity { get; }



		public PolityVM(IPolitySpecification polity)
		{
			Polity = polity;
		}
	}
}
