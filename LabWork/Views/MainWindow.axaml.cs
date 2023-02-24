using static LabWork.ViewModels.PageLabWork.LabWork19ViewModel;
using static LabWork.ViewModels.PageLabWork.LabWork15ViewModel;
using static LabWork.ViewModels.AdditionalFunctionality.DataReportViewModel;
using static LabWork.ViewModels.PageLabWork.LabWork12_14_21ViewModel;

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
            => InstaMainWindowViewModel.Page = new LabWork12_14_21
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
    }
}
