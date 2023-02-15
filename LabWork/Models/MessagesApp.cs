namespace LabWork.Models
{
    internal static class MessagesApp
    {
        /// <summary>
        /// Метод реализующий системное сообщение.
        /// </summary>
        internal static void System_Message<T>(string content, T control, object? sender) where T : Control
        {
            control.ContextFlyout = new MessageFlyout(content);
            control.ContextFlyout.ShowAt(sender as Control);
        }
    }
}
