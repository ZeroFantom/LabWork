using Avalonia.Controls;
using static LabWork.ViewModels.PageLabWork.LabWork26ViewModel;
namespace LabWork.Views.PageLabWork
{
    public partial class LabWork26 : UserControl
    {
        public LabWork26()
        {
            InitializeComponent();
        }

        private async void ListPadButton_OnClick(object? sender, RoutedEventArgs e)
         => await LabWork26ViewModelInstanse.CanSearch();

        private async void DownloadImageButton_OnClick(object? sender, RoutedEventArgs e)
         =>await LabWork26ViewModelInstanse.DownloadFile();

        private async void OneIdPostButton_OnClick(object? sender, RoutedEventArgs e)
            => JsonTextBlock.Text = await LabWork26ViewModelInstanse.GetPosts(false);

        private async void AllPostButton_OnClick(object? sender, RoutedEventArgs e)
            => JsonTextBlock.Text = await LabWork26ViewModelInstanse.GetPosts();
    }
}
