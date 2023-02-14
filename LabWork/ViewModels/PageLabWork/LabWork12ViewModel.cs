namespace LabWork.ViewModels.PageLabWork
{
    internal class LabWork12ViewModel : ViewModelBase
    {
        internal static LabWork12ViewModel InstancelabWork12ViewModel { get; private set; }

        #region ToggleButtonOptions

        private bool _isRecurseSubdirectories = false;
        internal bool IsRecurseSubdirectories { get => _isRecurseSubdirectories; set => this.RaiseAndSetIfChanged(ref _isRecurseSubdirectories, value); }

        private bool _isEnabledFileSize = false;
        internal bool IsEnabledFileSize { get => _isEnabledFileSize; set => this.RaiseAndSetIfChanged(ref _isEnabledFileSize, value); }
        
        private bool _isEnabledCreationDateFile = false;
        internal bool IsEnabledCreationDateFile { get => _isEnabledCreationDateFile; set => this.RaiseAndSetIfChanged(ref _isEnabledCreationDateFile, value); }

        #endregion


        #region OptionsFindFile

        internal DateTime MinDataCreationFile { get; set; }
        internal long MaxSizeFile { get; set; }
        internal long MinSizeFile { get; set; }

        #region FolderNameNPChanged

        private string? folderName = "Каталог не определён";
        internal string? FolderName
        {
            get => folderName;
            set => this.RaiseAndSetIfChanged(ref folderName, value);
        }

        #endregion

        #endregion


        internal LabWork12ViewModel()
        {
            InstancelabWork12ViewModel = this;
        }

        
        internal void FindFile(DataGrid dataGrid, string folder, string fileName)
        {
            dataGrid.Items = Directory.GetFiles(folder, "*" + fileName + "*.*", new EnumerationOptions()
            {
                RecurseSubdirectories = IsRecurseSubdirectories
            }).Select(x => new FileInfo(x))
                .Where(x=>!IsEnabledCreationDateFile || (x.CreationTime >= MinDataCreationFile))
                .Where(x=>!IsEnabledFileSize || ( (x.Length / 1024) >= MinSizeFile && (x.Length / 1024) <= MaxSizeFile));
        }

    }
}
