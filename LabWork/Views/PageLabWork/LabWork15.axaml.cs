using Avalonia.Media.Imaging;
using OpenFileDialog = Avalonia.Controls.OpenFileDialog;
using UserControl = Avalonia.Controls.UserControl;
using static LabWork.ViewModels.PageLabWork.LabWork15ViewModel;

namespace LabWork.Views.PageLabWork
{
    public partial class LabWork15 : UserControl
    {
        public LabWork15()
        {
            InitializeComponent();
        }

        private void MenuItemMax_OnClick(object? sender, RoutedEventArgs e)
        {
            InstancelabWork15ViewModel.CF = 3;
            if (InstancelabWork15ViewModel.ImageFile == null) return;

            InstancelabWork15ViewModel.Owner!.WindowState = WindowState.Normal;
            InstancelabWork15ViewModel.HeightImage = InstancelabWork15ViewModel.ImageFile!.Size.Height * 2;
            InstancelabWork15ViewModel.WidthImage = InstancelabWork15ViewModel.ImageFile!.Size.Width * 2;
        }

        private void MenuItemHight_OnClick(object? sender, RoutedEventArgs e)
        {
            InstancelabWork15ViewModel.CF = 2;
            InstancelabWork15ViewModel.Owner!.WindowState = WindowState.Normal;
            if (InstancelabWork15ViewModel.ImageFile == null) return;
            InstancelabWork15ViewModel.HeightImage = InstancelabWork15ViewModel.ImageFile!.Size.Height;
            InstancelabWork15ViewModel.WidthImage = InstancelabWork15ViewModel.ImageFile!.Size.Width;
        }

        private void MenuItemLow_OnClick(object? sender, RoutedEventArgs e)
        {
            InstancelabWork15ViewModel.CF = 1;
            InstancelabWork15ViewModel.Owner!.WindowState = WindowState.Normal;
            if (InstancelabWork15ViewModel.ImageFile == null) return;
            InstancelabWork15ViewModel.HeightImage = InstancelabWork15ViewModel.ImageFile!.Size.Height / 2;
            InstancelabWork15ViewModel.WidthImage = InstancelabWork15ViewModel.ImageFile!.Size.Width / 2;
        }

        private void MenuItemFull_OnClick(object? sender, RoutedEventArgs e)
        {
            InstancelabWork15ViewModel.CF = null;
            InstancelabWork15ViewModel.Owner!.WindowState = WindowState.FullScreen;
            if (InstancelabWork15ViewModel.ImageFile == null) return;
            InstancelabWork15ViewModel.HeightImage = InstancelabWork15ViewModel.ImageFile!.Size.Height;
            InstancelabWork15ViewModel.WidthImage = InstancelabWork15ViewModel.ImageFile!.Size.Width;
        }

        private void MenuItemExit_OnClick(object? sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItemOpenFile_OnClick(object? sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new()
            {
                Filters = new List<FileDialogFilter>{new() { Extensions = new List<string>{ "*.jpg", "*.jpeg", "*.png" }, Name = "Image" }}
            };

            var file = Task.Run(async ()=>await openFileDialog.ShowAsync(InstancelabWork15ViewModel.Owner!)).Result;
            
            if (file != null)
            {
                var fileInfo = new FileInfo(file[0]);
                var image = new Bitmap(file[0]);
                switch (InstancelabWork15ViewModel.CF)
                {
                    case 1:
                        InstancelabWork15ViewModel.HeightImage = image.Size.Height / 2;
                        InstancelabWork15ViewModel.WidthImage = image.Size.Width / 2;
                        break;
                    case 2:
                        InstancelabWork15ViewModel.HeightImage = image.Size.Height;
                        InstancelabWork15ViewModel.WidthImage = image.Size.Width;
                        break;
                    case 3:
                        InstancelabWork15ViewModel.HeightImage = image.Size.Height * 2;
                        InstancelabWork15ViewModel.WidthImage = image.Size.Width * 2;
                        break;
                    default:
                        InstancelabWork15ViewModel.Owner!.WindowState = WindowState.FullScreen;
                        InstancelabWork15ViewModel.HeightImage = image.Size.Height;
                        InstancelabWork15ViewModel.WidthImage = image.Size.Width;
                        break;
                }

                InstancelabWork15ViewModel.ImageFile = image;
                InstancelabWork15ViewModel.InfoFile = $"Размер файла:{fileInfo.Length}байт Ширина:{image.PixelSize.Width} Высота:{image.PixelSize.Height}";
            }
        }

        private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            InstancelabWork15ViewModel.Owner!.WindowState = WindowState.Normal;
        }
    }
}
