using System.Collections.Generic;
using System.Threading.Tasks;
using TaskingoApp.Model;

namespace TaskingoApp.Services
{
    public class UsersServices : IUsersServices
    {
        public async Task<UserModel> GetUserById(int id)
        {
            //TODO BaseCall.MakeCall();
            //set Properties from api response 
            //Properties.Settings.Default.UserId;

            //TEST
            var user = new UserModel
            {
                Id = Properties.Settings.Default.UserId,
                FirstName = "Adam",
                LastName = "SZybki",
                Email = "Email@admin.com",
                Phone = 123321123,
                Address = "Krk, Wawel 15A"
            };
            await Task.Delay(1500);

            return user;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            /*
           var jsonUsers =  await BaseCall.MakeCall("/getUsers",System.Net.Http.HttpMethod.Get, null);
           var users = JsonSerializer.Deserialize<List<UserModel>>(jsonUsers);
           userModels.Clear();
           userModels.AddRange(users);
            */
            var userModels = new List<UserModel>();
            userModels.Clear();
            await Task.Delay(3500);
            userModels.Add(new UserModel
            {
                Address = "Test road 15C, Krk",
                Email = "mail@test.com",
                FirstName = "Pablos",
                LastName = "Cucumber",
                Phone = 321321123,
                Id = 1
            });
            userModels.Add(new UserModel
            {
                Address = "Curie 18, WWa",
                Email = "adam@admin.com",
                FirstName = "Adam",
                LastName = "Majster",
                Phone = 123123123,
                Id = 2
            });
            return userModels;
        }
    }
}
