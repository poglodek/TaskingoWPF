using System;
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

        public string WorkTime
        {
            get
            {
                var timeSpan = WorkTimeModel.WorkTimeEnd - WorkTimeModel.WorkTimeStart;
                var minutes = timeSpan.Minutes > 10 ? timeSpan.Minutes.ToString() : "0" + timeSpan.Minutes;
                var seconds = timeSpan.Seconds > 10 ? timeSpan.Seconds.ToString() : "0" + timeSpan.Seconds;
                return $"{timeSpan.Hours}:{minutes}:{seconds}";

            }

        }

        public WorkTimeViewModel()
        {

        }

        public WorkTimeViewModel(WorkTimeModel workTimeModel)
        {
            WorkTimeModel = workTimeModel;
        }

        public override string ToString() => $"Start: {WorkTimeStart} | End: {WorkTimeEnd} \n Working Time: {WorkTime} | Break Time: {BreakTimeInMinutes} min";
    }
}
