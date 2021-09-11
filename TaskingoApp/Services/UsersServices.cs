using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using TaskingoApp.APICall;
using TaskingoApp.Builder;
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
                ActualStatus = "Free",
                Address = "Krk, Wawel 15A"
            };
            await Task.Delay(1500);

            return user;
        }

        public async Task<List<UserModel>> GetUsers()
        {
             //TODO BaseCall.MakeCall();
           var jsonUsers =  await BaseCall.MakeCall("User/GetAll",System.Net.Http.HttpMethod.Get, null);
           var userModels = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserModel>>(jsonUsers);
           return userModels;
        }

        public async Task<bool> DeleteUserById(int defaultUserId)
        {
            var result = MessageBox.Show($"Do you wanna delete user with id: {defaultUserId}", "Delete user", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Cancel || result == MessageBoxResult.No) return false;

            //TODO BaseCall.MakeCall();
            // if response is ok 
            await Task.Delay(1500);
            PopupBuilder.Build("User Deleted");
            // else PopupBuilder.Build("You cannot delete this user.");
            return true;
        }

        public async Task<bool> AddNewUser(UserModel userModel)
        {
            if (!CheckUserModel(userModel)) return false;
            //TODO BaseCall.MakeCall();
            // if response is ok 
            await Task.Delay(1500);
            PopupBuilder.Build("User Added");
            // else PopupBuilder.Build("You cannot add this user.");
            return true;
        }

        public async Task EditUser(int defaultUserId, UserModel userModel)
        {
            if (!CheckUserModel(userModel)) return;
            //TODO BaseCall.MakeCall();
            // if response is ok 
            await Task.Delay(1500);
            PopupBuilder.Build("User Edited Successfully");
            // else PopupBuilder.Build("You cannot edit this user.");

        }

        private bool CheckUserModel(UserModel userModel)
        {
            var regex = new Regex(@"[0-9]{9}$");

            if (string.IsNullOrWhiteSpace(userModel.FirstName) || string.IsNullOrWhiteSpace(userModel.LastName)
                                                               || string.IsNullOrWhiteSpace(userModel.Address) ||
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
