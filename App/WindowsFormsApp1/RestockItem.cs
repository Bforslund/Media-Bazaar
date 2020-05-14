using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public class RestockItem : Product
    {
        MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
        List<Product> prodlistToRestock = new List<Product>();


        private int id;
        private string userId;
        private string productID; //id of the product being restocked
        private DateTime dateOfRestock;
        private int amountOfrestock;
        private int status;
        private string message;


        public string UserId { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }

        public DateTime DateOfRestock { get; set; }
        public int AmountOfrestock { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

        public RestockItem(int id, string userId, string productId, DateTime dateOfRestock, int amountOfRestock, int status, string message) : base(id, amountOfRestock)
        {
            this.Id = id;
            this.UserId = userId;
            this.ProductID = productID;
            this.DateOfRestock = dateOfRestock;
            this.AmountOfrestock = amountOfrestock;
            this.Status = status;
            this.Message = message;

        }
        public RestockItem(int id, string userId, string productId, DateTime dateOfRestock, int amountOfRestock) : base(id, amountOfRestock)
        {
            this.Id = id;
            this.UserId = userId;
            this.ProductID = productID;
            this.DateOfRestock = dateOfRestock;
            this.AmountOfrestock = amountOfrestock;
        }
        public RestockItem()
        {

        }
        //!inserting an item to the outstanding requests list
        public void RequestRestockOfitem(Product productToRestock, DateTime timeOfRequest) //TODO User userdInitiatingRestock 
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "INSERT INTO restock (products, date, amount, approved) VALUES(@products, @date,null, null)"; //amount removed
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);

                //TODO cmd.Parameters.AddWithValue("@users", this.UserId); apply it later

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
        public void RejectRequest(RestockItem restockItemToReject, int approved, string message) //TODO User userdInitiatingRestock 
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();
                string sql = "UPDATE restock SET approved = @approved, message=@message WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@id", restockItemToReject.Id);

                cmd.Parameters.AddWithValue("@approved", approved);
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
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "UPDATE restock SET amount = (amount+@amount), approved=1 WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@id", r.Id);

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
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "UPDATE products SET stock = (stock + @value) WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@stock", r.Stock);
                cmd.Parameters.AddWithValue("@id", r.Id);
                cmd.Parameters.AddWithValue("@value", value);
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
            //? something broken
            //TODO display the product name
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            List<RestockItem> retlist = new List<RestockItem>();
            try
            {
                string query = "SELECT r.id, u.username, p.name, r.date, r.amount FROM restock r INNER JOIN products p ON r.products = p.id INNER JOIN users u ON r.users=u.id WHERE r.approved IS NULL ";

                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

                MySqlDataReader reader = commandDatabase.ExecuteReader();
                //int id, string userId, string productId, DateTime dateOfRestock, int amountOfRestock
                while (reader.Read())
                {
                    retlist.Add(new RestockItem(Convert.ToInt32(reader["id"]), Convert.ToString(reader["username"]), Convert.ToString(reader["name"]), Convert.ToDateTime(reader["date"]), GetNullable(reader, 4, reader.GetInt32)));
                }
                databaseConnection.Close();
                return retlist;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<RestockItem> GetCompeletedData()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            List<RestockItem> retlist = new List<RestockItem>();
            try
            {
                string query = "SELECT r.id, u.username, p.name, r.date, r.amount, r.approved, r.message FROM restock r INNER JOIN products p ON r.products = p.id INNER JOIN users u ON r.users=u.id WHERE r.approved = 1 OR r.approved = 0";

                databaseConnection.Open();
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

                MySqlDataReader reader = commandDatabase.ExecuteReader();

                while (reader.Read())
                {
                    bool approved = false;
                    if (Convert.ToString(reader["approved"]) == "1") //if 1
                    {
                        approved = true;
                    }
                    // int id, string userId, string productId, DateTime dateOfRestock, int amountOfRestock, bool status, string message
                    retlist.Add(new RestockItem(Convert.ToInt32(reader["id"]), Convert.ToString(reader["username"]), Convert.ToString(reader["name"]), Convert.ToDateTime(reader["date"]), GetNullable(reader, 4, reader.GetInt32), GetNullable(reader, 5, reader.GetInt32), GetNullable(reader, 6, reader.GetString)));
                }
                databaseConnection.Close();
                return retlist;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        public override string ToString()
        {

            return $"{base.Id} {this.UserId} {this.ProductID} {this.DateOfRestock} {this.AmountOfrestock}";

        }
        public string ToStringWithMsg()
        {
            return $"{base.Id} {this.UserId} {this.ProductID} {this.DateOfRestock} {this.AmountOfrestock} {this.Status} {this.Message}";
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
