namespace LabWork.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        internal static MainWindowViewModel InstaMainWindowViewModel;
        internal new string Title => "Главная страница";

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
