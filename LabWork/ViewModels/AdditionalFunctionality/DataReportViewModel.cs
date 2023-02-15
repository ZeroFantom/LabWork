﻿namespace LabWork.ViewModels.AdditionalFunctionality
{
    internal class DataReportViewModel : ViewModelBase
    {
        internal static DataReportViewModel InstanceDataReportViewModel { get; private set; }

        public new string Title => "Отчёт";

        internal DataReportViewModel()
        {
            InstanceDataReportViewModel = this;
        }
    }
}
