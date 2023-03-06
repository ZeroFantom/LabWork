using Avalonia.Controls;

namespace LabWork.Views.PageLabWork
{
    public partial class LabWork22 : UserControl
    {
        public LabWork22()
        {
            InitializeComponent();
        }

        private void GeneratePasswordButton_OnClick(object? sender, RoutedEventArgs e)
            => LabWork22ViewModel.LabWork22ViewModelInstanse.PasswordGenerate();

        private void VisualDataButton_OnClick(object? sender, RoutedEventArgs e)
            => LabWork22ViewModel.LabWork22ViewModelInstanse.VisualDataReg();

        private void AddDataButton_OnClick(object? sender, RoutedEventArgs e)
            => LabWork22ViewModel.LabWork22ViewModelInstanse.AddDataReg();

        private void ShifrPasswordButton_OnClick(object? sender, RoutedEventArgs e)
            => LabWork22ViewModel.LabWork22ViewModelInstanse.Encrypt();

        private void UnShifrPasswordButton_OnClick(object? sender, RoutedEventArgs e)
            => LabWork22ViewModel.LabWork22ViewModelInstanse.Decrypt();
    }
}
