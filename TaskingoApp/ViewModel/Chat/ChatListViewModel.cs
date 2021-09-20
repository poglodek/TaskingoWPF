using System.Threading.Tasks;
using TaskingoApp.Components;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;
using TaskingoApp.ViewModel.Base;
using TaskingoApp.ViewModel.Users;

namespace TaskingoApp.ViewModel.Chat
{
    public class ChatListViewModel : ViewModelBase
    {
        public AsyncObservableCollection<UserViewModel> MessageModels { get; set; } = new AsyncObservableCollection<UserViewModel>();
        private readonly IChatServices _chatServices = new ChatServices();
        public ChatListViewModel()
        {
            DownloadLastUserChatting();
        }

        private void DownloadLastUserChatting()
        {
            Task.Run(() =>
            {
                var users = _chatServices.GetLastUsers().Result;
                MessageModels.Clear();
                foreach (var user in users)
                    MessageModels.Add(new UserViewModel(user));
            });
        }
        private UserViewModel _selectedUser;

        public UserViewModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                if (_selectedUser != null)
                {
                    Properties.Settings.Default.UserId = _selectedUser.Id;
                    Properties.Settings.Default.TaskUserMail = _selectedUser.Email;
                }



            }
        }
    }
}
