using System.Collections.Generic;



namespace Client.HiMod
{
	public interface IApplicationDirectoryStructure
	{
		IReadOnlyList<string> GetAssemblies();
	}
}
