using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public List<string> GetRolesName(List<Role> roles)
        {
            var roleNames = new List<string>();
            foreach (var role in roles)
                roleNames.Add(role.RoleName);
            return roleNames;
        }
    }
}
