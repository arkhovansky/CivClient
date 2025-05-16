using System.Collections.Generic;
using Common.Domain.Meta.GameSpecification;



namespace Common.Domain.Meta
{
	public interface ILobby
	{
		public IGameAbstractSpecification GameSpecification { get; }

		public Dictionary<IParticipantAssignment_AbstractSpecification, bool> ParticipantReadiness { get; }

		public bool GameReady { get; }
	}
}
