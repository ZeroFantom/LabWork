namespace LabWork.Models
{
    internal struct Node
    {
        private static string RootFolder 
            => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        internal ObservableCollection<Node> SubFolders { get; set; }

        internal string? FolderName { get; }
        internal string FullPath { get; }

        internal Node(string path)
        {
            FullPath = path;
            SubFolders = GetSubfolders(FullPath);
            var targetDir = new DirectoryInfo(FullPath);
            FolderName = targetDir.Name;
        }

        public Node() : this(RootFolder)
        {
        }

        private ObservableCollection<Node> GetSubfolders(string strPath)
        {
            var subDirs = Directory.GetDirectories(strPath, "*", SearchOption.TopDirectoryOnly).ToList();

            var subfolders = new ObservableCollection<Node>();

            foreach (var dir in subDirs)
            {
                var thisNode = new Node(dir);

                if (Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly).Length > 0)
                {
                    thisNode.SubFolders = new ObservableCollection<Node>();
                    thisNode.SubFolders = GetSubfolders(dir);
                }

                subfolders.Add(thisNode);
            }

            return subfolders;
        }
    }

}
