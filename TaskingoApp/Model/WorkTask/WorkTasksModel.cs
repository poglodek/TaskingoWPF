using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;

namespace TaskingoApp.Model.WorkTask
{
    public class WorkTasksModel : IEnumerable<WorkTaskModel>
    {
        private List<WorkTaskModel> WorkTasksList { get; set; } = new List<WorkTaskModel>();
        private readonly IWorkTaskServices _workTaskServices = new WorkTaskServices();
        public WorkTaskModel this[int index] => WorkTasksList[index];

        public async Task<List<WorkTaskModel>> GetUsersModelsList()
        {
            WorkTasksList = await _workTaskServices.GetAllTasks();
            return WorkTasksList;

        }

        public IEnumerator<WorkTaskModel> GetEnumerator() => WorkTasksList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
