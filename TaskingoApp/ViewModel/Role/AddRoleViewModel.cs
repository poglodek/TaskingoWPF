using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Builder;
using TaskingoApp.Commands;
using TaskingoApp.Services;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Role
{
    public class AddRoleViewModel : ViewModelBase
    {
        private readonly IRoleServices _roleServices = new RoleServices();

        public string RoleName { get; set; }

        private ICommand addNewRole;

        public ICommand AddNewRole
        {
            get
            {
                if (addNewRole == null)
                    addNewRole = new RelayCommand(x =>
                    {
                        _roleServices.AddNewRole(RoleName);
                    });
                return addNewRole;
            }
        }
    }
}
