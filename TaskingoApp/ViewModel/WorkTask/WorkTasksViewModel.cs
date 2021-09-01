﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private AsyncObservableCollection<WorkTaskViewModel> TasksFromApi { get; set; } = new AsyncObservableCollection<WorkTaskViewModel>();


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
                if (!string.IsNullOrEmpty(Properties.Settings.Default.TaskUserMail))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SearchingTask = Properties.Settings.Default.TaskUserMail;
                    });
                }
                    
            });
        }


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
        private void ShowTasks()
        {
            Properties.Settings.Default.TaskUserMail = string.Empty;
            if (string.IsNullOrEmpty(_searchingTask))
                DownloadTasks();
            var searchingUsersFromApi = SelectTasks(); 
            workTaskViewModels.Clear();
            workTaskViewModels.AddRange(searchingUsersFromApi.ToList());
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
    }
}
