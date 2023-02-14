using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using LabWork.Models;
using LabWork.ViewModels;
using LabWork.ViewModels.PageLabWork;
using LabWork.Views.PageLabWork;
using static LabWork.ViewModels.MainWindowViewModel;
namespace LabWork.Views
{
    public partial class MainWindow : CustomUI
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LabWork12_OnClick_OnClick(object? sender, RoutedEventArgs e)
            => InstaMainWindowViewModel.Page = new LabWork12
            {
                DataContext = new LabWork12ViewModel()
            };

        private void LabWork14_OnClick(object? sender, RoutedEventArgs e)
        {

        }
    }
}
