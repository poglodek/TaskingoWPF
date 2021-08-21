using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Annotations;

namespace TaskingoApp.Model
{
    public class WorkTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime DeadLine { get; set; }
        public UserModel WhoCreated { get; set; }
        public bool IsAssigned { get; set; }

        [CanBeNull]
        public UserModel AssignedUser { get; set; }
    }
}
