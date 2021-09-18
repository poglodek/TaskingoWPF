using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskingoApp.APICall;
using TaskingoApp.Builder;
using TaskingoApp.Model;
using TaskingoApp.Services.IServices;

namespace TaskingoApp.Services.Services
{
    public class RoleServices : IRoleServices
    {
        public async Task<List<RoleModel>> GetRoles()
        {
            var rolesjson = await BaseCall.MakeCall($"role/GetAll", System.Net.Http.HttpMethod.Get, null);
            var roles = JsonConvert.DeserializeObject<List<RoleModel>>(rolesjson);
            return roles;
        }

        public async Task<List<string>> GetRolesName()
        {
            var roles = await GetRoles();
            var roleNames = new List<string>();
            foreach (var role in roles)
                roleNames.Add(role.RoleName);
            return roleNames;
        }

        public async Task AddNewRole(string roleName)
        {
            await BaseCall.MakeCall($"Role?roleName={roleName}", System.Net.Http.HttpMethod.Post, null);
            PopupBuilder.Build("Role Created.");
        }
    }
}
