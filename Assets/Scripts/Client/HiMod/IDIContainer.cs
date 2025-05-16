using System.Reflection;



namespace Client.HiMod
{
	public interface IDiContainer
	{
		bool CanResolve(ParameterInfo parameter);

		object Resolve(ParameterInfo parameter);
	}



	public interface IDiContainerManagement
	{
		void Register(object instance);
	}
}
