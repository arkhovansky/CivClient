using Sodium.Frp;



namespace UniMvvm
{
	public interface IPromise<T>
	{
		Stream<T> Then { get; }
	}
}
