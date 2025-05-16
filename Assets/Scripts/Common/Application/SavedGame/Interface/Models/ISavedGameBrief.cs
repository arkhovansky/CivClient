using System;
using System.Collections.Generic;
using Common.Domain.Meta.GameSpecification;



namespace Common.Application.SavedGame.Interface.Models
{
	public interface ISavedGameBrief
	{
		Guid Id { get; }

		Guid KindId { get; }
		string KindName { get; }

		IGameAttributes Attributes { get; }

		string RulesetName { get; }


		IList<ISavedGameSnapshotBrief>? Snapshots { get; }
	}
}
