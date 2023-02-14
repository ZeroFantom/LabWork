using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using LabWork.AvaloniaGIF;
using LabWork.Views;
using Material.Dialog.ViewModels.Elements;
using static LabWork.ViewModels.ViewModelBase;

namespace LabWork.Models
{
    /// <summary>
    /// Базовая схема окна, содержит базовые функции, которые задействуются в каждом окне приложения.
    /// </summary>
    public abstract class CustomUI : Window
    {
        internal const double HEIGHT_BAR = 40;

        //TitleBarFocusUi
        
        internal void TitleBarPanel_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.Source is Border && e.GetPosition(sender as Control).Y < HEIGHT_BAR)
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
        {
            var control = sender as Control;
            switch (control!.Name)
            {
                case "TitleBarPanel":
                    control.IsVisible = true;
                    break;
            }
        }

        /// <summary>
        /// Управление фокусом, после того, как он сошёл с элемента управления.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TitleBarPanel_OnLostFocus(object? sender, RoutedEventArgs e)
        {
            var control = sender as Control;
            switch (control!.Name)
            {
                case "TitleBarPanel":
                    control.IsVisible = false;
                    break;
            }
        }

        //Функции TitleBar.

        /// <summary>
        /// Управление фокусом, для TitleBar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Window_OnPointerMoved(object? sender, PointerEventArgs e)
        {
            var control = sender as Window;
            Point point = e.GetPosition(control);
            if (FocusManager.Instance.Current is not TextBox)
            {
                if (control != null)
                {
                    FocusManager.Instance.Focus(point.Y <= HEIGHT_BAR ? ((dynamic)sender).TitleBarPanel : control);
                }
            }
        }

        /// <summary>
        /// Сокрытие приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void HideWindow_OnClick(object? sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Закрытие приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ExitWindow_OnClick(object? sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Закрытие приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ExitAdditionalFunctionality_OnClick(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
