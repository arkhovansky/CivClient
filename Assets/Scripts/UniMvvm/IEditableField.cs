using Sodium.Frp;



namespace UniMvvm
{
	public interface IEditableField<T>
		where T : struct
	{
		Cell<T?> Value { get; }

		Cell<bool> IsChanged { get; }

		Cell<bool> IsSynchronizing { get; }
		Cell<bool> IsLoading { get; }
		Cell<bool> IsSaving { get; }


		void Save(string text);
	}
}
