namespace LabWork.Models
{
    internal static class MessagesApp
    {
        /// <summary>
        /// Метод реализующий системное сообщение.
        /// </summary>
        internal static void System_Message<T>(string content, T control, object? sender) where T : Control
        {
            if (sender is not Control controlSender) return;

            control.ContextFlyout = new MessageFlyout(content);
            control.ContextFlyout.ShowAt(controlSender);
        }
    }
}
