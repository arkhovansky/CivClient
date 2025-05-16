using System;
using Client.UI.Meta.Common.Interface;
using Common.Application.SavedGame.Interface.Models;
using Sodium.Frp;
using UniMvvm;



namespace Client.UI.Meta.MainMenu.Interface
{
	public interface IMainMenuVM
	{
		Cell<ILastGameVM?> LastGameVM { get; }

		ICommand ContinueLastGameCommand { get; }

		ICommand NewGameCommand { get; }

		ICommand LoadGameCommand { get; }

		Cell<bool> RequestInProgress { get; }
	}



	public interface ILastGameVM
	{
		string? Name { get; }

		string GameKind { get; }

		IPolityVM PolityVM { get; }

		// bool PolityChanged { get; }

		uint Turn { get; }

		string? Comment { get; }

		DateTime Timestamp { get; }
	}



	public interface ILastGameVMFactory
	{
		ILastGameVM Create(ISavedGameSnapshotBrief snapshot);
	}
}
