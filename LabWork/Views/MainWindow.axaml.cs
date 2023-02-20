namespace LabWork.Views
{
    public partial class MainWindow : CustomUI
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LabWork12_OnClick_OnClick(object? sender, RoutedEventArgs e)
            => InstaMainWindowViewModel.Page = new LabWork12_14
            {
                DataContext = new LabWork12_14ViewModel()
            };

        private void DataReport_OnClick(object? sender, RoutedEventArgs e)
            => new DataReport
            {
                DataContext = new DataReportViewModel()
            }.Show();

        private void LabWork15_OnClick(object? sender, RoutedEventArgs e)
        {
            var lab15 = new LabWork15ViewModel
            {
                Owner = this
            };

            InstaMainWindowViewModel.Page = new LabWork15
            {
                DataContext = lab15
            };
        }
    }
}
