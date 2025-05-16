using Sodium.Frp;



namespace UniMvvm
{
	public abstract class Command : ICommand
	{
		public Cell<bool> Enabled { get; }


		public abstract void Execute();



		protected Command(Cell<bool> enabled)
		{
			Enabled = enabled;
		}
	}
}
