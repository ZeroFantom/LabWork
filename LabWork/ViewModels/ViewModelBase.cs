namespace LabWork.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        //�������� ���������
        internal static ViewModelBase Instance;

        /// <summary>
        /// https://fonts-online.ru/fonts.
        /// </summary>
        internal FontFamily FontWindow => "avares://LabWork/Assets/FontFamily/0.ttf#American TextC";

        /// <summary>
        /// �������� ����������.
        /// </summary>
        internal string Title;

        /// <summary>
        /// ���� ����.
        /// </summary>
        internal IBrush BackGroundWindow => Brush.Parse("#222831");

        /// <summary>
        /// ���� ������ � ����.
        /// </summary>
        internal IBrush ForeGroundWindow => Brush.Parse("#00ADB5");

        /// <summary>
        /// ���� ������� ���� ������ � ����.
        /// </summary>
        internal IBrush BackGroundButton => Brush.Parse("#222831");

        /// <summary>
        /// ���� ������� ���� ����������� ���������.
        /// </summary>
        internal IBrush BackGroundToolTip => Brush.Parse("#222831");

        /// <summary>
        /// ��������� ���� ����, ���������.
        /// </summary>
        internal IBrush SecondBackGroundWindow => Brush.Parse("#393E46");

        /// <summary>
        /// ��� ����������� ������ �������� ����������.
        /// </summary>
        internal Uri HideGif => new("avares://LabWork/Assets/hide.gif", UriKind.RelativeOrAbsolute);

        /// <summary>
        /// ��� ����������� ������ �������� ����������.
        /// </summary>
        internal Uri ExitGif => new("avares://LabWork/Assets/exit.gif", UriKind.RelativeOrAbsolute);

        /// <summary>
        /// ����������� ���� ����������.
        /// </summary>
        internal Uri WindowBackGround => new("avares://LabWork/Assets/loadAndBackgroundWindow.gif",
            UriKind.RelativeOrAbsolute);

        internal Uri PasswordEaysGif => new("avares://LabWork/Assets/eays.gif", UriKind.RelativeOrAbsolute);
        //��������� ���������� ������.

        /// <summary>
        /// ���������� ������ ��������. 
        /// </summary>
        double _heightWindow = PrimaryScreenHeight - 320;

        /// <summary>
        /// UI ��������, �������� ������ ���������� ������.
        /// </summary>
        internal double HeightWindow
        {
            get => _heightWindow;
            set => this.RaiseAndSetIfChanged(ref _heightWindow, value);

        }

        /// <summary>
        /// ���������� ������ ��������.
        /// </summary>
        double _widthWindow = PrimaryScreenWidth - 280;

        /// <summary>
        /// UI ��������, �������� ������ ���������� ������.
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
