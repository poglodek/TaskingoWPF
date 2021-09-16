using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Role
{
    public class RoleViewModel : ViewModelBase
    {
        private Model.RoleModel RoleModel { get; set; }
        public string RoleName => RoleModel.RoleName;

        public RoleViewModel(Model.RoleModel roleModel)
        {
            RoleModel = roleModel;
        }
    }
}
