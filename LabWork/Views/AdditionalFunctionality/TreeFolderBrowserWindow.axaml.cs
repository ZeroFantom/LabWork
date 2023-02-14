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
