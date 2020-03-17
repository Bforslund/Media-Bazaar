using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Personal
    {
        private int id;
        private string email;
        private string firstname;
        private string lastname;
        private int privilage;
        private string username;

        public Personal(int id, string email, string firstname, string lastname, int privilage, string username)
        {
            this.id = id;
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.privilage = privilage;
            this.username = username;
        }

        public int Id()
        {
            return id;
        }

        public override string ToString()
        {
            return $"{firstname} {lastname}";
        }
    }
}
