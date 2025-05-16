using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;



namespace Client.HiMod.Implementation
{
	public class DiContainer : IDiContainerManagement, IDiContainer
	{
		protected readonly List<IParameterBinding> parameterBindings = new();



		public void Register(object instance)
		{
			parameterBindings.Add(new Parameter(instance));
		}



		public bool CanResolve(ParameterInfo parameter)
		{
			return parameterBindings.Any(binding => binding.ParameterSpecification.IsSatisfiedBy(parameter));
		}


		public object Resolve(ParameterInfo parameter)
		{
			var binding = parameterBindings
				.FirstOrDefault(binding => binding.ParameterSpecification.IsSatisfiedBy(parameter));

			if (binding == null)
				throw new Exception(); //TODO

			return binding.Value;
		}
	}
}
