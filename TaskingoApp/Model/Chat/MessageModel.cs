namespace TaskingoApp.Model.Chat
{
    public class MessageModel
    {
        public string Sender { get; set; }
        public string UserMessage { get; set; }
        public override string ToString()
        {
            return $"{Sender}: {UserMessage}";
        }
    }
}
