using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using LibVLCSharp.Shared;

namespace LabWork.ViewModels.PageLabWork
{
    internal class LabWork15ViewModel : ViewModelBase
    {
        internal static LabWork15ViewModel InstancelabWork15ViewModel { get; private set; } = new();

        public Window? Owner = null;
        private string infoFile = "Файл не выбран!";

        public string InfoFile
        {
            get => infoFile; 
            set => this.RaiseAndSetIfChanged(ref infoFile, value);
        }
        public double? HeightImage
        {
            get => heightImage;
            set => this.RaiseAndSetIfChanged(ref heightImage, value);
        }

        public double? WidthImage
        {
            get => widthImage;
            set => this.RaiseAndSetIfChanged(ref widthImage, value);
        }

        private double? heightImage = null;
        private double? widthImage = null;
        
        public int? CF;

        private IBitmap? imageBitmap;
        public IBitmap? ImageFile
        {
            get => imageBitmap;
            set => this.RaiseAndSetIfChanged(ref imageBitmap, value);
        }

        internal LabWork15ViewModel()
        {
            InstancelabWork15ViewModel = this;
        }
    }
}
