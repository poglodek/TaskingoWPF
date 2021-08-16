using System.Threading.Tasks;

namespace TaskingoApp.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"ID:{Id}    {FirstName} {LastName}";
        }

        public async Task GetFromApi()
        {
            //TODO BaseCall.MakeCall();
            //set Properties from api response 
            //Properties.Settings.Default.UserId;

            //TEST

            await Task.Delay(1500);
            Id = Properties.Settings.Default.UserId;
            FirstName = "Adam";
            LastName = "SZybki";
            Email = "Email@admin.com";
            Phone = 123321123;
            Address = "Krk, Wawel 15A";



        }
    }

}
