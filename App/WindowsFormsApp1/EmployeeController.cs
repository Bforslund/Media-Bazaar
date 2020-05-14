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
        private List<Personal> AllEmployees = new List<Personal>();

        /// <summary>
        /// gets all the employees from the database and puts the in a private variable and returns them
        /// </summary>
        /// <returns></returns>
        public List<Personal> GetEmployees()
        {
            personals.Clear();
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            string query = "SELECT * FROM `users` WHERE privilage = 1";

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
                        int id = Convert.ToInt32(reader["id"]);
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
                        Department department = new DepartmentController().GetDepartment(Convert.ToInt32(reader["department_id"]));

                        personals.Add(new Employee(id, email, firstname, lastname, privilage, username, adress, birthday, contract, department, hiredate, phone, wage));
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
            catch (Exception)
            {
                databaseConnection.Close();
                return null;
            }
        }

        public List<Personal> GetAllEmployees() // I need all employees from the database so i can choose one to make
        { // a manager, however I did not want to change the list above (its the same one basically) in case Ryan uses it for his schedule
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            string query = "SELECT * FROM `users`";

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
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
                        Department department = new DepartmentController().GetDepartment(Convert.ToInt32(reader["id"]));

                        AllEmployees.Add(new Employee(id, email, firstname, lastname, privilage, username, adress, birthday, contract, department, hiredate, phone, wage));
                    }
                }
                return AllEmployees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
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

        public void RemoveEmployee(Personal employeeToRemove)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);

            try
            {

                string Queryable = "DELETE FROM users WHERE id = @id";

                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(Queryable, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@id", employeeToRemove.Id);
                //MySqlDataReader reader = commandDatabase.ExecuteReader();
                commandDatabase.ExecuteNonQuery();


            }
            catch (Exception)
            {

            }


            finally
            {
                databaseConnection.Close();
            }


        }


        public void saveEmployeeData(string email, string firstname, string lastname, int privilage, string username, string password, string adress, DateTime birthday, bool contract, Department department, DateTime hiredate, string phone, double wage, bool isSelected)
        {

            if (isSelected == true) // if there is already such an employee, update
            {
                MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
                //insert new day and shifts
                string insertQuery = $"INSERT INTO users(username, password, firstname, lastname, privilage, wage, hiredate, birthday, adress, email, phone, contract) VALUES(@username, @password, @firstname, @lastname, @privilage, @wage, " +
                    $"@hiredate, @birthday, @adress, @email, @phone,@contract)";
                databaseConnection.Open();

                MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@username", username);
                commandDatabase.Parameters.AddWithValue("@password", password);
                commandDatabase.Parameters.AddWithValue("@firstname", firstname);
                commandDatabase.Parameters.AddWithValue("@lastname", lastname);
                commandDatabase.Parameters.AddWithValue("@privilage", privilage);
                commandDatabase.Parameters.AddWithValue("@wage", wage);
                commandDatabase.Parameters.AddWithValue("@hiredate", hiredate);
                commandDatabase.Parameters.AddWithValue("@birthday", birthday);
                commandDatabase.Parameters.AddWithValue("@adress", adress);
                commandDatabase.Parameters.AddWithValue("@email", email);
                commandDatabase.Parameters.AddWithValue("@phone", phone);
                commandDatabase.Parameters.AddWithValue("@contract", contract);
                commandDatabase.ExecuteNonQuery();
                long employeeId = commandDatabase.LastInsertedId;

                databaseConnection.Close();

            }
            else //else create new record
            {
                MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
                //insert new day and shifts
                string insertQuery = $"UPDATE users SET password = @password, firstname = @firstname, lastname = @lastname, privilage = @privilage, wage = @wage, " +
                    $"hiredate = @hiredate, birthday = @birthday, adress = @adress, email = @email, phone = @phone, contract = @contract WHERE username = @username) )";

                databaseConnection.Open();

                MySqlCommand commandDatabase = new MySqlCommand(insertQuery, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@username", username);
                commandDatabase.Parameters.AddWithValue("@password", password);
                commandDatabase.Parameters.AddWithValue("@firstname", firstname);
                commandDatabase.Parameters.AddWithValue("@lastname", lastname);
                commandDatabase.Parameters.AddWithValue("@privilage", privilage);
                commandDatabase.Parameters.AddWithValue("@wage", wage);
                commandDatabase.Parameters.AddWithValue("@hiredate", hiredate);
                commandDatabase.Parameters.AddWithValue("@birthday", birthday);
                commandDatabase.Parameters.AddWithValue("@adress", adress);
                commandDatabase.Parameters.AddWithValue("@email", email);
                commandDatabase.Parameters.AddWithValue("@phone", phone);
                commandDatabase.Parameters.AddWithValue("@contract", contract);


                commandDatabase.ExecuteNonQuery();
                long employeeId = commandDatabase.LastInsertedId;

                databaseConnection.Close();

            }


            //personals.Add(new Employee(Convert.ToInt32(employeeId), email, firstname, lastname, privilage, username, adress, birthday, contract, department, hiredate, phonenumber, wage));
        }
        public Personal GetEmployee(int id) // get an employee by ID
        {
            foreach (Personal employee in GetAllEmployees())
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }

            return null;
        }
        private T GetNullable<T>(MySqlDataReader reader, int ordinal, Func<int, T> getValue)
        {
            if (reader.IsDBNull(ordinal))
            {
                return default(T);
            }
            return getValue(ordinal);
        }
    }
}
