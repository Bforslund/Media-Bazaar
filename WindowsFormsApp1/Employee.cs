using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Employee
    {
        private int employeeNo;
        private int department; //TODO maybe to change to an enumerator
        private bool contract; // if regular employee or pool of temp workers
        private string address;
        private DateTime birthday;
        private DateTime hiredate;
        private int phoneNo; // TODO string
        private double hourlyWage;
        private string allergies_issues;
        private string shiftPreference;

        
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

        public string GetEmployedTime()
        {
            throw new System.NotImplementedException();
        }
    }
}
