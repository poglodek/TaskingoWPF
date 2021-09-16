using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model.WorkTask;

namespace TaskingoApp.Services
{
    public interface IWorkTaskServices
    {
        Task<List<WorkTaskModel>> GetAllTasks();
        Task<WorkTaskModel> GetTaskById(int Id);
        Task EditTask(int Id, WorkTaskModel workTaskModel);
        Task<bool> DeleteTaskById(int Id);
        Task AddTask(WorkTaskCreate workTaskModel);
    }
}