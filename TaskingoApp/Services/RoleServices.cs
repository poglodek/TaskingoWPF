using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.APICall;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public class RoleServices : IRoleServices
    {
        public async Task<List<Role>> GetRoles()
        {
            var rolesjson = await BaseCall.MakeCall($"role/GetAll", System.Net.Http.HttpMethod.Get, null);
            var roles = JsonConvert.DeserializeObject<List<Role>>(rolesjson);
            return roles;
        }

        public List<string> GetRolesName()
        {
            var roles = GetRoles().Result;
            var roleNames = new List<string>();
            foreach (var role in roles)
                roleNames.Add(role.RoleName);
            return roleNames;
        }
    }
}
