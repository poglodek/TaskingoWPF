using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskingoApp.Model
{
    public class WorkTimeModel
    {
        public DateTime WorkTimeStart { get; set; }
        public DateTime WorkTimeEnd { get; set; }
        public int BreakTimeInMinutes { get; set; }
    }
}
