using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskingoApp.APICall;

namespace TaskingoApp.Model
{
    public class UsersModel : IEnumerable<UserModel>
    {
        private List<UserModel> userModels { get; set; } = new List<UserModel>();

        public async Task GetUsersModelsList()
        {
           var jsonUsers =  await BaseCall.MakeCall("/getUsers",System.Net.Http.HttpMethod.Get, null);
           var users = JsonSerializer.Deserialize<List<UserModel>>(jsonUsers);
           userModels.Clear();
           userModels.AddRange(users);

        }
        public UserModel this[int index]
        {
            get => userModels[index];
        }
        public IEnumerator<UserModel> GetEnumerator() => userModels.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
    }
}
