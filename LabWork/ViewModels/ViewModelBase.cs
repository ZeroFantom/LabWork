namespace LabWork.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        //Основные параметры
        internal static ViewModelBase Instance;

        /// <summary>
        /// https://fonts-online.ru/fonts.
        /// </summary>
        internal FontFamily FontWindow => "avares://LabWork/Assets/FontFamily/0.ttf#American TextC";

        /// <summary>
        /// Название приложения.
        /// </summary>
        internal string Title;

        /// <summary>
        /// Цвет окна.
        /// </summary>
        internal IBrush BackGroundWindow => Brush.Parse("#222831");

        /// <summary>
        /// Цвет текста в окне.
        /// </summary>
        internal IBrush ForeGroundWindow => Brush.Parse("#00ADB5");

        /// <summary>
        /// Цвет заднего фона кнопок в окне.
        /// </summary>
        internal IBrush BackGroundButton => Brush.Parse("#222831");

        /// <summary>
        /// Цвет заднего фона всплывающих подсказок.
        /// </summary>
        internal IBrush BackGroundToolTip => Brush.Parse("#222831");

        /// <summary>
        /// Вторичный цвет окна, внутрений.
        /// </summary>
        internal IBrush SecondBackGroundWindow => Brush.Parse("#393E46");

        /// <summary>
        /// Гиф изображение значка сокрытия приложения.
        /// </summary>
        internal Uri HideGif => new("avares://LabWork/Assets/hide.gif", UriKind.RelativeOrAbsolute);

        /// <summary>
        /// Гиф изображение значка закрытия приложения.
        /// </summary>
        internal Uri ExitGif => new("avares://LabWork/Assets/exit.gif", UriKind.RelativeOrAbsolute);

        /// <summary>
        /// Изображение фона приложения.
        /// </summary>
        internal Uri WindowBackGround => new("avares://LabWork/Assets/loadAndBackgroundWindow.gif",
            UriKind.RelativeOrAbsolute);

        internal Uri PasswordEaysGif => new("avares://LabWork/Assets/eays.gif", UriKind.RelativeOrAbsolute);
        //Настройка разрешения экрана.

        /// <summary>
        /// Адаптивная высота лаунчера. 
        /// </summary>
        double _heightWindow = PrimaryScreenHeight - 320;

        /// <summary>
        /// UI свойство, привязка данных адаптивной высоты.
        /// </summary>
        internal double HeightWindow
        {
            get => _heightWindow;
            set => this.RaiseAndSetIfChanged(ref _heightWindow, value);

        }

        /// <summary>
        /// Адаптивная ширина лаунчера.
        /// </summary>
        double _widthWindow = PrimaryScreenWidth - 280;

        /// <summary>
        /// UI свойство, привязка данных адаптивной ширины.
        /// </summary>
        internal double WidthWindow
        {
            get => _widthWindow;
            set => this.RaiseAndSetIfChanged(ref _widthWindow, value);
        }

        public ViewModelBase()
        {
            Instance = this;
        }
    }
}
