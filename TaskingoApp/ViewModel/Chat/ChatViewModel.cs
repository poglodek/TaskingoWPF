using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.Components;
using TaskingoApp.Model.Chat;
using TaskingoApp.Services;
using TaskingoApp.Services.IServices;
using TaskingoApp.Services.Services;
using TaskingoApp.ViewModel.Base;

namespace TaskingoApp.ViewModel.Chat
{
    public class ChatViewModel : ViewModelBase
    {
        private readonly IChatServices _chatServices = new ChatServices();
        private readonly IUsersServices _usersServices = new UsersServices();

        public AsyncObservableCollection<MessageModel> MessagesList { get; set; } = new AsyncObservableCollection<MessageModel>();

        public ChatViewModel()
        {
            DownloadMessages();
            _chatServices.ReceiveMessage += _chatServices_ReceiveMessage;
        }
        private void DownloadMessages()
        {
            Task.Run(() =>
            {
                var user = _usersServices.GetUserById(Properties.Settings.Default.UserId).Result;
                UserName = $"{user.FirstName} {user.LastName}";
                var newMessages = _chatServices.GetMessages(MessagesList.Count).Result;
                AddMessages(newMessages);
            });
        }
        private void _chatServices_ReceiveMessage(MessageModel obj)
        {
            MessagesList.Add(obj);
            OnPropertyChanged(nameof(Messages));
        }


        public string Messages
        {
            get
            {
                var messages = "";
                foreach (var message in MessagesList)
                    messages += $"\n{message}";
                return messages;
            }
        }

        private string message;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private string userName;

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(userName));
            }
        }
        private ICommand sendMessage;

        public ICommand SendMessage
        {
            get
            {
                if (sendMessage == null)
                    sendMessage = new RelayCommand(x =>
                    {
                        _chatServices.SendMessage(Message, Properties.Settings.Default.UserId);
                        MessagesList.Add(new MessageModel
                        {
                            Sender = Properties.Settings.Default.MyName,
                            UserMessage = Message
                        });
                        Message = "";
                        OnPropertyChanged(nameof(Messages));
                    });
                return sendMessage;
            }
        }

        private ICommand downloadMessage;

        public ICommand DownloadMessage
        {
            get
            {
                if (downloadMessage == null)
                    downloadMessage = new RelayCommand(x =>
                    {
                        Task.Run(() =>
                        {
                            var newMessages = _chatServices.GetMessages(MessagesList.Count).Result;
                            ApendMessages(newMessages);
                        });
                    });
                return downloadMessage;
            }
        }

        private void AddMessages(List<MessageModel> messages)
        {
            MessagesList.AddRange(messages);
            OnPropertyChanged(nameof(Messages));
        }
        private void ApendMessages(List<MessageModel> messages)
        {
            var oldMessage = MessagesList.ToList();
            MessagesList.Clear();
            AddMessages(messages);
            AddMessages(oldMessage);
            OnPropertyChanged(nameof(Messages));
        }

    }
}
