using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Services;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;

namespace TaskingoApp.Model.WorkTime
{
    public class WorkTimesModel : IEnumerable<WorkTimeModel>
    {
        private List<WorkTimeModel> WorkTimeModel { get; set; } = new List<WorkTimeModel>();
        private IWorkTimeServices workTimeServices = new WorkTimeServices();
        public WorkTimeModel this[int index] => WorkTimeModel[index];



        public IEnumerator<WorkTimeModel> GetEnumerator() => WorkTimeModel.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public async Task GetWorkTime()
        {
            WorkTimeModel = await workTimeServices.GetWorkTimeByUserId(Properties.Settings.Default.UserId);
        }
    }
}
