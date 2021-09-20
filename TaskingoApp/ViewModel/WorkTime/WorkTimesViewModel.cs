using System.Threading.Tasks;
using TaskingoApp.Components;
using TaskingoApp.Model.WorkTime;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTime
{
    public class WorkTimesViewModel : ViewModelBase
    {
        private readonly WorkTimesModel workTimesModel;
        public AsyncObservableCollection<WorkTimeViewModel> WorkTimeModels { get; set; } = new AsyncObservableCollection<WorkTimeViewModel>();

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
            WorkTimeModels.Clear();
            foreach (var time in workTimesModel)
                WorkTimeModels.Add(new WorkTimeViewModel(time));

        }
    }
}
