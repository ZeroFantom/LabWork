using DynamicData;
using Microsoft.Win32;
using Mvvm.CommonInteractions;
using System.IO.Compression;

namespace LabWork.ViewModels.PageLabWork
{
    internal class LabWork19ViewModel : ViewModelBase
    {
        public static LabWork19ViewModel LabWork19ViewModelInstanse { get; private set; } = new();


        private bool isEnableDirectory;
        public bool IsEnableDirectory
        {
            get => isEnableDirectory;
            set => this.RaiseAndSetIfChanged(ref isEnableDirectory, value);
        }

        private string catalogName = string.Empty;
        public string CatalogName
        {
            get => catalogName;
            set => this.RaiseAndSetIfChanged(ref catalogName, value);
        }

        private string arhiveName = string.Empty;
        public string ArhiveName
        {
            get => arhiveName;
            set => this.RaiseAndSetIfChanged(ref arhiveName, value);
        }

        private string fileName = string.Empty;
        public string FileName
        {
            get => fileName;
            set => this.RaiseAndSetIfChanged(ref fileName, value);
        }

        public LabWork19ViewModel()
        {
            LabWork19ViewModelInstanse = this;
        }

        public void OpenDataFileArhive()
        {
            if (string.IsNullOrWhiteSpace(ArhiveName)) return;

            using var archive = ZipFile.OpenRead(ArhiveName);

            Func<ZipArchiveEntry, bool> filterFunc = IsEnableDirectory ?
                x => !x.FullName.Contains(".") :
                x => x.FullName.Contains(".");

            Data.ObjectDataReport.AddRange(archive.Entries.Where(filterFunc).Select(x =>
            {
                var paths = x.FullName.Split('/').Where(dirName => !string.IsNullOrEmpty(dirName)).ToList();
                paths.RemoveAt(0);
                var path = Path.Combine(ArhiveName, Path.GetFileNameWithoutExtension(ArhiveName),
                    string.Join(Path.DirectorySeparatorChar, paths));
                return filterFunc == (Func<ZipArchiveEntry, bool>)(y => !y.FullName.Contains(".")) ?
                    (FileSystemInfo)new DirectoryInfo(path) :
                    new FileInfo(path);
            }));
        }

        public void Arhivator()
        {
            if (File.Exists(ArhiveName))
            {
                File.Delete(ArhiveName);
            }

            ZipFile.CreateFromDirectory(CatalogName, ArhiveName);
        }

        public void DiArhivator()
        {
            if (Directory.Exists(CatalogName))
            {
                Directory.Delete(CatalogName, true);
            }

            ZipFile.ExtractToDirectory(ArhiveName, CatalogName);
        }

        public void UpdateArhive()
        {
            using var archive = ZipFile.Open(ArhiveName, ZipArchiveMode.Update);

            archive.CreateEntryFromFile(FileName, Path.GetFileName(FileName));
        }
    }
}
