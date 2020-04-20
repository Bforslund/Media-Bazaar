using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ProductController
    {
        private MySqlConnection databaseConnection = DatabaseInfo.sqlConnection;

        public void AddProduct(Product p)
        {
            try
            {
                databaseConnection.Open();

                string sql = "INSERT INTO products (type, name, price, stock, department, min_stock ) VALUES(@type, @name, @price, @stock, @department, 0)";

                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@type", p.Type);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@price", p.Price);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@department", p.Department);

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

        public void UpdateProduct(Product p)
        {
            try
            {
                databaseConnection.Open();

                string sql = "UPDATE products SET type = @type, name = @name, price = @price, department = @department, min_stock = 0 WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@type", p.Type);
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@price", p.Price);
                cmd.Parameters.AddWithValue("@department", p.Department);

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

        public void DeleteProduct(Product p)
        {

            try
            {
                databaseConnection.Open();

                string sql = "DELETE FROM products WHERE products.id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);

                cmd.Parameters.AddWithValue("@id", p.Id);
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


        
        public List<Product> GetListOfProducts()
        {
            try
            {
                return GetAllProducts();
            }
            catch(MySqlException ex)
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

        public bool DecreaseStock(Product p, int value)
        {
            try
            {
                databaseConnection.Open();
                if (p.Stock - value < 0 || value <= 0)
                {
                    return false;
                }

                else
                {
                    string sql = "UPDATE products SET stock = (@stock - @value) WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
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
        public bool IncreaseStock(Product p, int value)
        {
            try
            {
                databaseConnection.Open();
                if (value <= 0)
                {
                    return false;
                }
                else
                {
                    string sql = "UPDATE products SET stock = (@stock + @value) WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
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
        public List<Product> FilterProducts(string filterTerm) // same the filtering in the schedule
        {
            try
            {
                databaseConnection.Open();
                filterTerm = filterTerm.ToLower(); //makes everything lower case, makes it easier to compare

                if (string.IsNullOrEmpty(filterTerm)) // if no filter term given return all products
                {
                    return GetAllProducts();
                }

                List<Product> filterProducts = new List<Product>();

                foreach (Product p in GetAllProducts())
                {
                    if (p.ToString().ToLower().IndexOf(filterTerm) >= 0) // check if the product contains a part of the filter term
                    {
                        filterProducts.Add(p);
                    }
                }

                return filterProducts;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                databaseConnection.Close();
            }

        }

        public List<Product> GetAllProducts()
        {
            databaseConnection.Open();
            string sql = "SELECT id, type, name, price, stock, department, min_stock FROM Products";
            List<Product> returnedProducts = new List<Product>();
            MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);



            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                Product p = new Product(Convert.ToInt32(dr["id"]), dr["type"].ToString(), dr["name"].ToString(), Convert.ToDouble(dr["price"]), Convert.ToInt32(dr["stock"]), Convert.ToInt32(dr["min_stock"]), dr["department"].ToString());
                returnedProducts.Add(p);


            }
            databaseConnection.Close();
            return returnedProducts;
        }
    }
}
