namespace LabWork.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        internal static MainWindowViewModel InstaMainWindowViewModel { get; set; } = new();
        internal new string Title => "������� ��������";

        private UserControl? page;
        internal UserControl? Page
        {
            get => page;
            set => this.RaiseAndSetIfChanged(ref page, value);
        }

        public MainWindowViewModel()
        {
            InstaMainWindowViewModel = this;
        }
    }
}
