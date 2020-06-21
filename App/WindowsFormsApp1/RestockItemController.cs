using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace Mediabazaar
{
    class RestockItemController
    {
     
        List<RestockItem> retlistCompleted = new List<RestockItem>();

        //!inserting an item to the outstanding requests list
        public void RequestRestockOfitem(Product productToRestock, DateTime timeOfRequest)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "INSERT INTO restock (products, date, amount, approved) VALUES(@products, @date,null, null)"; //amount removed
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@products", productToRestock.Id); //product id
                cmd.Parameters.AddWithValue("@date", timeOfRequest);
                //cmd.Parameters.AddWithValue("@amount", productToRestock.amout); 
                //? is the above necessary ?

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw ex;
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
        public void RejectRequest(RestockItem restockItemToReject, string message) //done 
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();
                string sql = "UPDATE restock SET approved = @approved, message=@message WHERE rId=@rId";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@rId", restockItemToReject.RestockId);
                cmd.Parameters.AddWithValue("@approved", 0);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw ex;
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
        public void IncreaseRestockItem(RestockItem r, int amount)
        {
            increaseInRestock(r, amount);
            increaseInProducts(r, amount);

        }
        private void increaseInRestock(RestockItem r, int amount)
        {
            int newStock = r.Product.Stock + amount;
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);

            try
            {
                databaseConnection.Open();
                string sql = "UPDATE restock SET amount = @amount, approved=1 WHERE rId=@rId";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@rId", r.RestockId);
                cmd.Parameters.AddWithValue("@amount", newStock);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
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

        private void increaseInProducts(RestockItem r, int value)
        {
            int newStock = r.Product.Stock + value;

            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);

            try
            {
                databaseConnection.Open();
                string sql = "UPDATE products SET stock = stock + @stock WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@id", r.Product.Id);
                cmd.Parameters.AddWithValue("@stock", newStock);
                //cmd.Parameters.AddWithValue("@id", 9);
                //cmd.Parameters.AddWithValue("@stock", 1);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
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
        #region fetching the data

        //!Getting the data
        public List<RestockItem> GetOutstandingData()
        {
            List<RestockItem> retlistOutstanding = new List<RestockItem>();
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            //r.id, u.username, p.name, r.date, r.amount
            try
            {
                string query = "SELECT r.rId, p.id, u.username, p.name, r.date FROM restock r INNER JOIN products p ON r.products = p.id INNER JOIN users u ON r.users=u.id WHERE r.approved IS NULL ";
                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                MySqlDataReader reader;

                reader = commandDatabase.ExecuteReader();
                //int id, string userId, string productId, DateTime dateOfRestock, int amountOfRestock
                while (reader.Read())
                {
                    int _rId = Convert.ToInt32(reader["rId"]);
                    int _productId = Convert.ToInt32(reader["id"]);
                    string _username = reader["username"].ToString();
                    string _productName = (reader["name"]).ToString();
                    DateTime _dateOfRequest = Convert.ToDateTime(reader["date"]);
                    RestockItem r = new RestockItem(_rId, _productId, _username, _productName, _dateOfRequest);

                    //RestockItem r = new RestockItem(Convert.ToInt32(reader["id"]), reader["username"].ToString(), (reader["name"]).ToString(), Convert.ToDateTime(reader["date"]), GetNullable(reader, 4, reader.GetInt32));

                    retlistOutstanding.Add(r);
                }
                databaseConnection.Close();
                return retlistOutstanding;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<RestockItem> GetCompeletedData()
        {
            retlistCompleted.Clear();

            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            string query = "SELECT r.rId,p.id, u.username, p.name,r.date, r.amount, r.approved, r.message FROM restock r INNER JOIN products p ON r.products = p.id INNER JOIN users u ON r.users=u.id WHERE r.approved = 1 OR r.approved = 0";
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            try
            {
                databaseConnection.Open();

                MySqlDataReader reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    bool approved = false;
                    if (Convert.ToString(reader["approved"]) == "1") //if 1
                    {
                        approved = true;
                    }
                    // int id, string userId, string productId, DateTime dateOfRestock, int amountOfRestock, bool status, string message
                    retlistCompleted.Add(new RestockItem(Convert.ToInt32(reader["rId"]),Convert.ToInt32(reader["id"]), Convert.ToString(reader["username"]), Convert.ToString(reader["name"]), Convert.ToDateTime(reader["date"]), GetNullable(reader, 5, reader.GetInt32), GetNullable(reader, 6, reader.GetInt32), GetNullable(reader, 7, reader.GetString)));
                }
                databaseConnection.Close();
                return retlistCompleted;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        #endregion

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
