// using Client.HiMod;
//
//
//
// namespace Client.UI.Application
// {
// 	public class ApplicationQuitConfirmationFeature
// 	{
// 		protected IController? confirmationDialog;
//
// 		protected bool quitConfirmed;
//
// 		protected IComponentResolver resolver;
// 		protected IGui gui;
//
//
//
// 		public ApplicationQuitConfirmationFeature(IComponentResolver resolver,
// 		                                          IGui gui)
// 		{
// 			this.resolver = resolver;
// 			this.gui = gui;
//
// 			gui.AddCommandMiddleware<QuitCommand>(OnQuitCommand, CommandMiddlewareRole.Confirmation);
// 		}
//
//
//
//
//
//
//
// 		protected bool OnQuitCommand()
// 		{
// 			if (quitConfirmed)
// 				return true;
//
// 			EnterConfirmationState();
//
// 			return false;
// 		}
//
//
//
// 		protected void EnterConfirmationState()
// 		{
// 			// User can emit standard OS quit commands during confirmation
// 			if (confirmationDialog != null)
// 				return;
//
// 			DoEnterConfirmationState();
// 		}
//
//
// 		protected void DoEnterConfirmationState()
// 		{
// 			confirmationDialog = resolver.Resolve<IController>("ConfirmApplicationQuitDialog");
//
// 			confirmationDialog.SetResultHandler<ConfirmCommand>(OnConfirm);
// 			confirmationDialog.SetResultHandler<CancelCommand>(OnCancel);
//
// 			gui.ShowModalWindow(confirmationDialog);
// 		}
//
//
// 		protected void OnConfirm()
// 		{
// 			quitConfirmed = true;
// 			gui.EmitCommand(new QuitCommand());
// 		}
//
//
// 		protected void OnCancel()
// 		{
// 			confirmationDialog.Dispose();
// 			confirmationDialog = null;
// 		}
// 	}
// }
