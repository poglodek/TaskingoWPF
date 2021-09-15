using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public interface IRoleServices
    {
        Task<List<Role>> GetRoles();
        public List<string> GetRolesName(List<Role> roles);
    }
}