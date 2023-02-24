namespace LabWork.ViewModels.AdditionalFunctionality
{
    internal class TreeFolderBrowserWindowViewModel : ViewModelBase
    {
        internal static TreeFolderBrowserWindowViewModel InstanceBrowserWindowViewModel { get; private set; } = new();
        internal new string Title => "Ветка Директорий";
        internal ObservableCollection<Node> Items { get; } = new();
        internal Node SelectedNode { get; set; }

        internal TreeFolderBrowserWindowViewModel()
        {
            Task.Run(async () =>{
                var rootNode = new Node();

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    Items.Add(rootNode);
                    InstanceBrowserWindowViewModel = this;
                });
            });
                
        }
    }
}
