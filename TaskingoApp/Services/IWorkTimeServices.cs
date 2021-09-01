using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public interface IWorkTimeServices
    {
        Task<List<WorkTimeModel>> GetWorkTimeByUserId(int id);
    }
}