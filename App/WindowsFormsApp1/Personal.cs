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
        private string firstname;
        private string lastname;
        private int privilage;
        private string username;

        public Personal(int id, string email, string firstname, string lastname, int privilage, string username)
        {
            this.Id = id;
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.privilage = privilage;
            this.username = username;
        }

        public override string ToString()
        {
            return $"{firstname} {lastname}";
        }
    }
}
