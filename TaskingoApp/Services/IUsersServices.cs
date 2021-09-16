using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;
using TaskingoApp.Model.User;

namespace TaskingoApp.Services
{
    public interface IUsersServices
    {
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> GetUsers();
        Task<bool> DeleteUserById(int defaultUserId);
        Task<bool> AddNewUser(UserCreateModel userCreateModel);
        Task EditUser(int defaultUserId, UserModel userModel);
    }
}