using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Services;

namespace TaskingoApp.Model
{
    public class WorkTimesModel :  IEnumerable<WorkTimeModel>
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
