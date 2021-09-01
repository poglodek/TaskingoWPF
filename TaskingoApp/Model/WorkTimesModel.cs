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
    private List<WorkTimeModel> workTimeModel { get; set; } = new List<WorkTimeModel>();
    public WorkTimeModel this[int index] => workTimeModel[index];



    public IEnumerator<WorkTimeModel> GetEnumerator() => workTimeModel.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
