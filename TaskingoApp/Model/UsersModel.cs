using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskingoApp.Model
{
    public class UsersModel : IEnumerable<UserModel>
    {
        private List<UserModel> userModels { get; set; } = new List<UserModel>();

        public async Task GetUsersModelsList()
       // public async Task<List<UserModel>> GetUsersModelsList()
        {

            /*
           var jsonUsers =  await BaseCall.MakeCall("/getUsers",System.Net.Http.HttpMethod.Get, null);
           var users = JsonSerializer.Deserialize<List<UserModel>>(jsonUsers);
           userModels.Clear();
           userModels.AddRange(users);
            */
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
        }
        public UserModel this[int index]
        {
            get => userModels[index];
        }
        public IEnumerator<UserModel> GetEnumerator() => userModels.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)this.GetEnumerator();

        public static implicit operator UsersModel(UserModel v)
        {
            throw new NotImplementedException();
        }
    }
}
