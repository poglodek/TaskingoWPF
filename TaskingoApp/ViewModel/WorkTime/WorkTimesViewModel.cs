using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.Components;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTime
{
    public class WorkTimesViewModel : ViewModelBase
    {
        private WorkTimesModel workTimesModel;
        public AsyncObservableCollection<WorkTimeViewModel> workTimeModels { get; set; } = new AsyncObservableCollection<WorkTimeViewModel>();

        public WorkTimesViewModel()
        {
            workTimesModel = new WorkTimesModel();
            DownloadWorkTimeData();
        }
        private void DownloadWorkTimeData()
        {
            Task.Run(() =>
            {
                workTimesModel.GetWorkTime().Wait();
                CopyFromModel();
            });
        }
        public void CopyFromModel()
        {
            workTimeModels.Clear();
            foreach (var time in workTimesModel)
                workTimeModels.Add(new WorkTimeViewModel(time));
            
        }
    }
}
