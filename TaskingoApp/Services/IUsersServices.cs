using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public interface IUsersServices
    {
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> GetUsers();
        Task<bool> DeleteUserById(int defaultUserId);
        Task<bool> AddNewUser(UserModel userModel);
        Task EditUser(int defaultUserId, UserModel userModel);
    }
}