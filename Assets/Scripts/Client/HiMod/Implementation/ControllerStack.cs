using System.Collections.Generic;



namespace Client.HiMod.Implementation
{
	public class ControllerStack
	{
		public enum ControllerDisposition {
			Fixed,
			Transitional
		}



		protected readonly IController owner;


		protected record ControllerRecord(
			IController Controller,
			ControllerDisposition Disposition);

		protected readonly Stack<ControllerRecord> stack = new ();



		public ControllerStack(IController owner)
		{
			this.owner = owner;
		}



		public virtual void Push(IController child, ControllerDisposition disposition)
		{
			if (disposition == ControllerDisposition.Fixed)
				PurgeTransitionalControllers();

			DoPush(child, disposition);
		}


		public virtual void Pop()
		{
			if (stack.Count == 0)
				; //TODO

			var (child, disposition) = stack.Pop();
			child.DetachFromGui();
			// child.Dispose();
		}


		protected virtual void PurgeTransitionalControllers()
		{
			while (stack.Peek().Disposition == ControllerDisposition.Transitional) {
				Pop();
			}
		}


		protected virtual void DoPush(IController child, ControllerDisposition disposition)
		{
			stack.Push(new ControllerRecord(child, disposition));

			owner.AttachChildToGui(child);
		}
	}
}
