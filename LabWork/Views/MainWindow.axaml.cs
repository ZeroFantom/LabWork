using static LabWork.ViewModels.PageLabWork.LabWork19ViewModel;
using static LabWork.ViewModels.PageLabWork.LabWork15ViewModel;
using static LabWork.ViewModels.AdditionalFunctionality.DataReportViewModel;
using static LabWork.ViewModels.PageLabWork.LabWork12_14_21ViewModel;
using static LabWork.ViewModels.PageLabWork.LabWork22ViewModel;
using static LabWork.ViewModels.PageLabWork.LabWork26ViewModel;

namespace LabWork.Views
{
    public partial class MainWindow : CustomUI
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LabWork19_OnClick(object? sender, RoutedEventArgs e)
            => InstaMainWindowViewModel.Page = new LabWork19
            {
                DataContext = LabWork19ViewModelInstanse
            };

        private void LabWork12_14_OnClick(object? sender, RoutedEventArgs e)
            => InstaMainWindowViewModel.Page = new LabWork121421
            {
                DataContext = InstancelabWork121421ViewModel
            };

        private void DataReport_OnClick(object? sender, RoutedEventArgs e)
            => new DataReport
            {
                DataContext = InstanceDataReportViewModel
            }.Show();
        
        private void LabWork15_OnClick(object? sender, RoutedEventArgs e)
        {
            InstancelabWork15ViewModel.Owner = this;

            InstaMainWindowViewModel.Page = new LabWork15
            {
                DataContext = InstancelabWork15ViewModel
            };
        }

        private void LabWork26_OnClick(object? sender, RoutedEventArgs e)
            => InstaMainWindowViewModel.Page = new LabWork26()
            {
                DataContext = LabWork26ViewModelInstanse
            };
        private void LabWork22_OnClick(object? sender, RoutedEventArgs e)
            => InstaMainWindowViewModel.Page = new LabWork22
            {
                DataContext = LabWork22ViewModelInstanse
            };
    }
}
