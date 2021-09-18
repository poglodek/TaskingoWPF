using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Services;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;

namespace TaskingoApp.Model.WorkTask
{
    public class WorkTasksModel : IEnumerable<WorkTaskModel>
    {
        private List<WorkTaskModel> workTasksList { get; set; } = new List<WorkTaskModel>();
        private readonly IWorkTaskServices _workTaskServices = new WorkTaskServices();
        public WorkTaskModel this[int index] => workTasksList[index];

        public async Task<List<WorkTaskModel>> GetUsersModelsList()
        {
            workTasksList = await _workTaskServices.GetAllTasks();
            return workTasksList;

        }

        public IEnumerator<WorkTaskModel> GetEnumerator() => workTasksList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
