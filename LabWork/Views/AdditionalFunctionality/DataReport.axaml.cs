using System.Collections.Specialized;
using Avalonia.Controls;
using Windows.Media.Protection.PlayReady;

namespace LabWork.Views.AdditionalFunctionality
{
    public partial class DataReport : CustomUI
    {
        int PageCount;
        int RemainRow;

        dynamic _dataObject;
        dynamic DataObject
        {
            get => _dataObject;
            set
            {
                _dataObject = value;

                if (_dataObject.Count > 0)
                {
                    PageCount = _dataObject.Count / 10;

                    var remainsRow = _dataObject.Count % 10;
                    if (remainsRow != 0)
                    {
                        PageCount += 1;
                        RemainRow = remainsRow;
                    }
                }
                PageData = 1;
            }
        }

        int pageData = 1;
        int PageData
        {
            get => pageData;
            set
            {
                pageData = value;
                PageBox.Text = pageData.ToString();

                if (pageData != 1)
                {
                    if (pageData != PageCount)
                        TableData.Items = DataOperateAndSkip((pageData - 1) * 10, 10, DataObject);
                    else
                    {
                        if (RemainRow != 0)
                        {
                            TableData.Items = TableData.Items = DataOperateAndSkip((pageData - 1) * 10, RemainRow, DataObject);
                        }
                        else
                        {
                            TableData.Items = TableData.Items = DataOperateAndSkip((pageData - 1) * 10, 10, DataObject);
                        }
                    }

                }
                else
                {
                    if (DataObject.Count >= 10)
                    {
                        TableData.Items = DataOperate(10, DataObject);
                    }
                    else
                    {
                        if (RemainRow != 0)
                        {
                            TableData.Items = DataOperate(RemainRow, DataObject);
                        }
                    }
                }
            }
        }

        public DataReport()
        {
            InitializeComponent();

            DataObject = Data.ObjectDataReport;
            Data.ObjectDataReport.CollectionChanged += (sender, args) 
                =>
            {
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    DataObject = Data.ObjectDataReport;
                }
            };
        }

        void SetDataReport_OnClick(object? sender, RoutedEventArgs e)
        {
            DataObject = Data.ObjectDataReport;
            Data.ObjectDataReport.Clear();
            PageData = 1;
        }

        void PageUp_OnClick(object? sender, RoutedEventArgs e)
        {
            if (PageCount is 1 or 0 || pageData > PageCount) return;

            PageData += 1;
        }

        void PageDown_OnClick(object? sender, RoutedEventArgs e)
        {
            if (pageData == 1) return;

            PageData -= 1;
        }

        void PageChanged_OnTextChanged(object? sender, TextChangedEventArgs e)
        {
            if (int.TryParse(PageBox.Text, out var resultParse))
            {
                PageData = resultParse != 0 ? resultParse : 1;
            }
        }

        IEnumerable<dynamic> DataOperate(int count, ObservableCollection<dynamic> listData)
        {
            return listData.Take(count);
        }
        IEnumerable<dynamic> DataOperateAndSkip(int countSkip, int count, ObservableCollection<dynamic> listData)
        {
            return listData.Skip(countSkip).Take(count);
        }
    }
}
