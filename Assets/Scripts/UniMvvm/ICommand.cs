using Sodium.Frp;



namespace UniMvvm
{
	public interface ICommand
	{
		Cell<bool> Enabled { get; }


		void Execute();
	}
}
