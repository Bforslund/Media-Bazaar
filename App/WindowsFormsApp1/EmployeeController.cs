using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class EmployeeController
    {
        private List<Personal> personals = new List<Personal>();

        private MySqlConnection databaseConnection = DatabaseInfo.sqlConnection;

        /// <summary>
        /// gets all the employees from the database and puts the in a private variable and returns them
        /// </summary>
        /// <returns></returns>
        public List<Personal> GetEmployees()
        {
            string query = "SELECT * FROM `users` WHERE privilage = 0";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    while (reader.Read()) //read each individual row
                    {
                        string username = reader["username"].ToString();
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int privilage = Convert.ToInt32(reader["privilage"]);
                        double wage = Convert.ToDouble(reader["wage"]);
                        DateTime hiredate = Convert.ToDateTime(reader["hiredate"]);
                        DateTime birthday = Convert.ToDateTime(reader["birthday"]);
                        string adress = reader["adress"].ToString();
                        string email = reader["email"].ToString();
                        string phone = reader["phone"].ToString();
                        bool contract = Convert.ToBoolean(reader["contract"]);
                        //int department = Convert.ToInt32(reader["department_id"]);
                        int department = 0;

                        personals.Add(new Employee(email, firstname, lastname, privilage, username, adress, birthday, contract, department, hiredate, phone, wage));
                    }

                    databaseConnection.Close();
                    return personals;
                }
                else
                {
                    databaseConnection.Close();
                }
                databaseConnection.Close();
                return null;
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
                return null;
            }
        }

        /// <summary>
        /// gets a filter list of employees using the paramater given
        /// </summary>
        /// <param name="filterTerm"></param>
        /// <returns></returns>
        public List<Personal> FilterEmployees(string filterTerm)
        {
            filterTerm = filterTerm.ToLower(); //makes everything lower case, makes it easier to compare

            if (string.IsNullOrEmpty(filterTerm)) // if no filter term given return all employees
            {
                return personals;
            }

            List<Personal> filterPersonals = new List<Personal>(); 

            foreach (Personal person in personals)
            {
                if (person.ToString().ToLower().IndexOf(filterTerm) >= 0) // check if the person contains a part of the filter term
                {
                    filterPersonals.Add(person);
                }
            }

            return filterPersonals;
        }
    }
}
