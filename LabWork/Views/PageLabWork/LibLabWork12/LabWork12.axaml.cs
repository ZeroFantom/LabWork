using Avalonia.Controls;
using Avalonia.Interactivity;
using LabWork.Models;
using LabWork.ViewModels.AdditionalFunctionality;
using LabWork.ViewModels.PageLabWork;
using LabWork.Views.AdditionalFunctionality;
using static LabWork.ViewModels.PageLabWork.LabWork12ViewModel;
using static LabWork.ViewModels.AdditionalFunctionality.TreeFolderBrowserWindowViewModel;

namespace LabWork.Views.PageLabWork
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
                if (InstanceBrowserWindowViewModel != null)
                {
                    InstancelabWork12ViewModel.FindFile(DataFiles,
                        InstanceBrowserWindowViewModel.SelectedNode.FullPath, FileName.Text);
                    InstancelabWork12ViewModel.FolderName = InstanceBrowserWindowViewModel.SelectedNode.FolderName;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}