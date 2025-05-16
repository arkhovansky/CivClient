using System;
using System.Collections.Generic;
using System.Reflection;



namespace Client.HiMod
{
	public interface IParameterSpecification
	{
		bool IsSatisfiedBy(ParameterInfo parameter);
	}



	public record TypeParameterSpecification(
			Type Type)
		: IParameterSpecification
	{
		public bool IsSatisfiedBy(ParameterInfo parameter) {
			return parameter.ParameterType.IsAssignableFrom(Type);
		}
	}



	public interface IParameterBinding
	{
		IParameterSpecification ParameterSpecification { get; }

		object Value { get; }
	}



	public struct Parameter : IParameterBinding
	{
		public IParameterSpecification ParameterSpecification { get; }

		public object Value { get; }


		public Parameter(object value)
		{
			ParameterSpecification = new TypeParameterSpecification(value.GetType());
			Value = value;
		}
	}



	// public struct Parameter<T> : IParameterBinding
	// {
	// 	public IParameterSpecification ParameterSpecification { get; }
	//
	// 	public object Value { get; }
	//
	//
	// 	public Parameter(object value)
	// 	{
	// 		ParameterSpecification = new TypeParameterSpecification(typeof(T));
	// 		Value = value;
	// 	}
	// }



	public interface IComponentResolver
	{
		IComponentResolver CopyWithContext(IComponentEntity? subjectEntityContext = null,
		                                   IComponentContext? context = null);


		T Resolve<T>(IComponentSpecification spec);

		T Resolve<T>(IComponentSpecification spec, IParameterBinding parameterBinding);

		T Resolve<T>(IComponentSpecification spec, IReadOnlyList<IParameterBinding> parameterBindings);
	}
}
