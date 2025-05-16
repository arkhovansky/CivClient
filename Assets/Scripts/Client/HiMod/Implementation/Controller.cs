using System;
using System.Collections.Generic;



namespace Client.HiMod.Implementation
{
	public abstract class Controller : IController
	{
		public IController? Parent { get; }

		public IVisualNode? VisualNode { get; }

		public IReadOnlyDictionary<Type, Delegate> CommandHandlers => commandHandlers;


		protected readonly ICommandRouter commandRouter;

		protected readonly Dictionary<Type, Delegate> commandHandlers;



		public Controller(
			ICommandRouter commandRouter)
		{
			this.commandRouter = commandRouter;

			Parent = null;

			commandHandlers = new Dictionary<Type, Delegate>();
		}



		protected virtual void AddCommandHandler<TCommand>(Action<TCommand> method)
		{
			commandHandlers[typeof(TCommand)] = method;
		}


		protected virtual void EmitCommand(ICommand command)
		{
			commandRouter.EmitCommand(command, this);
		}


		public virtual void AttachChildToGui(IController child)
		{
			commandRouter.AddController(child);

			if (VisualNode != null)
				child.SetVisualNode(GetChildVisualNode(child));
		}


		public virtual void DetachFromGui()
		{
			commandRouter.RemoveController(this);
		}


		public abstract void SetVisualNode(IVisualNode visualNode);


		protected virtual IVisualNode GetChildVisualNode(IController child)
		{
			if (VisualNode == null)
				throw new InvalidOperationException("No visual node set");

			return VisualNode; //TODO
		}
	}
}
