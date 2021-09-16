using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.APICall;
using TaskingoApp.Builder;
using TaskingoApp.Model.WorkTask;

namespace TaskingoApp.Services
{
    public class WorkTaskServices : IWorkTaskServices
    {
        public async Task<List<WorkTaskModel>> GetAllTasks()
        {
            var json = await BaseCall.MakeCall($"WorkTask/{Properties.Settings.Default.MonthOfTasks}", System.Net.Http.HttpMethod.Get, null);
            var tasks = JsonConvert.DeserializeObject<List<WorkTaskModel>>(json);
            return tasks;

        }

        public async Task<WorkTaskModel> GetTaskById(int id)
        {
            var json = await BaseCall.MakeCall($"WorkTask/{id}", System.Net.Http.HttpMethod.Get, null);
            var task = JsonConvert.DeserializeObject<WorkTaskModel>(json);
            return task;
        }

        public async Task EditTask(int Id, WorkTaskModel workTaskModel)
        {
            if (!CheckTaskModel(workTaskModel)) return;
            workTaskModel.Status = workTaskModel.Status.Substring(38);
            await BaseCall.MakeCall($"WorkTask", System.Net.Http.HttpMethod.Patch, workTaskModel);
            PopupBuilder.Build("Task Edited Successfully");
        }

        public async Task<bool> DeleteTaskById(int id)
        {
            var result = MessageBox.Show($"Do you wanna delete task with id: {id}", "Delete Task", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Cancel || result == MessageBoxResult.No) return false;
            await BaseCall.MakeCall($"WorkTask/{id}", System.Net.Http.HttpMethod.Delete, null);
            PopupBuilder.Build("Task Deleted");
            return true;
        }

        public async Task AddTask(WorkTaskCreate workTaskCreate)
        {
            var workTaskModel = MyMapper.iMapper.Map<WorkTaskModel>(workTaskCreate);
            if (!CheckTaskModel(workTaskModel)) return;
            workTaskCreate.Status = workTaskCreate.Status.Substring(38);
            await BaseCall.MakeCall($"WorkTask", System.Net.Http.HttpMethod.Post, workTaskCreate);
            PopupBuilder.Build("Task Added Successfully");
        }

        private bool CheckTaskModel(WorkTaskModel workTaskModel)
        {
            if (string.IsNullOrWhiteSpace(workTaskModel.Title) ||
                string.IsNullOrWhiteSpace(workTaskModel.Status) ||
                string.IsNullOrWhiteSpace(workTaskModel.WorkGroup) ||
                workTaskModel.Status.Length < 38 ||
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
