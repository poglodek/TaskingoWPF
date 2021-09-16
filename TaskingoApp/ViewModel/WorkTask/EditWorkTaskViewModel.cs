using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Model;
using TaskingoApp.Model.User;
using TaskingoApp.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTask
{
    public class EditWorkTaskViewModel : ViewModelBase
    {
        private WorkTaskModel _workTaskModel;
        private IWorkTaskServices _workTaskServices = new WorkTaskServices();
        private IRoleServices _roleServices = new RoleServices();
        public List<string> RoleNames { get; set; }
        public EditWorkTaskViewModel()
        {
            _workTaskModel = new WorkTaskModel();
            GetTaskFromApi();
        }
        private void GetTaskFromApi()
        {
            Task.Run(() =>
            {
                _workTaskModel = _workTaskModel.GetTaskById().Result;
                RoleNames = _roleServices.GetRolesName();
                OnPropertyChanged(nameof(Id), nameof(Priority), nameof(Title), nameof(Description), nameof(Status), nameof(Comment), nameof(CreatedTime), nameof(DeadLine), nameof(WhoCreated), nameof(IsAssigned), nameof(AssignedUser), nameof(Role), nameof(RoleNames));
            });

        }
        #region Getters

        public int Id => _workTaskModel.Id;

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
            set
            {
                _workTaskModel.WorkGroup = value;
                OnPropertyChanged(nameof(Role));
            }
        }
        public string Comment
        {
            get => _workTaskModel.Comment;
            set => _workTaskModel.Comment = value;
        }
        public DateTime CreatedTime => _workTaskModel.CreatedTime;
        public DateTime DeadLine
        {
            get => _workTaskModel.DeadLine;
            set => _workTaskModel.DeadLine = value;
        }
        public UserModel WhoCreated => _workTaskModel.WhoCreated;
        public bool IsAssigned => _workTaskModel.IsAssigned;
        public UserModel AssignedUser => _workTaskModel.AssignedUser;

        #endregion
        #region Commands
        private ICommand _editTask;

        public ICommand EditTask
        {
            get
            {
                return _editTask ?? (_editTask = new RelayCommand(x =>
                {
                    Task.Run(() =>
                    {
                        _workTaskServices.EditTask(Properties.Settings.Default.TaskId, _workTaskModel).Wait();
                        GetTaskFromApi();
                    });
                }));
            }
        }


        #endregion
    }
}
