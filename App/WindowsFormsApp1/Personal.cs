using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Personal
    {
        public int Id { get; set; }
        private string email;
        private string firstName;
        private string lastName;
        private int privilage;
        private string username;

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Privilage { get; set; }
        public string Username { get; set; }

        public Personal(int id, string email, string firstname, string lastname, int privilage, string username)
        {
            this.Id = id;
            this.Email = email;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Privilage = privilage;
            this.Username = username;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
