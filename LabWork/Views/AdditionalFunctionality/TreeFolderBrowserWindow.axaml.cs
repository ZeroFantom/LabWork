using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Styling;
using LabWork.Models;
using static LabWork.ViewModels.AdditionalFunctionality.TreeFolderBrowserWindowViewModel;

namespace LabWork.Views.AdditionalFunctionality
{
    public partial class TreeFolderBrowserWindow : CustomUI
    {
        public TreeFolderBrowserWindow()
        {
            InitializeComponent();
        }

        private void BrowseFolderCustom_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
            => InstanceBrowserWindowViewModel.SelectedNode = (Node)BrowseFolderCustom.SelectedItems[0];
    }
}
