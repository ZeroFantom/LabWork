using System.Diagnostics;
using System.IO.Compression;
using Avalonia.Controls;
using static LabWork.ViewModels.PageLabWork.LabWork19ViewModel;

namespace LabWork.Views.PageLabWork
{
    public partial class LabWork19 : UserControl
    {
        public LabWork19()
        {
            InitializeComponent();
        }

        private void VisualArhiveButton_OnClick(object? sender, RoutedEventArgs e)
            => MethodDataTry(LabWork19ViewModelInstanse.OpenDataFileArhive, VisualArhiveButton, sender, "Данные успешно записаны в отчёт!","Ошибка во время выполнения!");

        private void ZipButton_OnClick(object? sender, RoutedEventArgs e)
            => MethodDataTry(LabWork19ViewModelInstanse.Arhivator, ZipButton, sender, "Данные успешно архивированы!", "Ошибка во время выполнения!");

        private void UnzipButton_OnClick(object? sender, RoutedEventArgs e)
            => MethodDataTry(LabWork19ViewModelInstanse.DiArhivator, UnzipButton, sender, "Данные успешно разархивированы!", "Ошибка во время выполнения!");

        private void AddArhiveButton_OnClick(object? sender, RoutedEventArgs e)
            => MethodDataTry(LabWork19ViewModelInstanse.UpdateArhive, ZipButton, sender, "Данные успешно добавлены в архив!", "Ошибка во время выполнения!");

        public void MethodDataTry(Action action, Control control, object? sender, string successful, string error)
        {
            try
            {
                action.Invoke();
                MessagesApp.System_Message(successful, control, sender);
            }
            catch (Exception)
            {
                MessagesApp.System_Message(error, control, sender);
            }
        }
    }
}
