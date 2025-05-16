using System;
using Client.HiMod.Implementation;



namespace Client.HiMod
{
	public interface IComponentSpecification { }

	public interface IPartialComponentSpecification : IComponentSpecification { }

	public interface IPartialSubjectComponentSpecification : IPartialComponentSpecification { }



	public readonly struct MetadataMatchResult
	{
		public bool Matched { get; }

		private readonly bool _strict;
		public bool Strict {
			get {
				if (!Matched) throw new InvalidOperationException("Matched is false");
				return _strict;
			}
		}


		public static MetadataMatchResult Match(bool strict) => strict ? MatchedStrict : MatchedNotStrict;
		public static MetadataMatchResult NoMatch() => NotMatched;


		public static MetadataMatchResult MatchedStrict = new MetadataMatchResult(true, true);
		public static MetadataMatchResult MatchedNotStrict = new MetadataMatchResult(true, false);
		public static MetadataMatchResult NotMatched = new MetadataMatchResult(false);


		private MetadataMatchResult(bool matched, bool strict = true) {
			Matched = matched;
			_strict = strict;
		}
	}



	public interface IComponentSubject : IPartialComponentSpecification
	{
		MetadataMatchResult Match(IComponentSubject query);
	}



	public interface IComponentContext
		: IEquatable<IComponentContext>
	{
		MetadataMatchResult Match(IComponentContext query);

		EntityInstance? GetEntityItem();
	}


	public interface IComponentContextItem
		: IEquatable<IComponentContextItem>
	{
		bool HasSameKind(IComponentContextItem other);
	}



	public interface IComponentEntity : IComponentSubject
	{
		string Type { get; }

		// MetadataMatchResult Match(IComponentEntity query);
	}



	public interface IComponentMetadata : IComponentSpecification
	{
		IComponentSubject Subject { get; }

		IComponentContext? Context { get; }


		MetadataMatchResult Match(IComponentMetadata query);
	}
}
