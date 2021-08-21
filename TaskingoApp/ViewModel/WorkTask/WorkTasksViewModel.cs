using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Components;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;
using TaskingoApp.ViewModel.Users;

namespace TaskingoApp.ViewModel.WorkTask
{
    public class WorkTasksViewModel : ViewModelBase
    {
        private WorkTasksModel _workTaskModels;
        public AsyncObservableCollection<WorkTaskViewModel> workTaskViewModels { get; set; } = new AsyncObservableCollection<WorkTaskViewModel>();
        private static AsyncObservableCollection<WorkTaskViewModel> TasksFromApi { get; set; } = new AsyncObservableCollection<WorkTaskViewModel>();


        public void CopyFromModel()
        {
            workTaskViewModels.Clear();
            TasksFromApi.Clear();
            foreach (var task in _workTaskModels)
                TasksFromApi.Add(new WorkTaskViewModel(task));
            workTaskViewModels.AddRange(TasksFromApi);

        }
        public WorkTasksViewModel()
        {
            _workTaskModels = new WorkTasksModel();
            DownloadUsers();

        }
        private void DownloadUsers()
        {
            Task.Run(() =>
            {
                _workTaskModels.GetUsersModelsList().Wait();
                CopyFromModel();
            });
        }
    }
}
