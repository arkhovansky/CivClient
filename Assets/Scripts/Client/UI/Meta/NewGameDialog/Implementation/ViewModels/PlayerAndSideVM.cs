// using Domain;
// using UnityEngine;
//
//
//
// namespace UI.NewGameDialog.ViewModels
// {
// 	public class PlayerAndSideVM
// 	{
// 		public string? UserName { get; }
// 		public string? AiProfile { get; }
//
// 		public string Nation { get; }
// 		public Color Color { get; }
//
// 		public bool Ready { get; }
//
//
//
// 		public PlayerAndSideVM(IPlayableSideSpecification playableSide, bool ready)
// 		{
// 			Nation = playableSide.Nation.Name;
//
// 			Color = playableSide.Color;
//
//
// 			var player = playableSide.Player;
//
// 			if (player != null) {
// 				if (player is RemoteParticipantSpecification)
// 					UserName = ((RemoteParticipantSpecification)player).User.Name;
// 				else if (player is LocalAiParticipantSpecification) {
// 					UserName = "Local AI";
// 					AiProfile = ((LocalAiParticipantSpecification)player).ConfigurationProfile.Name;
// 				}
// 			}
//
//
// 			Ready = ready;
// 		}
// 	}
// }
