using System;



namespace Client.HiMod.Implementation
{
	public record ComponentMetadata : IComponentMetadata
	{
		public IComponentSubject Subject { get; }

		public IComponentContext? Context { get; }



		public ComponentMetadata(IComponentSubject subject,
		                         IComponentContext? context = null)
		{
			Subject = subject;
			Context = AugmentWithEntity(context);
		}


		public ComponentMetadata(IComponentSubject subject,
		                         IComponentContextItem contextItem)
			: this(subject, new ComponentContext(contextItem))
		{ }



		public MetadataMatchResult Match(IComponentMetadata query)
		{
			var subjectMatch = Subject.Match(query.Subject);
			if (!subjectMatch.Matched)
				return MetadataMatchResult.NotMatched;

			var contextMatch = (Context ?? new ComponentContext()).Match(query.Context ?? new ComponentContext());
			if (!contextMatch.Matched)
				return MetadataMatchResult.NotMatched;

			if (subjectMatch.Strict && contextMatch.Strict)
				return MetadataMatchResult.MatchedStrict;
			return MetadataMatchResult.MatchedNotStrict;
		}



		private IComponentContext? AugmentWithEntity(IComponentContext? context)
		{
			return ComponentContext.Combine(context, GetEntityInstanceFromSubject());
		}


		private EntityInstance? GetEntityInstanceFromSubject()
		{
			return Subject switch {
				EntityInstance entity => entity,
				RoleSubject role => role.Entity as EntityInstance,
				_ => null
			};
		}


		private bool ContextEquals(IComponentContext? queryContext)
		{
			return Context?.Equals(queryContext) ?? queryContext == null;
		}
	}



	public record EntityType(
			string Type
		)
		: IComponentEntity
	{
		public MetadataMatchResult Match(IComponentSubject query)
		{
			return query switch {
				EntityType q =>
					this == q ? MetadataMatchResult.MatchedStrict : MetadataMatchResult.NotMatched,
				EntityInstance q =>
					Type == q.Type ? MetadataMatchResult.MatchedNotStrict : MetadataMatchResult.NotMatched,
				_ => MetadataMatchResult.NotMatched
			};
		}
	}



	public record EntityInstance(
			string Type,
			string Id
		)
		: IComponentEntity, IComponentContextItem
	{
		public MetadataMatchResult Match(IComponentSubject query)
		{
			return query switch {
				EntityInstance q =>
					this == q ? MetadataMatchResult.MatchedStrict : MetadataMatchResult.NotMatched,
				_ => MetadataMatchResult.NotMatched
			};
		}


		public bool Equals(IComponentContextItem? other)
		{
			return Equals((object?)other);
		}


		public bool HasSameKind(IComponentContextItem other)
		{
			return GetType() == other.GetType() && Type == ((EntityInstance)other).Type;
		}


		public static ComponentContext operator +(EntityInstance a, IComponentContextItem b)
		{
			return new ComponentContext(a, b);
		}
	}



	// public record EntityTypeSubject(
	// 		string Type
	// 	)
	// 	: IComponentSubject
	// {
	// 	public MetadataMatchResult Match(IComponentSubject query)
	// 	{
	// 		return query switch {
	// 			EntityTypeSubject q =>
	// 				this == q ? MetadataMatchResult.MatchedStrict : MetadataMatchResult.NotMatched,
	// 			EntityInstanceSubject q =>
	// 				Type == q.Type ? MetadataMatchResult.MatchedNotStrict : MetadataMatchResult.NotMatched,
	// 			_ => MetadataMatchResult.NotMatched
	// 		};
	// 	}
	// }
	//
	//
	//
	// public record EntityInstanceSubject(
	// 		string Type,
	// 		string Id
	// 	)
	// 	: IComponentSubject
	// {
	// 	public MetadataMatchResult Match(IComponentSubject query)
	// 	{
	// 		return query switch {
	// 			EntityInstanceSubject q =>
	// 				this == q ? MetadataMatchResult.MatchedStrict : MetadataMatchResult.NotMatched,
	// 			_ => MetadataMatchResult.NotMatched
	// 		};
	// 	}
	// }



	public record CollectionSubject(
			string Type
		)
		: IComponentSubject
	{
		public MetadataMatchResult Match(IComponentSubject query)
		{
			return query switch {
				CollectionSubject q =>
					this == q ? MetadataMatchResult.MatchedStrict : MetadataMatchResult.NotMatched,
				_ => MetadataMatchResult.NotMatched
			};
		}
	}



	public record RoleSubject(
			string Role,
			IComponentEntity Entity
		)
		: IComponentSubject
	{
		public MetadataMatchResult Match(IComponentSubject query)
		{
			return query switch {
				RoleSubject q =>
					Role != q.Role ? MetadataMatchResult.NotMatched :
					Entity.Match(q.Entity),
				_ =>
					MetadataMatchResult.NotMatched
			};
		}
	}



	public record OperationSubject(
			string Operator,
			string Type
		)
		: IComponentSubject
	{
		public MetadataMatchResult Match(IComponentSubject query)
		{
			return query switch {
				OperationSubject q =>
					this == q ? MetadataMatchResult.MatchedStrict : MetadataMatchResult.NotMatched,
				_ => MetadataMatchResult.NotMatched
			};
		}
	}
}
