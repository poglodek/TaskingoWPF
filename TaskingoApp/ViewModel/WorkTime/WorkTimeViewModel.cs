using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Model;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.WorkTime
{
    public class WorkTimeViewModel : ViewModelBase
    {
        private WorkTimeModel WorkTimeModel { get; set; }
        public DateTime WorkTimeStart => WorkTimeModel.WorkTimeStart;
        public int BreakTimeInMinutes => WorkTimeModel.BreakTimeInMinutes;
        public DateTime WorkTimeEnd => WorkTimeModel.WorkTimeEnd;

        public TimeSpan WorkTime => WorkTimeModel.WorkTimeStart - WorkTimeModel.WorkTimeEnd;

        public WorkTimeViewModel()
        {
            
        }

        public WorkTimeViewModel(WorkTimeModel workTimeModel)
        {
            WorkTimeModel = workTimeModel;
        }

        public override string ToString() => $"{WorkTimeStart} | {WorkTimeEnd} \n {WorkTime} | Break Time: {BreakTimeInMinutes} min";
    }
}
