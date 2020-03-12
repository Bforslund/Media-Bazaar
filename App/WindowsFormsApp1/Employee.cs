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
        private int department;
        private DateTime hiredate;
        private string phonenumber;
        private double wage;

        public Employee(string email, string firstname, string lastname, int privilage, string username,
                        string adress, DateTime birthday, bool contract, int department, DateTime hiredate, string phonenumber, double wage) : base(email, firstname, lastname, privilage, username)
        {
            this.adress = adress;
            this.birthday = birthday;
            this.contract = contract;
            this.department = department;
            this.hiredate = hiredate;
            this.phonenumber = phonenumber;
            this.wage = wage;
        }
    }
}
