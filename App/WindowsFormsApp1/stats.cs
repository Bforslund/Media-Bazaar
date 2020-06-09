using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Stats
    {
        public int userRole = 3; //Global user variable
        MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);

        List<Product> prodlist = new List<Product>();

        public List<Product> GetData()
        {
            string query = "SELECT id, type, name, buy_price, sell_price, stock, department, min_stock FROM `products`";

            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    Department d = new DepartmentController().GetDepartment(Convert.ToInt32(reader["department"]));
                    prodlist.Add(new Product(Convert.ToInt32(reader["id"]), reader["type"].ToString(), reader["name"].ToString(), Convert.ToDouble(reader["sell_price"]), Convert.ToDouble(reader["buy_price"]), Convert.ToInt32(reader["stock"]), Convert.ToInt32(reader["min_stock"]), d));
                }
                databaseConnection.Close();
                return prodlist;
            }
            catch(MySqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                databaseConnection.Close();
                throw;
            }
        }
        public StoreStats loadEmployeeCostStats(string begin, string end)
        {

            string query = "SELECT MONTHNAME(@begin) as Month ,concat(SUM(u.wage) * 8) AS EmployeeCost, getSales.total AS TotalSales, getOrders.totalCost AS totalCosts FROM users u INNER JOIN ( SELECT SUM(amount * p.sell_price) as total FROM saleshistory sh INNER JOIN products p ON p.id = sh.products_id WHERE date BETWEEN CAST(@begin AS DATE) AND CAST(@end AS DATE)) as getSales INNER JOIN ( SELECT SUM(amount * p.buy_price) as totalCost FROM ordertable ot INNER JOIN products p ON p.id = ot.productId WHERE date BETWEEN CAST(@begin AS DATE) AND CAST(@end AS DATE) AND ot.approved = 1) AS getOrders INNER JOIN users_has_shift uhs ON u.id = uhs.users_id INNER JOIN shift s ON s.id = uhs.shift_id INNER JOIN day d ON d.id = s.day_id WHERE uhs.checkedIn = 1 AND d.day BETWEEN CAST(@begin AS DATE) AND CAST(@end AS DATE)";
            StoreStats month = new StoreStats();
            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@begin", begin);
                commandDatabase.Parameters.AddWithValue("@end", end);
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    month = new StoreStats(reader["Month"].ToString(), GetNullable(reader, 1, reader.GetDecimal), GetNullable(reader, 2, reader.GetDecimal), GetNullable(reader, 3, reader.GetDecimal));
                }
                databaseConnection.Close();
                return month;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> loadSchedule(string date, int shifttype)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            string query = "SELECT CONCAT(username,0x20,lastname) FROM users u INNER JOIN users_has_shift uhs ON u.id = uhs.users_id INNER JOIN shift s ON uhs.shift_id = s.id INNER JOIN day d ON s.id WHERE d.day = @date AND s.shifttype = @shifttype";
            List<string> retlist = new List<string>();
            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@date", date);
                commandDatabase.Parameters.AddWithValue("@shifttype", shifttype);
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    retlist.Add((string)reader.GetValue(0));
                }
                databaseConnection.Close();
                return retlist;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Product> GetDepartmentData()
        {

            string query = "SELECT d.name, SUM(amount) as total FROM saleshistory sh INNER JOIN products p ON sh.products_id = p.id INNER JOIN department d ON p.department = d.id GROUP BY d.name";

            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    prodlist.Add(new Product(reader["name"].ToString(), Convert.ToInt32(reader["total"])));

                }
                databaseConnection.Close();
                return prodlist;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                databaseConnection.Close();
                throw;
            }
        }
        public void login(string usr, string pwd)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            string query = "SELECT privilage FROM users WHERE username = @usr AND password = @pwd";

            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@usr", usr);
                commandDatabase.Parameters.AddWithValue("@pwd", pwd);
                MySqlDataReader reader = commandDatabase.ExecuteReader();

                if (reader.Read())
                {
                    //MessageBox.Show("Success!");
                    userRole = Convert.ToInt32(reader.GetValue(0));
                }
                else
                {
                    MessageBox.Show("Error: Wrong Username or Password");
                }
                databaseConnection.Close();
            }
            catch (Exception)
            {

                throw;
            }
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
