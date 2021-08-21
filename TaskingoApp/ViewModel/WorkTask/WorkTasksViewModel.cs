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
            if(!Properties.Settings.Default.TaskFilter.Equals("All"))
                workTaskViewModels.AddRange(TasksFromApi
                    .Where(x=> x.Status.Contains(Properties.Settings.Default.TaskFilter))
                    .ToList());
            else
                workTaskViewModels.AddRange(TasksFromApi);

        }
        public WorkTasksViewModel()
        {
            _workTaskModels = new WorkTasksModel();
            DownloadTasks();
            

        }
        private void DownloadTasks()
        {
            Task.Run(() =>
            {
                _workTaskModels.GetUsersModelsList().Wait();
                CopyFromModel();
            });
        }

        private string _searchingTask;

        public string SearchingTask
        {
            get => _searchingTask;
            set
            {
                _searchingTask = value;
                ShowTasks();
            }
        }
        private void ShowTasks()
        {
            if (string.IsNullOrEmpty(_searchingTask))
                DownloadTasks();
            var searchingUsersFromApi = TasksFromApi.Where(

                x =>
                {
                    var searchingByTitle = x.Title.Contains(_searchingTask);
                    if (x.AssignedUser != null)
                        return x.AssignedUser.Email.Equals(_searchingTask) || searchingByTitle;
                    return searchingByTitle;
                }
                   )
                .ToList();
            if(!Properties.Settings.Default.TaskFilter.Equals("All")) searchingUsersFromApi
                .Where(x => x.Status.Contains(Properties.Settings.Default.TaskFilter));
            workTaskViewModels.Clear();
            workTaskViewModels.AddRange(searchingUsersFromApi);
        }

    }
}
