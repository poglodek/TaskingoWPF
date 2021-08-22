using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTask
{
    public class EditWorkTask : ViewModelBase
    {
        private WorkTaskModel _workTaskModel;

        public EditWorkTask()
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
        #region Getters

        public int Id  => _workTaskModel.Id;

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
            set =>  _workTaskModel.Status = value;
           
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
        public UserModel AssignedUser
        {
            get => _workTaskModel.AssignedUser;
            set => _workTaskModel.AssignedUser = value;
        }
        #endregion
    }
}
