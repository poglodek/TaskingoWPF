using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Services;

namespace TaskingoApp.Model
{
    public class WorkTasksModel : IEnumerable<WorkTaskModel>
    {
        private List<WorkTaskModel> workTasksList { get; set; } = new List<WorkTaskModel>();
        private readonly IWorkTaskServices _workTaskServices = new WorkTaskServices();
        public WorkTaskModel this[int index] => workTasksList[index];

        public async Task<List<WorkTaskModel>> GetUsersModelsList()
        {
           // workTasksList = await _workTaskServices.GetUsers();
            return workTasksList;

        }

        public IEnumerator<WorkTaskModel> GetEnumerator() => workTasksList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
