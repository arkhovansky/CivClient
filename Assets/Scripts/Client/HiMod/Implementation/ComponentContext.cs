using System;
using System.Collections.Generic;
using System.Linq;



namespace Client.HiMod.Implementation
{
	public record ComponentContextItem(
			string Name,
			string Value)
		: IComponentContextItem
	{
		public bool Equals(IComponentContextItem? other)
		{
			return Equals((object?)other);
		}


		public bool HasSameKind(IComponentContextItem other)
		{
			return GetType() == other.GetType() && Name == ((ComponentContextItem)other).Name;
		}


		public static ComponentContext operator +(ComponentContextItem a, IComponentContextItem b)
		{
			return new ComponentContext(a, b);
		}
	}



	public readonly struct ComponentContext : IComponentContext
	{
		public IReadOnlyCollection<IComponentContextItem> Items => _items;


		private readonly HashSet<IComponentContextItem> _items;



		public ComponentContext(IComponentContextItem item)
		{
			_items = new HashSet<IComponentContextItem> { item };
		}


		public ComponentContext(IComponentContextItem item1, IComponentContextItem item2)
		{
			_items = new HashSet<IComponentContextItem> { item1 };
			Add(item2);
		}


		public ComponentContext(ComponentContext other)
		{
			// Use version with comparer to enable cloning optimization
			_items = new HashSet<IComponentContextItem>(other._items, other._items.Comparer);
		}


		public void Add(IComponentContextItem item)
		{
			var sameKindItem = _items.FirstOrDefault(it => it.HasSameKind(item));

			if (sameKindItem != null) {
				if (sameKindItem.Equals(item)) return;

				throw new InvalidOperationException($"Context already contains item of the same kind"); //TODO
			}

			_items.Add(item);
		}


		public MetadataMatchResult Match(IComponentContext query)
		{
			EntityInstance? queryEntity = query.GetEntityItem();
			if (queryEntity == null)
				return MetadataMatchResult.MatchedStrict;

			EntityInstance? thisEntity = GetEntityItem();
			if (thisEntity == null)
				return MetadataMatchResult.MatchedNotStrict;

			return thisEntity == queryEntity ? MetadataMatchResult.MatchedStrict : MetadataMatchResult.NotMatched;
		}


		public EntityInstance? GetEntityItem()
		{
			return _items.OfType<EntityInstance>().FirstOrDefault();
		}


		public bool Equals(IComponentContext? other)
		{
			return other != null &&
			       GetType() == other.GetType() &&
			       _items.Equals(((ComponentContext)other)._items);
		}


		public static ComponentContext operator +(ComponentContext context, IComponentContextItem item)
		{
			var result = new ComponentContext(context);
			result.Add(item);

			return result;
		}


		public static IComponentContext? Combine(IComponentContext? a, IComponentContextItem? b)
		{
			if (a == null) {
				if (b == null) return null;
				return new ComponentContext(b);
			}
			else {
				if (b == null) return a;
				return (ComponentContext)a + b; //TODO: Ok while IComponentContext has single implementor
			}
		}
	}
}
