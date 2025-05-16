namespace Client.HiMod
{
	public interface IGui
	{
		ICommandRouter CommandRouter { get; }


		void SetRootVisualNode(IVisualNode visualNode);

		void SetRootController(IController controller);


		void Update();
	}
}
