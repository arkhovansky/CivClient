using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;



namespace Client.HiMod.Implementation
{
	public class ComponentResolver : IComponentResolver
	{
		protected readonly IComponentRegistry registry;

		protected readonly IDiContainer diContainer;


		protected readonly IComponentEntity? subjectEntityContext;

		protected readonly IComponentContext? context;



		public ComponentResolver(IComponentRegistry registry,
		                         IDiContainer diContainer,
		                         IComponentEntity? subjectEntityContext = null,
		                         IComponentContext? context = null)
		{
			this.registry = registry;
			this.diContainer = diContainer;
			this.subjectEntityContext = subjectEntityContext;
			this.context = context;
		}



		public virtual IComponentResolver CopyWithContext(IComponentEntity? subjectEntityContext = null,
		                                                  IComponentContext? context = null)
		{
			//TODO: return this if suitable
			return new ComponentResolver(registry, diContainer,
			                             subjectEntityContext, context);
		}


		// public virtual IComponentResolver CopyWithMergedContext(IComponentEntity? subjectEntityContext = null,
		//                                                         IComponentContext? context = null)
		// {
		// 	//TODO: return this if suitable
		// 	return new ComponentResolver(registry, diContainer,
		// 	                             subjectEntityContext, ComponentContext.Combine(this.context, context));
		// }



		public virtual T Resolve<T>(IComponentSpecification spec)
		{
			return Resolve<T>(spec, Array.Empty<IParameterBinding>());
		}


		public virtual T Resolve<T>(IComponentSpecification spec, IParameterBinding parameterBinding)
		{
			return Resolve<T>(spec, new[] { parameterBinding });
		}


		public virtual T Resolve<T>(IComponentSpecification spec, IReadOnlyList<IParameterBinding> parameterBindings)
		{
			IComponentMetadata fullSpec = GetFullComponentSpecification(spec);

			TypeWithMetadata? typeWithMetadata = registry.Find(fullSpec);

			if (typeWithMetadata == null)
				throw new Exception(); //TODO

			return Instantiate<T>(typeWithMetadata.Type, parameterBindings, fullSpec);
		}



		protected virtual IComponentMetadata GetFullComponentSpecification(IComponentSpecification spec)
		{
			if (spec is IComponentMetadata metadata)
				return metadata;

			if (spec is IComponentSubject subject)
				return new ComponentMetadata(subject, context);

			if (spec is IPartialSubjectComponentSpecification) {
				if (subjectEntityContext == null)
					throw new InvalidOperationException($"{nameof(subjectEntityContext)} is null");

				switch (spec) {
					case ComponentRole role:
						return new ComponentMetadata(
							new RoleSubject(role.Value, subjectEntityContext),
							context);

					case ComponentOperator @operator:
						return new ComponentMetadata(
							new OperationSubject(@operator.Value, subjectEntityContext.Type),
							context);
				}
			}

			throw new ArgumentException($"Unknown specification type: {spec.GetType().FullName}",
			                            nameof(spec));
		}



		protected virtual T Instantiate<T>(Type type,
		                                   IReadOnlyList<IParameterBinding> parameterBindings,
		                                   IComponentMetadata resolveQuery)
		{
			ConstructorInfo constructor;
			object[] arguments;
			(constructor, arguments) = FindConstructor(type.GetConstructors(), parameterBindings, resolveQuery);

			return (T) constructor.Invoke(arguments);
		}



		protected virtual (ConstructorInfo, object[]) FindConstructor(
			ConstructorInfo[] constructors,
			IReadOnlyList<IParameterBinding> parameterBindings,
			IComponentMetadata resolveQuery)
		{
			object[] arguments = { };
			var constructor = constructors.First(c => Matches(c, parameterBindings, resolveQuery, out arguments));

			return (constructor, arguments);
		}



		protected virtual bool Matches(ConstructorInfo constructor,
		                               IReadOnlyList<IParameterBinding> parameterBindings,
		                               IComponentMetadata resolveQuery,
		                               out object[] arguments)
		{
			var args = new ArrayList();
			var bindings = parameterBindings.ToHashSet();

			foreach (var parameter in constructor.GetParameters()) {
				var binding = bindings.FirstOrDefault(b => b.ParameterSpecification.IsSatisfiedBy(parameter));

				if (binding != null) {
					bindings.Remove(binding);
					args.Add(binding.Value);
				}
				else if (parameter.ParameterType == typeof(IComponentMetadata)) {
					args.Add(resolveQuery);
				}
				else if (parameter.ParameterType == typeof(IComponentResolver)) {
					// Do not resolve here because we don't know if current constructor matches.
					// Add parameter as a token for later resolution.
					args.Add(parameter);
				}
				else if (diContainer.CanResolve(parameter)) {
					// Do not resolve here because we don't know if current constructor matches.
					// Add parameter as a token for later resolution.
					args.Add(parameter);
				}
				else {
					arguments = Array.Empty<object>();
					return false;
				}
			}

			for (var i = 0; i < args.Count; ++i) {
				if (args[i] is ParameterInfo parameter) {
					if (parameter.ParameterType == typeof(IComponentResolver))
						args[i] = CopyWithContext(resolveQuery.Subject as IComponentEntity, resolveQuery.Context);
					else
						args[i] = diContainer.Resolve(parameter);
				}
			}

			arguments = args.ToArray();
			return true;
		}
	}
}
