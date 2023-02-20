namespace LabWork.Views.PageLabWork
{
    public partial class LabWork12_14 : UserControl
    {
        public LabWork12_14()
        {
            InitializeComponent();
        }

        private void BrowseFolderButton_OnClick(object? sender, RoutedEventArgs e)
            => new TreeFolderBrowserWindow
            {
                DataContext = new TreeFolderBrowserWindowViewModel()
            }.Show();

        private void FindButton_OnClick(object? sender, RoutedEventArgs e)
        {
            try
            {
                InstancelabWork12_14ViewModel.MaxSizeFile = long.Parse(MaxSizeFileBox.Text ?? "0");
                InstancelabWork12_14ViewModel.MinSizeFile = long.Parse(MinSizeFileBox.Text ?? "0");
                InstancelabWork12_14ViewModel.MinDataCreationFile = DateTimePickerPanel.SelectedDate?.DateTime ?? DateTime.Now;

                InstancelabWork12_14ViewModel.FindFile(InstanceBrowserWindowViewModel.SelectedNode.FullPath, FileName.Text ?? string.Empty);
                InstancelabWork12_14ViewModel.FolderName = InstanceBrowserWindowViewModel.SelectedNode.FolderName;

                MessagesApp.System_Message("Данные в отчёте успешно обновлены!",FindButton,sender);
            }
            catch (Exception)
            {
                MessagesApp.System_Message("Обновить данные не удалось!", FindButton, sender);
            }
        }
    }
}
