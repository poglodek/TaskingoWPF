using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services.IServices
{
    public interface IRoleServices
    {
        Task<List<RoleModel>> GetRoles();
        public Task<List<string>> GetRolesName();
        public Task AddNewRole(string roleName);
    }
}