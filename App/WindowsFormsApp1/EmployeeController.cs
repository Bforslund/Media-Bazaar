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

            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int privilage = Convert.ToInt32(reader["privilage"]);
                        double wage = Convert.ToDouble(reader["wage"]);
                        DateTime hiredate = Convert.ToDateTime(reader["hiredate"]);
                        DateTime birthday = Convert.ToDateTime(reader["birthday"]);
                        string allergies = reader["allergies"].ToString();
                        string adress = reader["adress"].ToString();
                        string email = reader["email"].ToString();
                        string phone = reader["phone"].ToString();
                        int contract = Convert.ToInt32(reader["contract"]);
                        Department department = new DepartmentController().GetDepartment(Convert.ToInt32(reader["department_id"]));

                        personals.Add(new Employee(id, email, firstname, lastname, privilage, username, password, adress, birthday, allergies, contract, department, hiredate, phone, wage));
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

        public List<Personal> GetAllEmployees() // This one is used to fill people in departments. Reusing the other one does not seem to work without getting bugs.
        {  
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            string query = "SELECT * FROM `users`";

            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);

            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)// check if any rows are found
                {
                    while (reader.Read()) //read each individual row
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int privilage = Convert.ToInt32(reader["privilage"]);
                        double wage = Convert.ToDouble(reader["wage"]);
                        DateTime hiredate = Convert.ToDateTime(reader["hiredate"]);
                        DateTime birthday = Convert.ToDateTime(reader["birthday"]);
                        string allergies = reader["allergies"].ToString();
                        string adress = reader["adress"].ToString();
                        string email = reader["email"].ToString();
                        string phone = reader["phone"].ToString();
                        int contract = Convert.ToInt32(reader["contract"]);
                        Department department = new DepartmentController().GetDepartment(Convert.ToInt32(reader["id"]));

                        AllEmployees.Add(new Employee(id, email, firstname, lastname, privilage, username, password, adress, birthday, allergies, contract, department, hiredate, phone, wage));
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


        public void saveEmployeeData(Employee e)
        {

                MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();
                string insertQuery = $"INSERT INTO users(username, password, firstname, lastname, privilage, wage, hiredate, birthday, allergies, adress, email, phone, contract, department_id) VALUES(@username, @password, @firstname, @lastname, @privilage, @wage, @hiredate, @birthday, @allergies, @adress, @email, @phone,@contract, @department)";
                

                MySqlCommand cmd = new MySqlCommand(insertQuery, databaseConnection);
                cmd.Parameters.AddWithValue("@username", e.Username);
                cmd.Parameters.AddWithValue("@password", e.Password);
                cmd.Parameters.AddWithValue("@firstname", e.FirstName);
                cmd.Parameters.AddWithValue("@lastname", e.LastName);
                cmd.Parameters.AddWithValue("@privilage", e.Privilage);
                cmd.Parameters.AddWithValue("@wage", e.Wage);
                cmd.Parameters.AddWithValue("@hiredate", e.Hiredate);
                cmd.Parameters.AddWithValue("@birthday", e.Birthday);
                cmd.Parameters.AddWithValue("@allergies", e.Allergies);
                cmd.Parameters.AddWithValue("@adress", e.Adress);
                cmd.Parameters.AddWithValue("@email", e.Email);
                cmd.Parameters.AddWithValue("@phone", e.PhoneNumber);
                cmd.Parameters.AddWithValue("@contract", e.Contract);
                cmd.Parameters.AddWithValue("@department", e.Department.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                databaseConnection.Close();
            }
                

        }

    public void UpdateEmployee(Employee e)
    {
        MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();
                string insertQuery = $"UPDATE users SET firstname = @firstname, lastname = @lastname, privilage = @privilage, wage = @wage, hiredate = @hiredate, birthday = @birthday, allergies = @allergies, adress = @adress, email = @email, phone = @phone, contract = @contract, department_id = (SELECT id FROM department WHERE name = @department) WHERE id = @id";

                


                MySqlCommand cmd = new MySqlCommand(insertQuery, databaseConnection);
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.Parameters.AddWithValue("@firstname", e.FirstName);
                cmd.Parameters.AddWithValue("@lastname", e.LastName);
                cmd.Parameters.AddWithValue("@privilage", e.Privilage);
                cmd.Parameters.AddWithValue("@wage", e.Wage);
                cmd.Parameters.AddWithValue("@hiredate", e.Hiredate);
                cmd.Parameters.AddWithValue("@birthday", e.Birthday);
                cmd.Parameters.AddWithValue("@allergies", e.Allergies);
                cmd.Parameters.AddWithValue("@adress", e.Adress);
                cmd.Parameters.AddWithValue("@email", e.Email);
                cmd.Parameters.AddWithValue("@phone", e.PhoneNumber);
                cmd.Parameters.AddWithValue("@contract", e.Contract);
                cmd.Parameters.AddWithValue("@department", e.Department);
                cmd.ExecuteNonQuery();

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
      
    }
}
