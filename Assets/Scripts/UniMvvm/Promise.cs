using System;
using System.Threading.Tasks;
using Sodium.Frp;
using Sodium.Functional;



namespace UniMvvm
{
	public class Promise<T> : IPromise<T>
	{
		public Stream<T> sDeliver { get; }
		public Cell<Maybe<T>> Value { get; }



		public Promise(Stream<T> sDeliver) {
			this.sDeliver = sDeliver.Once();
			Value = this.sDeliver.Map(Maybe.Some).Hold(Maybe.None);
		}



		public Promise(T value)
		{
			Value = Cell.Constant(Maybe.Some(value));
			sDeliver = Value.Values().FilterMaybe().Once();
		}



		public Stream<T> Then => Value.Values().FilterMaybe().OrElse(sDeliver).Once();

		// public final void thenDo(Handler<A> h) {
		// 	Transaction.runVoid(() ->
		// 			then().listenOnce(h)
		// 		);
		// }
	}



	public static class TaskPromiseExtensions
	{
		public static IPromise<T> ToPromise<T>(this Task<T> task)
		{
			if (task.IsCompletedSuccessfully)
				return new Promise<T>(task.Result);

			StreamSink<T> streamSink = Stream.CreateSink<T>();
			var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
			task.ContinueWith(t => streamSink.Send(t.Result),
				// null,
				// TaskContinuationOptions.OnlyOnRanToCompletion,
				uiScheduler);

			return new Promise<T>(streamSink);
		}
	}
}
