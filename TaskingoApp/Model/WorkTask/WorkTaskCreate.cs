﻿using System;

namespace TaskingoApp.Model.WorkTask
{
    public class WorkTaskCreate
    {
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //In queue, In progress, Done, Canceled
        public string Comment { get; set; }
        public string WorkGroup { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
