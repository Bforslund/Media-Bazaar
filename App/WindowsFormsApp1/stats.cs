﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    class Stats
    {
        private MySqlConnection databaseConnection = DatabaseInfo.sqlConnection;

        List<Product> prodlist = new List<Product>();

        public List<Product> GetData()
        {
            string query = "SELECT type, name, price, stock, department, min_stock FROM `products`";

            try
            {
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;

                reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    prodlist.Add(new Product(reader["type"].ToString(), reader["name"].ToString(), Convert.ToDouble(reader["price"]), Convert.ToInt32(reader["stock"]), Convert.ToInt32(reader["min_stock"]), reader["department"].ToString()));
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

        public List<string> loadSchedule(string date, int shifttype)
        {
            string query = "SELECT CONCAT(username,0x20,lastname) FROM users u INNER JOIN users_has_shift uhs ON u.id = uhs.users_id INNER JOIN shift s ON uhs.shift_id = s.id INNER JOIN day d ON s.id = @date WHERE d.day = @date AND s.shifttype = @shifttype";
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
    }
}
