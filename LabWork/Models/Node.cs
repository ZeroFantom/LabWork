namespace LabWork.Models
{
    internal struct Node
    {
        internal ObservableCollection<Node> SubFolders { get; set; }

        internal string? FolderName { get; }
        internal string FullPath { get; }

        internal Node(string fullPath)
        {
            FullPath = fullPath;
            SubFolders = GetSubfolders(FullPath);
            var targetDir = new DirectoryInfo(fullPath);
            FolderName = targetDir.Name;
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
