using Client.HiMod;
using Client.HiMod.Implementation;



namespace Client.UniHiMod
{
	public abstract class ApplicationController_Base : Controller
	{



		public ApplicationController_Base(
			ICommandRouter commandRouter
		)
			: base(commandRouter)
		{
			AddCommandHandler<ExitApplicationCommand>(OnQuitCommand);

			// Intercept standard OS quit commands
			UnityEngine.Application.wantsToQuit += OnWantsToQuit;
		}



		protected virtual void OnQuitCommand(ExitApplicationCommand command)
		{
			UnityEngine.Application.wantsToQuit -= OnWantsToQuit;
			UnityEngine.Application.Quit();
		}



		protected virtual bool OnWantsToQuit()
		{
			EmitCommand(new ExitApplicationCommand());

			return false;
		}
	}
}
