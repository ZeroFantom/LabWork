using Avalonia.Controls.Primitives;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LabWork.Views.PageLabWork.LibLabWork12
{
    public partial class LabWork12 : UserControl
    {
        public LabWork12()
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
                InstancelabWork12ViewModel.MaxSizeFile = long.Parse(MaxSizeFileBox.Text ?? "0");
                InstancelabWork12ViewModel.MinSizeFile = long.Parse(MinSizeFileBox.Text ?? "0");
                InstancelabWork12ViewModel.MinDataCreationFile = DateTimePickerPanel.SelectedDate?.DateTime ?? DateTime.Now;

                InstancelabWork12ViewModel.FindFile(InstanceBrowserWindowViewModel.SelectedNode.FullPath, FileName.Text ?? string.Empty);
                InstancelabWork12ViewModel.FolderName = InstanceBrowserWindowViewModel.SelectedNode.FolderName;

                MessagesApp.System_Message("Данные в отчёте успешно обновлены!",FindButton,sender);
            }
            catch (Exception)
            {
                MessagesApp.System_Message("Обновить данные не удалось!", FindButton, sender);
            }
        }
    }
}
