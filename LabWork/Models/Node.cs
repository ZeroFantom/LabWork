using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork.Models
{
    internal class Node
    {
        internal ObservableCollection<Node> SubFolders { get; set; }

        internal string FolderName { get; }
        internal string FullPath { get; }

        internal Node(string fullPath)
        {
            FullPath = fullPath;
            FolderName = Path.GetFileName(fullPath);
        }
    }

}
