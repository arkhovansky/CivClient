using System;
using System.Reflection;



namespace Common.GameKind
{
	public static class AssemblyExtensions
	{
		public static Func<TArg, TResult> GetConversionFactoryMethodDelegate<TArg, TResult>(
			this Assembly assembly, string typeName, string factoryMethodName)
		{
			Type? resultType = Array.Find(assembly.GetExportedTypes(), type => type.Name == typeName);
			if (resultType == null)
				throw new Exception(); //TODO

			return (Func<TArg, TResult>) Delegate.CreateDelegate(
				typeof(Func<TArg, TResult>), resultType, factoryMethodName);
		}
	}
}
