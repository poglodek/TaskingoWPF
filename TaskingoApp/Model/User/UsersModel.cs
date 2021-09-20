using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Services;
using TaskingoApp.Services.Services;

namespace TaskingoApp.Model.User
{
    public class UsersModel : IEnumerable<UserModel>
    {
        private List<UserModel> UserModels { get; set; } = new List<UserModel>();
        private readonly IUsersServices _usersServices = new UsersServices();

        public async Task<List<UserModel>> GetUsersModelsList()
        {
            UserModels = await _usersServices.GetUsers();
            return UserModels;

        }
        public UserModel this[int index] => UserModels[index];
        public IEnumerator<UserModel> GetEnumerator() => UserModels.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this.GetEnumerator();
    }
}
