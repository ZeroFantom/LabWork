namespace LabWork.ViewModels.AdditionalFunctionality
{
    internal class TreeFolderBrowserWindowViewModel : ViewModelBase
    {
        internal string RootFolder => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public new string Title => "Ветка Директорий";
        internal static TreeFolderBrowserWindowViewModel InstanceBrowserWindowViewModel { get; private set; }
        internal ObservableCollection<Node> Items { get; } = new();
        internal Node SelectedNode { get; set; }

        internal TreeFolderBrowserWindowViewModel()
        {
            Task.Run(async () =>{
                var rootNode = new Node(RootFolder);

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    Items.Add(rootNode);
                    InstanceBrowserWindowViewModel = this;
                });
            });
                
        }
    }
}
