using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Services;

namespace TaskingoApp.Model
{
    public class UsersModel : IEnumerable<UserModel>
    {
        private List<UserModel> userModels { get; set; } = new List<UserModel>();
        private readonly IUsersServices _usersServices = new UsersServices();

        public async Task<List<UserModel>> GetUsersModelsList()
        {
            userModels = await _usersServices.GetUsers();
            return userModels;

        }
        public UserModel this[int index] => userModels[index];
        public IEnumerator<UserModel> GetEnumerator() => userModels.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this.GetEnumerator();
    }
}
