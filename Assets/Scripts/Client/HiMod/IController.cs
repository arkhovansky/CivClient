using System;
using System.Collections.Generic;



namespace Client.HiMod
{
	public interface IController
	{
		IController? Parent { get; }

		IReadOnlyDictionary<Type, Delegate> CommandHandlers { get; }


		// Delegate? TryGetCommandTypeHandler(Type commandType);


		void AttachChildToGui(IController child);

		void DetachFromGui();

		void SetVisualNode(IVisualNode visualNode);
	}
}
