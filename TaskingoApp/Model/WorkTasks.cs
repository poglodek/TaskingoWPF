using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Services;

namespace TaskingoApp.Model
{
    public class WorkTasks : IEnumerable<WorkTask>
    {
        private List<WorkTask> workTasksList { get; set; } = new List<WorkTask>();
        private readonly IWorkTaskServices _workTaskServices = new WorkTaskServices();
        public WorkTask this[int index] => workTasksList[index];

        public async Task<List<WorkTask>> GetUsersModelsList()
        {
           // workTasksList = await _workTaskServices.GetUsers();
            return workTasksList;

        }

        public IEnumerator<WorkTask> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
