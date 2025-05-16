using System.Collections.Generic;
using Client.HiMod;



namespace Client.UniHiMod
{
	public class InEditorApplicationDirectoryStructure : IApplicationDirectoryStructure
	{
		public IReadOnlyList<string> GetAssemblies()
		{
			return new[] {
				"Assembly-CSharp.dll",
				"FreeCiv.Client.dll"
			};
		}
	}
}
