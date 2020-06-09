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
        private string password;

        public string Email {
            get { return email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                email = value;
            }
        }
        public string FirstName {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                firstName = value;
            }
        }
        public string LastName {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                lastName = value;
            }
        }
        public int Privilage { get; set; }
        public string Username {
            get { return username; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                username = value;
            }
        }
        public string Password {
            get { return password; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                password = value;
            }
        }

        public Personal(string firstname, string lastname)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
        }

        public Personal(string email, string firstname, string lastname, int privilage, string username, string password)
        {
           
            this.Email = email;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Privilage = privilage;
            this.Username = username;
            this.Password = password;
        }
        public Personal(int id, string email, string firstname, string lastname, int privilage, string username, string password)
        {
            this.Id = id;
            this.Email = email;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Privilage = privilage;
            this.Username = username;
            this.Password = password;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
