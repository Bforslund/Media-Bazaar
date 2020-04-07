using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class User
    {
        private MySqlConnection databaseConnection = DatabaseInfo.sqlConnection;

        public void registerUser(string user, string pass, string first, string last, string dob, string addr, string email, string phone)
        {
            //Auto increment issues?
            string query;
            query = "INSERT INTO users (username, password, firstname, lastname, privilage, wage, hiredate, birthday, adress, email, phone, contract, department_id)";
            query += "VALUES(@user, @pass, @first, @last, 0, 12.50, '2020-03-20', @dob, @addr, @email, @phone, 1, NULL)";

            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@user", user);
                commandDatabase.Parameters.AddWithValue("@pass", pass);
                commandDatabase.Parameters.AddWithValue("@first", first);
                commandDatabase.Parameters.AddWithValue("@last", last);
                commandDatabase.Parameters.AddWithValue("@dob", dob);
                commandDatabase.Parameters.AddWithValue("@addr", addr);
                commandDatabase.Parameters.AddWithValue("@email", email);
                commandDatabase.Parameters.AddWithValue("@phone", phone);

                commandDatabase.ExecuteNonQuery();
                databaseConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int checkAttendance(string employee, int status)
        {
            string query = "SELECT count(uhs.checkedIn) FROM users u INNER JOIN users_has_shift uhs ON u.id = uhs.users_id WHERE uhs.checkedIn = @status AND CONCAT(u.firstname,' ',u.lastname) = @employee";

            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@status", status);
                commandDatabase.Parameters.AddWithValue("@employee", employee);

                int output = Convert.ToInt32(commandDatabase.ExecuteScalar());
                databaseConnection.Close();
                return output;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
