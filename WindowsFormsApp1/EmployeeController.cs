using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class EmployeeController
    {
        private List<Personnel> employees;

        public void saveEmployeeData(int emploeeNo, int department, bool contract, string address, DateTime doB, DateTime hiredate, int phoneNo, double hourlyWage, string allergies_issues, string firstName, string lastName, int privilege, string username, string password, string email, string shiftPreference)
        {
            Employee employeeToAdd = new Employee(emploeeNo, department, contract, address, doB, hiredate, phoneNo, hourlyWage, allergies_issues, firstName, lastName, privilege, username, password, email, shiftPreference);


        }
        public void SetEmployee()
        {
            throw new System.NotImplementedException();
        }

        public double RemoveEmployee()
        {
            throw new System.NotImplementedException();
        }

        public Personnel GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public List<Personnel> GetListOfEmployees()
        {
            throw new System.NotImplementedException();
        }
    }
}
