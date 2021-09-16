using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Model.WorkTask;
using TaskingoApp.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTask
{
    public class AddWorkTaskViewModel : ViewModelBase
    {
        private WorkTaskCreate _workTaskModel;
        private IWorkTaskServices _workTaskServices = new WorkTaskServices();
        private IRoleServices _roleServices = new RoleServices();
        public List<string> RoleNames { get; set; }


        public AddWorkTaskViewModel()
        {
            _workTaskModel = new WorkTaskCreate();
            DeadLine = DateTime.Now.AddHours(1);
            OnPropertyChanged(nameof(DeadLine));
            GetRoleByApi();
        }

        private void GetRoleByApi()
        {
            Task.Run(() =>
            {
                RoleNames = _roleServices.GetRolesName().Result;
                OnPropertyChanged(nameof(RoleNames));
            });

        }
        #region getters
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
        public string Role
        {
            get => _workTaskModel.WorkGroup;
            set => _workTaskModel.WorkGroup = value;
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
