using System.Linq;
using System.Threading.Tasks;
#if !(MACCATALYST || MACOS)
using MessageUI;
#endif

namespace Microsoft.Maui.Essentials
{
	public static partial class Sms
	{
		internal static bool IsComposeSupported
#if !(MACCATALYST || MACOS)
			=> MFMessageComposeViewController.CanSendText;
#else
			=> false;
#endif

		static Task PlatformComposeAsync(SmsMessage message)
		{
#if !(MACCATALYST || MACOS)
			// do this first so we can throw as early as possible
			var controller = Platform.GetCurrentViewController();

			// create the controller
			var messageController = new MFMessageComposeViewController();
			if (!string.IsNullOrWhiteSpace(message?.Body))
				messageController.Body = message.Body;

			messageController.Recipients = message?.Recipients?.ToArray() ?? new string[] { };

			// show the controller
			var tcs = new TaskCompletionSource<bool>();
			messageController.Finished += (sender, e) =>
			{
				messageController.DismissViewController(true, null);
				tcs?.TrySetResult(e.Result == MessageComposeResult.Sent);
			};
			controller.PresentViewController(messageController, true, null);

			return tcs.Task;
#else
			return Task.CompletedTask;
#endif
		}
	}
}
