namespace LabWork.Models
{
    /// <summary>
    /// Всплывающее сообщение пользователю.
    /// </summary>
    internal class MessageFlyout : FlyoutBase
    {
        readonly TextBlock _textBlock = new();

        /// <inheritdoc />
        internal MessageFlyout(string Text)
        {
            _textBlock.Text = Text;
        }

        /// <inheritdoc />
        protected override Control CreatePresenter()
        {
            return new FlyoutPresenter
            {
                Content = _textBlock
            };
        }
    }
}
