using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.Components;
using TaskingoApp.Model.WorkTask;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTask
{
    public class WorkTasksViewModel : ViewModelBase
    {
        private WorkTasksModel _workTaskModels;
        public AsyncObservableCollection<WorkTaskViewModel> WorkTaskViewModels { get; set; } = new AsyncObservableCollection<WorkTaskViewModel>();
        private AsyncObservableCollection<WorkTaskViewModel> TasksFromApi { get; set; } = new AsyncObservableCollection<WorkTaskViewModel>();

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
                if (!string.IsNullOrEmpty(Properties.Settings.Default.TaskUserMail))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SearchingTask = Properties.Settings.Default.TaskUserMail;
                    });
                }

            });
        }
        public void CopyFromModel()
        {
            WorkTaskViewModels.Clear();
            TasksFromApi.Clear();
            foreach (var task in _workTaskModels)
                TasksFromApi.Add(new WorkTaskViewModel(task));
            if (!Properties.Settings.Default.TaskFilter.Equals("All"))
                WorkTaskViewModels.AddRange(TasksFromApi
                    .Where(x => x.Status.Contains(Properties.Settings.Default.TaskFilter))
                    .ToList());
            else
                WorkTaskViewModels.AddRange(TasksFromApi);

        }
        #region getters
        private WorkTaskViewModel _selectedTask;

        public WorkTaskViewModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                if (_selectedTask != null)
                    Properties.Settings.Default.TaskId = _selectedTask.Id;

            }
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
        #endregion

        #region searching
        private void ShowTasks()
        {
            Properties.Settings.Default.TaskUserMail = string.Empty;
            if (string.IsNullOrEmpty(_searchingTask))
                DownloadTasks();
            var searchingUsersFromApi = SelectTasks();
            WorkTaskViewModels.Clear();
            WorkTaskViewModels.AddRange(searchingUsersFromApi.ToList());
        }

        private IEnumerable<WorkTaskViewModel> SelectTasks()
        {
            var tasks = TasksFromApi.Where(

                x =>
                {
                    var searchingByTitle = x.Title.ToUpper().Contains(_searchingTask.ToUpper());
                    if (x.AssignedUser != null)
                        return x.AssignedUser.Email.ToUpper().Equals(_searchingTask.ToUpper()) || searchingByTitle;
                    return searchingByTitle;
                }
            );
            if (!Properties.Settings.Default.TaskFilter.Equals("All")) tasks
                .Where(x => x.Status.Contains(Properties.Settings.Default.TaskFilter));
            return tasks;
        }
        #endregion
    }
}
