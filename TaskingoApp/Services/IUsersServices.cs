using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public interface IUsersServices
    {
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> GetUsers();
        bool DeleteUserById(int defaultUserId);
        bool AddNewUser(UserModel userModel);
    }
}