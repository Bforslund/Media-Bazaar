using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Personal
    {
        private string email;
        private string firstname;
        private string lastname;
        private int privilage;
        private string username;

        public Personal(string email, string firstname, string lastname, int privilage, string username)
        {
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
