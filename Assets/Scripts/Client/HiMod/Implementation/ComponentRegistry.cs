using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;



namespace Client.HiMod.Implementation
{
	public class ComponentRegistry : IComponentRegistry, IComponentRegistryManagement
	{
		protected readonly IApplicationDirectoryStructure directoryStructure;

		protected readonly Dictionary<IComponentMetadata, Type> registry = new ();



		public ComponentRegistry(IApplicationDirectoryStructure directoryStructure)
		{
			this.directoryStructure = directoryStructure;
		}



		public virtual void Populate()
		{
			foreach (string path in directoryStructure.GetAssemblies()) {
				ScanAssembly(path);
			}
		}



		protected virtual void ScanAssembly(string path)
		{
			var assemblyName = AssemblyName.GetAssemblyName(path);
			var assembly = Assembly.Load(assemblyName);

			foreach (var type in assembly.GetExportedTypes()) {
				var metadataProperty = type.GetProperty(
					"Metadata",
					BindingFlags.Public | BindingFlags.Static,
					null,
					typeof(IComponentMetadata),
					Type.EmptyTypes,
					null);

				if (metadataProperty == null) continue;

				var metadata = (IComponentMetadata?) metadataProperty.GetValue(null);

				if (metadata == null)
					continue; //TODO

				Register(type, metadata);
			}
		}



		protected virtual void Register(Type type, IComponentMetadata metadata)
		{
			registry.Add(metadata, type);
		}



		public virtual TypeWithMetadata? Find(IComponentMetadata metadata)
		{
			var lookupByStrictMatch = registry
				.Select(kv => (kv.Key.Match(metadata), new TypeWithMetadata(kv.Value, kv.Key)))
				.Where(t => t.Item1.Matched)
				.ToLookup(t => t.Item1.Strict, t => t.Item2);

			var strictMatchTypes = lookupByStrictMatch[true].ToArray();

			if (strictMatchTypes.Length == 1)
				return strictMatchTypes[0];

			if (strictMatchTypes.Length > 1)
				throw new NotImplementedException();

			var notStrictMatchTypes = lookupByStrictMatch[false].ToArray();

			if (notStrictMatchTypes.Length == 1)
				return notStrictMatchTypes[0];

			if (notStrictMatchTypes.Length > 1)
				throw new NotImplementedException();

			// notStrictMatchTypes.Length == 0
			return null;
		}
	}
}
