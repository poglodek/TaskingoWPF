﻿namespace TaskingoApp.Model
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
    }

}
