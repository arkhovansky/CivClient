using System;
using Client.UI.Meta.Common.Interface;
using Client.UI.Meta.MainMenu.Interface;
using Common.Application.SavedGame.Implementation.Models;
using Common.Application.SavedGame.Interface.Models;
using Common.Domain.Game;
using Common.Domain.Game.World;
using Common.Util;
using FreeCiv.Common.Domain.Game;



namespace FreeCiv.Client.UI.Meta.MainMenu.ViewModels
{
	internal class LastGameVM : ILastGameVM
	{
		public string? Name { get; }

		public string GameKind { get; }

		public IPolityVM PolityVM { get; }

		// public bool PolityChanged { get; }

		public uint Turn { get; }

		public string? Comment { get; }

		public DateTime Timestamp { get; }


		// Own members

		public string Ruleset { get; }

		public HistoricYear Year { get; }



		public LastGameVM(ISavedGameSnapshotBrief snapshot,
		                  IPolityVMFactory polityVMFactory)
		{
			// assert snapshot.Game.TypeId == GameKind.Id

			Name = snapshot.Game.Attributes.Name;
			GameKind = snapshot.Game.KindName;
			PolityVM = polityVMFactory.Create(snapshot.ThisPlayerPolity);
			// PolityChanged = snapshot.ThisPlayerPolityChanged;
			Turn = ((TurnBasedWorldTimeProgress)snapshot.WorldTimeProgress).Turn;
			Comment = snapshot.Comment;
			Timestamp = snapshot.Timestamp;
			Ruleset = snapshot.Game.RulesetName;
			Year = ((WorldDateTime)((TurnBasedWorldTimeProgress)snapshot.WorldTimeProgress).WorldDateTime).Year;
		}



		// public LastGameVM FromLastGameSnapshot(SavedGameSnapshotBrief snapshot)
		// {
		// 	return new LastGameVM(snapshot);
		// }
	}



	internal class LastGameVMFactory : ILastGameVMFactory
	{
		private readonly IPolityVMFactory _polityVMFactory;


		public LastGameVMFactory(IPolityVMFactory polityVMFactory)
		{
			_polityVMFactory = polityVMFactory;
		}


		public ILastGameVM Create(ISavedGameSnapshotBrief snapshot)
		{
			return new LastGameVM(snapshot, _polityVMFactory);
		}
	}
}
