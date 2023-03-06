using static LabWork.ViewModels.PageLabWork.LabWork12_14_21ViewModel;

namespace LabWork.Views.PageLabWork
{
    public partial class LabWork121421 : UserControl
    {
        public LabWork121421()
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
                InstancelabWork121421ViewModel.FolderName = InstanceBrowserWindowViewModel.SelectedNode.FolderName;
                InstancelabWork121421ViewModel.FindFile(InstanceBrowserWindowViewModel.SelectedNode.FullPath, FileName.Text ?? string.Empty);
                
                MessagesApp.System_Message("Данные в отчёте успешно обновлены!",FindButton,sender);
            }
            catch (Exception)
            {
                MessagesApp.System_Message("Обновить данные не удалось!", FindButton, sender);
            }
        }
    }
}
