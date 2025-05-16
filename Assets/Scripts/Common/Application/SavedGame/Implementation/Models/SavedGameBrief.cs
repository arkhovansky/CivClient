using System;
using System.Collections.Generic;
using Common.Application.SavedGame.Interface.Models;
using Common.Domain.Meta.GameSpecification;



namespace Common.Application.SavedGame.Implementation.Models
{
	public class SavedGameBrief : ISavedGameBrief
	{
		public Guid Id { get; }

		public Guid KindId { get; }
		public string KindName { get; }

		public IGameAttributes Attributes { get; }

		public string RulesetName { get; }


		public IList<ISavedGameSnapshotBrief>? Snapshots { get; }
	}
}
