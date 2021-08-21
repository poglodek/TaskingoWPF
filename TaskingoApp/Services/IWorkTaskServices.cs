using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public interface IWorkTaskServices
    {
        Task<List<WorkTaskModel>> GetAllTasks();
    }
}