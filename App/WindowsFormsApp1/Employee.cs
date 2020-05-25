using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Employee : Personal
    {
        private string adress;
        private string allergies;
        private DateTime birthday;
        private int contract;
        private Department department;
        private DateTime hiredate;
        private string phonenumber;
        private double wage;

        public Employee(string email, string firstname, string lastname, int privilage, string username, string password,
                       string adress, DateTime birthday, string allergies, int contract, Department department, DateTime hiredate, string phonenumber, double wage) : base(email, firstname, lastname, privilage, username, password)
        {
            this.Adress = adress;
            this.Birthday = birthday;
            this.Allergies = allergies;
            this.Contract = contract;
            this.Department = department;
            this.Hiredate = hiredate;
            this.PhoneNumber = phonenumber;
            this.Wage = wage;
        }

        public Employee(int id, string email, string firstname, string lastname, int privilage, string username, string password,
                        string adress, DateTime birthday, string allergies, int contract, Department department, DateTime hiredate, string phonenumber, double wage) : base(id, email, firstname, lastname, privilage, username, password)
        {
            this.Adress = adress;
            this.Birthday = birthday;
            this.Allergies = allergies;
            this.Contract = contract;
            this.Department = department;
            this.Hiredate = hiredate;
            this.PhoneNumber = phonenumber;
            this.Wage = wage;
        }

        public string Adress
        {
            get { return adress; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                adress = value;
            }
        }
        public string Allergies
        {
            get { return allergies; }
            set
            {
               
                allergies = value;
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                birthday = value;
            }
        }
        public int Contract
        {
            get { return contract; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                contract = value;
            }
        }
        public Department Department
        {
            get { return department; }
            set
            {
                
                department = value;
            }
        }
        public DateTime Hiredate
        {
            get { return hiredate; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                hiredate = value;
            }
        }
        public string PhoneNumber
        {
            get { return phonenumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                phonenumber = value;
            }
        }
        public double Wage
        {
            get { return wage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                wage = value;
            }
        }

        //public override string ToString()
        //{
        //    return this.FirstName + " " + this.LastName;
        //}
    }

}
