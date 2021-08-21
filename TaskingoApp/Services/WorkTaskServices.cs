using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public class WorkTaskServices : IWorkTaskServices
    {
        public async Task<List<WorkTaskModel>> GetAllTasks()
        {
            await Task.Delay(1500);
            //TODO api call -> all tasks
            //TEST
            //From properties take month to call
            var tasks = new List<WorkTaskModel>();
            tasks.Add(new WorkTaskModel
                {
                    Id = 3,
                    Priority = 5,
                    Title = "First Task",
                    Description = "This is First Task",
                    Status = "In Progress",
                    Comment = "",
                    CreatedTime = DateTime.Now.AddDays(-2),
                    DeadLine = DateTime.Now.AddHours(5),
                    WhoCreated = new UserModel
                    {
                        Id = 2,
                        FirstName = "Adam",
                        LastName = "SZybki",
                        Email = "Email@admin.com",
                        Phone = 123321123,
                        Address = "Krk, Wawel 15A"
                    },
                    IsAssigned = true,
                    AssignedUser = new UserModel
                    {
                        Address = "Test road 15C, Krk",
                        Email = "mail@test.com",
                        FirstName = "Pablos",
                        LastName = "Cucumber",
                        Phone = 321321123,
                        Id = 15
                    }

                });
                tasks.Add(new WorkTaskModel
                {
                    Id = 10,
                    Priority = 5,
                    Title = "wash a cup",
                    Description = "Go to kitchen and put into dishwasher a cup",
                    Status = "Done",
                    Comment = "Done.",
                    CreatedTime = DateTime.Now.AddMinutes(-5),
                    DeadLine = DateTime.Now.AddMinutes(15),
                    WhoCreated = new UserModel
                    {
                        Address = "Curie 18, WWa",
                        Email = "adam@admin.com",
                        FirstName = "Adam",
                        LastName = "Majster",
                        Phone = 123123123,
                        Id = 22
                    },
                    IsAssigned = false,
                    AssignedUser = null

                });
            
            
            return tasks;

        }
    }
}
