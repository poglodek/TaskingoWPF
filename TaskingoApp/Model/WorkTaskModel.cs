﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Annotations;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.Model
{
    public class WorkTaskModel 
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } //In queue, In progress, Done, Canceled
        public string Comment { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime DeadLine { get; set; }
        public UserModel WhoCreated { get; set; }
        public bool IsAssigned { get; set; }

        [CanBeNull]
        public UserModel AssignedUser { get; set; }
        public override string ToString() => $"Id:{Id}, {Title}, {DeadLine}";
    }
}
