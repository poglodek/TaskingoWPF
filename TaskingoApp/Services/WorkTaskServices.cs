using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.Builder;
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

        public async Task<WorkTaskModel> GetTaskById(int Id)
        {
            await Task.Delay(1500);
            var task = new WorkTaskModel
            {
                Id = Id,
                Priority = 5,
                Title = "First Task",
                Description = "This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)",
                Status = "In Progress",
                Comment = "FiThis is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this app. :)This is First Task in this apprst comm",
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
            };
            return task;
        }

        public async Task EditTask(int Id, WorkTaskModel workTaskModel)
        {
            if (!CheckTaskModel(workTaskModel)) return;
            //TODO BaseCall.MakeCall();
            // if response is ok 
            await Task.Delay(1500);
            var a = workTaskModel.Status.Substring(38);
            PopupBuilder.Build("Task Edited Successfully");
            // else PopupBuilder.Build("You cannot edit this user.");
        }

        public async Task<bool> DeleteTaskById(int Id)
        {
            var result = MessageBox.Show($"Do you wanna delete task with id: {Id}", "Delete Task", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Cancel || result == MessageBoxResult.No) return false;

            //TODO BaseCall.MakeCall();
            // if response is ok 
            await Task.Delay(1500);
            PopupBuilder.Build("Task Deleted");
            // else PopupBuilder.Build("You cannot delete this user.");
            return true;
        }

        public async Task AddTask(WorkTaskModel workTaskModel)
        {
            if (!CheckTaskModel(workTaskModel)) return;
            //TODO BaseCall.MakeCall();
            // if response is ok 
            await Task.Delay(1500);
            PopupBuilder.Build("Task Added Successfully");
            // else PopupBuilder.Build("You cannot edit this user.");
        }

        private bool CheckTaskModel(WorkTaskModel workTaskModel)
        {
            if (string.IsNullOrWhiteSpace(workTaskModel.Title) ||
                string.IsNullOrWhiteSpace(workTaskModel.Status) ||
                workTaskModel.Status.Length < 38 ||
                workTaskModel.DeadLine < DateTime.Now.AddMinutes(-5) ||
                workTaskModel.Priority < 1 || 
                workTaskModel.Priority > 11)
            {
                PopupBuilder.Build("The fields are incorrectly completed");
                return false;
            }

            return true;
        }
    }
        
    
}
