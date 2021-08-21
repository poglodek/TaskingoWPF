﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTask
{
    public class WorkTaskViewModel : ViewModelBase
    {
        private WorkTaskModel _workTaskModel;

        public WorkTaskViewModel()
        {
            _workTaskModel = new WorkTaskModel();
            if (Properties.Settings.Default.ActualView == "Task")
                GetTaskFromApi();
        }
        private void GetTaskFromApi()
        {
            Task.Run(() =>
            {
                _workTaskModel = _workTaskModel.GetTaskById().Result;
                OnPropertyChanged(nameof(Id), nameof(Priority), nameof(Title), nameof(Description), nameof(Status), nameof(Comment), nameof(CreatedTime), nameof(DeadLine), nameof(WhoCreated), nameof(IsAssigned), nameof(AssignedUser));
            });

        }

        public WorkTaskViewModel(WorkTaskModel workTaskModel)
        {
            _workTaskModel = workTaskModel;
        }
        #region Getters

        public int Id => _workTaskModel.Id;
        public int Priority => _workTaskModel.Priority;
        public string Title => _workTaskModel.Title;
        public string Description => _workTaskModel.Description;
        public string Status => _workTaskModel.Status;
        public string Comment => _workTaskModel.Comment;
        public DateTime CreatedTime => _workTaskModel.CreatedTime;
        public DateTime DeadLine => _workTaskModel.DeadLine;
        public UserModel WhoCreated => _workTaskModel.WhoCreated;
        public bool IsAssigned => _workTaskModel.IsAssigned;
        public UserModel AssignedUser => _workTaskModel.AssignedUser;

        public override string ToString() => $"Id:{Id}, {Title}, {DeadLine}";
        #endregion
    }
}
