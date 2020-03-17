using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ProductController
    {
        SQLhelper sql = new SQLhelper();

        public void AddProduct(Product p)
        {
            try
            {
                sql.OpenConnection();
                sql.AddProducts(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConnection();
            }
        }

        public void UpdateProduct(Product p)
        {
            try
            {
                sql.OpenConnection();
                sql.UpdateProduct(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConnection();
            }
        }

        public void DeleteProduct(Product p)
        {

            try
            {
                sql.OpenConnection();
                sql.DeleteProduct(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConnection();
            }
        }


        
        public List<Product> GetListOfProducts()
        {
            try
            {
                sql.OpenConnection();

                return sql.GetAllProducts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                sql.CloseConnection();
            }
        }

        public bool DecreaseStock(Product p, int value)
        {
            try
            {
                sql.OpenConnection();
                if (p.Stock - value < 0 || value <= 0)
                {
                    return false;
                }

                else
                {
                    sql.DecreaseStock(p, value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConnection();
            }
           

        }
        public bool IncreaseStock(Product p, int value)
        {
            try
            {
                sql.OpenConnection();
                if (value <= 0)
                {
                    return false;
                }
                else
                {
                    sql.IncreaseStock(p, value);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConnection();
            }
          
        }
        public List<Product> FilterProducts(string filterTerm) // same the filtering in the schedule
        {
            try
            {
                sql.OpenConnection();
                filterTerm = filterTerm.ToLower(); //makes everything lower case, makes it easier to compare

                if (string.IsNullOrEmpty(filterTerm)) // if no filter term given return all products
                {
                    return sql.GetAllProducts();
                }

                List<Product> filterProducts = new List<Product>();

                foreach (Product p in sql.GetAllProducts())
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
                sql.CloseConnection();
            }

        }
    }
}
