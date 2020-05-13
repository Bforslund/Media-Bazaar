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
        public void AddProduct(Product p)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "INSERT INTO products (type, name, buy_price, sell_price, stock, department, min_stock ) VALUES(@type, @name, @buy_price, @sell_price, @stock, @department, 0)";

                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@type", p.Type);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@buy_price", p.Buyingprice);
                cmd.Parameters.AddWithValue("@sell_price", p.Sellingprice);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@department", p.Department.Id);

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
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            try
            {
                databaseConnection.Open();

                string sql = "UPDATE products SET type = @type, name = @name, buy_price = @buy_price, sell_price = @sell_price, department = (SELECT id FROM department WHERE name = @department) WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.Parameters.AddWithValue("@type", p.Type);
                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@buy_price", p.Buyingprice);
                cmd.Parameters.AddWithValue("@sell_price", p.Sellingprice);
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
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
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

        public bool DecreaseStock(Product p, int value)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
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
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
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
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
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
            MySqlConnection databaseConnection = new MySqlConnection(DatabaseInfo.connectionString);
            List<Product> products = new List<Product>();
            try
            {
                databaseConnection.Open();
                string sql = "SELECT id, type, name, buy_price, sell_price, stock, department, min_stock FROM Products";
                
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Department d = new DepartmentController().GetDepartment(Convert.ToInt32(dr["department"]));
                    Product p = new Product(Convert.ToInt32(dr["id"]),dr["type"].ToString(), dr["name"].ToString(), Convert.ToDouble(dr["sell_price"]), Convert.ToDouble(dr["buy_price"]), Convert.ToInt32(dr["stock"]), Convert.ToInt32(dr["min_stock"]), d);
                    products.Add(p);
                }
                return products;
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

        
    }
}
