// using System;
// using System.Collections.Generic;
// using Domain;
// using UnityEngine;
//
//
//
// namespace Server.Domain.Meta
// {
// 	public class Lobby
// 	{
// 		public interface IPlayerCountMode {}
//
// 		public class PlayerCountMode_SpecificCount : IPlayerCountMode
// 		{
// 			public MirrorxBehaviorSubject<uint> GameSideCount { get; }
// 			public MirrorxBehaviorSubject<IAiSpecification?> FillerAiSpecification { get; }
// 		}
//
// 		public class PlayerCountMode_MaxCount : IPlayerCountMode
// 		{
// 			public MirrorxBehaviorSubject<uint> MaxPlayerCount { get; }
// 		}
//
//
//
// 		public GameSpecification GameSpecification { get; }
//
// 		public MirrorxBehaviorSubject<IPlayerCountMode?> PlayerCountMode { get; }
//
// 		public Dictionary<IParticipantSpecification, bool> ParticipantReadiness { get; }
//
// 		public bool GameReady { get; }
//
//
//
// 		public Lobby(
// 			GameSpecification gameSpecification,
// 			MirrorxChannel mirrorxChannel,
// 			IObservable<User> connectedUsers)
// 		{
// 			GameSpecification = gameSpecification;
//
// 			PlayerCountMode = new MirrorxBehaviorSubject<IPlayerCountMode?>(null, mirrorxChannel);
// 			// PlayerCountMode.Subscribe(mode => {
// 			// 	if (mode == null) {
// 			// 		RemoveFillerAiPlayers();
// 			// 	}
// 			// 	else if (mode is PlayerCountMode_SpecificCount) {
// 			// 		mode.GameSideCount.Subscribe(count => {
// 			// 			if (count > GameSpecification.GameSideCount && mode.FillerAiSpecification != null) {
// 			// 				FillAiPlayers();
// 			// 			}
// 			// 		});
// 			// 		mode.FillerAiSpecification.Subscribe(aiSpec => FillAiPlayers());
// 			// 	}
// 			// 	else if (mode is PlayerCountMode_MaxCount) {
// 			// 		RemoveFillerAiPlayers();
// 			// 	}
// 			// });
//
// 			_rules.Rule(
// 				condition: _ => PlayerCountMode is PlayerCountMode_SpecificCount,
// 				target: GameSpecification.Polities.Join(GameSpecification.Players),
// 				rule: target => target.AutoFillAtEnd(
// 					toIndex: ((PlayerCountMode_SpecificCount)PlayerCountMode).GameSideCount,
// 					value: index => new {
// 						PlayableSide = new PlayableSideSpecification(new Random<NationSpecification>()),
// 						Player = PlayerCountMode.FillerAiSpecification
// 					}));
//
// 			ParticipantReadiness.Rule(_rules)
// 				.Keys(GameSpecification.Participants)
// 				.Value(participant =>
// 					GameSpecification.IsParticipantRoleSpecified(participant) &&
// 					_connectedUsers.Contains(participant.UserIdentity));
//
// 			GameReady.Rule(_rules)
// 				.TrueIf(
// 					GameSpecification.IsValid &&
// 					GameSpecification.Participants.TrueForAll(_connectedUsers.Contains));
// 		}
//
//
//
// 		[Command]
// 		public void AddPlayerWithSide(IParticipantSpecification participant)
// 		{
// 			uint maxPlayerCount =
// 				(PlayerCountMode as PlayerCountMode_SpecificCount)?.GameSideCount ??
// 				(PlayerCountMode as PlayerCountMode_MaxCount)?.MaxPlayerCount ??
// 				uint.MaxValue;
//
// 			if (GameSpecification.Polities.Length >= maxPlayerCount) {
// 				throw new Exception();
// 			}
//
// 			IPlayableSideSpecification side = _playableSideSpecificationFactory.New();
// 			IPlayerSpecification player = NewPlayerFromParticipant(participant);
//
// 			side.Player = player;
// 			player.PlayableSide = side;
//
// 			GameSpecification.Polities.Add(side);
// 			GameSpecification.Players.Add(player);
//
// 			_rightsService.SetOwner(player, CurrentUser);
// 			_rightsService.SetOwner(side, CurrentUser);
// 		}
// 	}
// }
