using System.Threading.Tasks;
using TaskingoApp.Services;
using TaskingoApp.Services.Services;

namespace TaskingoApp.Model.User
{
    public class UserModel
    {

        private readonly IUsersServices _usersServices = new UsersServices();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsOnline { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }

        public async Task<UserModel> GetUserFromApiById()
        {
            var user = await _usersServices.GetUserById(Properties.Settings.Default.UserId);
            return user;

        }
        public override string ToString()
        {
            return $"ID:{Id}    {FirstName} {LastName}, {Email}, {Role}";
        }


    }

}
