using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using TaskingoApp.APICall;
using TaskingoApp.Builder;
using TaskingoApp.Model.User;

namespace TaskingoApp.Services.Services
{
    public class UsersServices : IUsersServices
    {
        public async Task<UserModel> GetUserById(int id)
        {
            var jsonUser = await BaseCall.MakeCall($"User/{id}", System.Net.Http.HttpMethod.Get, null);
            var user = JsonConvert.DeserializeObject<UserModel>(jsonUser);
            return user;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            //TODO BaseCall.MakeCall();
            var jsonUsers = await BaseCall.MakeCall("User/GetAll", System.Net.Http.HttpMethod.Get, null);
            var userModels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserModel>>(jsonUsers);
            return userModels;
        }

        public async Task<bool> DeleteUserById(int defaultUserId)
        {
            var result = MessageBox.Show($"Do you wanna delete user with id: {defaultUserId}", "Delete user", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Cancel || result == MessageBoxResult.No) return false;
            await BaseCall.MakeCall($"User/{defaultUserId}", System.Net.Http.HttpMethod.Delete, null);
            PopupBuilder.Build("User Deleted");
            return true;
        }

        public async Task<bool> AddNewUser(UserCreateModel userCreateModel)
        {
            var userModel = MyMapper.iMapper.Map<UserModel>(userCreateModel);
            if (!CheckUserModel(userModel)) return false;
            await BaseCall.MakeCall("User/Register", System.Net.Http.HttpMethod.Post, userCreateModel);
            PopupBuilder.Build("User Added");
            return true;
        }

        public async Task EditUser(int defaultUserId, UserModel userModel)
        {
            if (!CheckUserModel(userModel)) return;
            await BaseCall.MakeCall("User", System.Net.Http.HttpMethod.Patch, userModel);
            PopupBuilder.Build("User Edited Successfully");
        }

        private bool CheckUserModel(UserModel userModel)
        {
            var regex = new Regex(@"[0-9]{9}$");

            if (string.IsNullOrWhiteSpace(userModel.FirstName) || string.IsNullOrWhiteSpace(userModel.LastName)
                                                               || string.IsNullOrWhiteSpace(userModel.Address) ||
                                                               string.IsNullOrWhiteSpace(userModel.Role) ||
                                                               !IsValidEmail(userModel.Email) ||
                                                               !regex.IsMatch(userModel.Phone.ToString()))
            {
                PopupBuilder.Build("The fields are incorrectly completed");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
