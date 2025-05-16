using System;



namespace Client.HiMod
{
	public record TypeWithMetadata(
		Type Type,
		IComponentMetadata Metadata);



	public interface IComponentRegistry
	{
		TypeWithMetadata? Find(IComponentMetadata metadata);
	}



	public interface IComponentRegistryManagement
	{
		void Populate();
	}
}
