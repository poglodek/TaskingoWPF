using System;
using System.Threading.Tasks;
using TaskingoApp.Annotations;
using TaskingoApp.Model.User;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;

namespace TaskingoApp.Model.WorkTask
{
    public class WorkTaskModel
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //In queue, In progress, Done, Canceled
        public string Comment { get; set; }
        public string WorkGroup { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime DeadLine { get; set; }
        public UserModel WhoCreated { get; set; }
        public bool IsAssigned { get; set; }

        [CanBeNull]
        public UserModel AssignedUser { get; set; }
        public override string ToString() => $"Id:{Id}, {Title}, {DeadLine}, {WorkGroup}";

        private readonly IWorkTaskServices _workTaskServices = new WorkTaskServices();
        public async Task<WorkTaskModel> GetTaskById()
        {
            var task = await _workTaskServices.GetTaskById(Properties.Settings.Default.TaskId);
            return task;
        }
    }
}
