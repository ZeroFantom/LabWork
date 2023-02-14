namespace LabWork.Models
{
    /// <summary>
    /// Базовая схема окна, содержит базовые функции, которые задействуются в каждом окне приложения.
    /// </summary>
    public abstract class CustomUI : Window
    {
        private const byte HEIGHT_TITLEBAR = 40;

        #region TitleBarPanel_OnEvent

        /// <summary>
        /// Метод диктует, что происходит при взаимодействии с TitleBar путём зажатия или нажатия правой кнопки мыши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TitleBarPanel_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (( e.Source is not null && sender is not null) 
                && ( e.Source is Border && e.GetPosition(sender as Control).Y < HEIGHT_TITLEBAR))
            {
                BeginMoveDrag(e);
            }
        }

        /// <summary>
        /// Управление фокусом, после того, как какой-то элемент управления отреагировал на его получение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TitleBarPanel_OnGotFocus(object? sender, GotFocusEventArgs e)
         => TitleBarPanel_SetIsVisibleStatus(sender);

        /// <summary>
        /// Управление фокусом, после того, как он сошёл с элемента управления.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TitleBarPanel_OnLostFocus(object? sender, RoutedEventArgs e)
            => TitleBarPanel_SetIsVisibleStatus(sender);

        #endregion

        #region ButtonTitleBarPanel_ClickEvent

        /// <summary>
        /// Скрытие окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void HideWindow_OnClick(object? sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        /// <summary>
        /// Метод закрывает приложение полностью.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ExitApplication_OnClick(object? sender, RoutedEventArgs e)
            => Environment.Exit(0);

        /// <summary>
        /// Метод закрывает только окно, что вызвало событие.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ExitWindow_OnClick(object? sender, RoutedEventArgs e)
            => Close();

        #endregion
        
        private void TitleBarPanel_SetIsVisibleStatus(object? sender)
        {
            if (sender as Control is { Name: "TitleBarPanel" } control)
            {
                control.IsVisible = !control.IsVisible;
            }
        }

        /// <summary>
        /// Метод фиксирует перемещение мыши по области окна и выполняет фокусировку на определённых элементах в случае удовлетворения условий. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Window_OnPointerMoved(object? sender, PointerEventArgs e)
        {
            if (FocusManager.Instance!.Current is TextBox || (sender as Window) is not { IsInitialized: true } control) return;

            var point = e.GetPosition(control);
            FocusManager.Instance.Focus(point.Y <= HEIGHT_TITLEBAR ? ((dynamic)sender).TitleBarPanel : control);
        }
    }
}
