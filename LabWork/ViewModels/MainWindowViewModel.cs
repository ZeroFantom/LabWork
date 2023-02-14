using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using LabWork.ViewModels.PageLabWork;

namespace LabWork.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        internal static MainWindowViewModel InstaMainWindowViewModel;
        internal new string Title => "Главная страница";

        private UserControl? page = null;
        internal UserControl? Page
        {
            get => page;
            set { this.RaiseAndSetIfChanged(ref page, value); }
        }

        public MainWindowViewModel()
        {
            InstaMainWindowViewModel = this;
        }
    }
}
