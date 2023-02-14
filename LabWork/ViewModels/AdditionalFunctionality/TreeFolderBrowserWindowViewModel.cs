using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Threading;
using LabWork.Models;

namespace LabWork.ViewModels.AdditionalFunctionality
{
    internal class TreeFolderBrowserWindowViewModel : ViewModelBase
    {
        internal const string RootFolder = @"C:\\Users\User\Desktop";
        public new string Title => "Ветка Директорий";
        internal static TreeFolderBrowserWindowViewModel InstanceBrowserWindowViewModel { get; private set; }
        internal ObservableCollection<Node> Items { get; } = new();
        internal Node SelectedNode { get; set; }

        internal TreeFolderBrowserWindowViewModel()
        {
            var rootNode = new Node(RootFolder);

            Task.Run(async () =>
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    rootNode.SubFolders = GetSubfolders(rootNode.FullPath);
                    Items.Add(rootNode);
                    InstanceBrowserWindowViewModel = this;
                }));
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
