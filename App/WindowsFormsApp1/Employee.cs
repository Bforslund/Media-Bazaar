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
        private List<string> allergies;
        private DateTime birthday;
        private bool contract;
        private Department department;
        private DateTime hiredate;
        private string phonenumber;
        private double wage;



        public Employee(int id, string email, string firstname, string lastname, int privilage, string username,
                        string adress, DateTime birthday, bool contract, Department department, DateTime hiredate, string phonenumber, double wage) : base(id, email, firstname, lastname, privilage, username)
        {
            this.Adress = adress;
            this.Birthday = birthday;
            this.Contract = contract;
            this.Department = department;
            this.Hiredate = hiredate;
            this.PhoneNumber = phonenumber;
            this.Wage = wage;
        }

        public string Adress { get => adress; set => adress = value; }
        public List<string> Allergies { get => allergies; set => allergies = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public bool Contract { get => contract; set => contract = value; }
        public Department Department { get => department; set => department = value; }
        public DateTime Hiredate { get => hiredate; set => hiredate = value; }
        public string PhoneNumber { get => phonenumber; set => phonenumber = value; }
        public double Wage { get => wage; set => wage = value; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }

}
