using Mvvm.CommonInteractions;
using System.Security.Cryptography;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using System.Security.Policy;
using AutoMapper;
using System.Linq;

namespace LabWork.ViewModels.PageLabWork
{
    internal class LabWork12_14_21ViewModel : ViewModelBase
    {
        internal static LabWork12_14_21ViewModel InstancelabWork121421ViewModel { get; private set; } = new();

        #region ToggleButtonOptions

        private bool _isRecurseSubdirectories = false;
        internal bool IsRecurseSubdirectories { get => _isRecurseSubdirectories; set => this.RaiseAndSetIfChanged(ref _isRecurseSubdirectories, value); }

        private bool _isEnabledFileSize = false;
        internal bool IsEnabledFileSize { get => _isEnabledFileSize; set => this.RaiseAndSetIfChanged(ref _isEnabledFileSize, value); }
        
        private bool _isEnabledCreationDateFile = false;
        internal bool IsEnabledCreationDateFile { get => _isEnabledCreationDateFile; set => this.RaiseAndSetIfChanged(ref _isEnabledCreationDateFile, value); }

        private bool _isEnabledDuplicate = false;
        internal bool IsEnabledDuplicate { get => _isEnabledDuplicate; set => this.RaiseAndSetIfChanged(ref _isEnabledDuplicate, value); }

        private bool _isEnabledHash = false;
        internal bool IsEnabledHash { get => _isEnabledHash; set => this.RaiseAndSetIfChanged(ref _isEnabledHash, value); }
        #endregion


        #region OptionsFindFile

        private DateTimeOffset? _minDataCreationFile = null;
        private long? _minSizeFile = null;
        private long? _maxSizeFile = null;

        internal DateTimeOffset? MinDataCreationFile
        {
            get => _minDataCreationFile;
            set => this.RaiseAndSetIfChanged(ref _minDataCreationFile, value);
        }
        internal long? MinSizeFile
        {
            get => _minSizeFile;
            set => this.RaiseAndSetIfChanged(ref _minSizeFile, value);
        }
        internal long? MaxSizeFile
        {
            get => _maxSizeFile;
            set => this.RaiseAndSetIfChanged(ref _maxSizeFile, value);
        }

        private string? fileHash = null;

        internal string? FileHash
        {
            get => fileHash;
            set => this.RaiseAndSetIfChanged(ref fileHash, value);
        }

        #region FolderNameNPChanged

        private string? folderName = "Каталог не определён";
        internal string? FolderName
        {
            get => folderName;
            set => this.RaiseAndSetIfChanged(ref folderName, value);
        }

        #endregion

        #endregion


        internal LabWork12_14_21ViewModel()
        {
            InstancelabWork121421ViewModel = this;
        }


        internal void FindFile(string folderFullPath,string fileName)
        {
            if (!IsEnabledFileSize)
            {
                MinSizeFile = 0;
                MaxSizeFile = 0;
            }

            if (!IsEnabledCreationDateFile)
            {
                MinDataCreationFile = DateTime.Now;
            }

            if (FolderName != null)
            {
                Data.ObjectDataReport.AddRange(
                    Directory.EnumerateFiles(folderFullPath, $"{fileName}.*",
                            new EnumerationOptions { RecurseSubdirectories = IsRecurseSubdirectories })
                        .Select(x =>
                        {
                            var fileInfoWithHash = GetFileInfoWithHash(x);
                            return fileInfoWithHash;
                        })
                        .Where(x => IsFileSelected(x, fileName))
                        .Where(IsCreationDateInRange)
                        .Where(IsFileSizeInRange)
                        .Select(x=>(dynamic)(IsEnabledHash ? x : new FileInfo(x.FullName)))
                );
            }
        }
        private FileInfoWithHash GetFileInfoWithHash(string filePath)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FileInfo, FileInfoWithHash>()
                    .ForMember(dest => dest.Hash, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        using var md5 = MD5.Create();
                        using var stream = File.OpenRead(src.FullName);
                        var hash = md5.ComputeHash(stream);
                        var hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                        dest.Hash = hashString;
                    });
            });

            var fileInfoWithHash = new Mapper(mapperConfig).Map<FileInfoWithHash>(new FileInfo(filePath));
            return fileInfoWithHash;
        }

        private bool IsFileSelected(FileInfoWithHash fileInfo, string fileName)
        {
            if (!IsEnabledDuplicate)
            {
                return true;
            }

            if (IsEnabledHash)
            {
                return fileInfo.Hash.Equals(FileHash, StringComparison.CurrentCulture);
            }

            return fileInfo.Name.Equals(fileName + fileInfo.Extension, StringComparison.CurrentCulture);
        }

        private bool IsCreationDateInRange(FileInfoWithHash fileInfo)
        {
            if (!IsEnabledCreationDateFile)
            {
                return true;
            }

            return fileInfo.CreationTime >= MinDataCreationFile!.Value;
        }

        private bool IsFileSizeInRange(FileInfoWithHash fileInfo)
        {
            if (!IsEnabledFileSize)
            {
                return true;
            }

            var fileSize = fileInfo.Length / 1024;
            return fileSize >= MinSizeFile && fileSize <= MaxSizeFile;
        }

        public class FileInfoWithHash
        {
            public string Name { get; set; }
            public string FullName { get; set; }
            public string Extension { get; set; }
            public string DirectoryName { get; set; }
            public long Length { get; set; }
            public string Hash { get; set; }
            public DateTime CreationTime { get; set; }
            public DateTime LastWriteTime { get; set; }
        }
    }

}
