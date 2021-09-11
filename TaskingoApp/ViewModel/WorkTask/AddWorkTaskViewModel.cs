﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Model;
using TaskingoApp.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTask
{
    public class AddWorkTaskViewModel : ViewModelBase
    {
        private WorkTaskModel _workTaskModel;
        private IWorkTaskServices _workTaskServices = new WorkTaskServices();


        public AddWorkTaskViewModel()
        {
            _workTaskModel = new WorkTaskModel();
            DeadLine = DateTime.Now.AddHours(1);
            OnPropertyChanged(nameof(DeadLine));
        }
        #region Getters


        public int Priority
        {
            get => _workTaskModel.Priority;
            set => _workTaskModel.Priority = value;
        }
        public string Title
        {
            get => _workTaskModel.Title;
            set => _workTaskModel.Title = value;
        }
        public string Description
        {
            get => _workTaskModel.Description;
            set => _workTaskModel.Description = value;
        }
        public string Status
        {
            get => _workTaskModel.Status;
            set => _workTaskModel.Status = value;

        }
        public string Comment
        {
            get => _workTaskModel.Comment;
            set => _workTaskModel.Comment = value;
        }
        public DateTime DeadLine
        {
            get => _workTaskModel.DeadLine;
            set => _workTaskModel.DeadLine = value;
        }

        #endregion
        #region Commands
        private ICommand _addTask;

        public ICommand AddTask
        {
            get
            {
                return _addTask ?? (_addTask = new RelayCommand(x =>
                {
                    Task.Run(() =>
                    {
                        _workTaskServices.AddTask(_workTaskModel).Wait();
                    });
                }));
            }
        }


        #endregion
    }
}