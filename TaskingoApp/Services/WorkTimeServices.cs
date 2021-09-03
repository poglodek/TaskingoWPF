using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public class WorkTimeServices : IWorkTimeServices
    {
        public async Task<List<WorkTimeModel>> GetWorkTimeByUserId(int id)
        {
            //TODO API CALL
            //tests
            await Task.Delay(1500);
            var workTask = new List<WorkTimeModel>();
            workTask.Add(new WorkTimeModel
            {
                BreakTimeInMinutes = 30,
                WorkTimeStart = DateTime.Now.AddHours(-8),
                WorkTimeEnd = DateTime.Now
            });
            workTask.Add(new WorkTimeModel
            {
                BreakTimeInMinutes = 29,
                WorkTimeStart = DateTime.Now.AddHours(-12).AddDays(-4),
                WorkTimeEnd = DateTime.Now.AddDays(-4).AddHours(-5).AddMinutes(25)
            });
            return workTask;
        }
    }
}
