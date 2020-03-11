using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Personnel
    {
        private string firstName;
        private string lastName;
        private int privilege;
        private string username;
        private string email;

        public Personnel(string firstName, string lastName, int privilege, string username, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.privilege = privilege;
            this.username = username;
            this.email = email;
        }
        public override string ToString()
        {
            return firstName + " "+ lastName;//firstname lastname

        }

        public int GetPrivilege()
        {
            return this.privilege;

            throw new System.NotImplementedException();
        }

        public string GetUsername()
        {
            return this.username;
            throw new System.NotImplementedException();
        }
    }
}
