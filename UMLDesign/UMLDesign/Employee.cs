using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMLDesign
{
    public class Personal
    {
        private string firstname;
        private string lastname;
        private int privilage;
        private int username;
        private int email;

        public override string ToString()
        {
            return base.ToString();//firstname lastname
        }

        public int GetPrivilage()
        {
            throw new System.NotImplementedException();
        }

        public string GetUsername()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Employee : Personal
    {
        private int department;
        private bool contract;
        private string adress;
        private date birthday;
        private date hiredate;
        private int phone;
        private double wage;
        private List<string> allergies;

        public int GetNumber()
        {
            throw new System.NotImplementedException();
        }

        public int GetAge()
        {
            throw new System.NotImplementedException();
        }

        public string GetAdress()
        {
            throw new System.NotImplementedException();
        }

        public void GetAllergies()
        {
            throw new System.NotImplementedException();
        }

        public strign GetEmployedTime()
        {
            throw new System.NotImplementedException();
        }
    }
}