using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskingoApp.Components;
using TaskingoApp.Services;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;
using TaskingoApp.ViewModel.Base;
using TaskingoApp.ViewModel.WorkTime;

namespace TaskingoApp.ViewModel.Role
{
    public class RolesViewModel : ViewModelBase
    {
        private IRoleServices _roleServices = new RoleServices();
        public AsyncObservableCollection<string> RoleViewModels { get; set; } = new AsyncObservableCollection<string>();

        public RolesViewModel()
        {
            DownloadRolesFromApi();
        }

        private void DownloadRolesFromApi()
        {
            Task.Run(() =>
            {
                var roles = _roleServices.GetRolesName().Result;
                foreach (var role in roles)
                    RoleViewModels.Add(role);
            });
        }
    }
    
}
