﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public class SQLhelper
    {

        MySqlConnection conn = DatabaseInfo.sqlConnection;
        //MySqlConnection conn = new MySqlConnection("Server = studmysql01.fhict.local; Uid=dbi431685;Database=dbi431685;Pwd=");

        public void OpenConnection()
        {
            conn.Open();
        }

        public void AddProducts(Product p)
        {
            string sql = "INSERT INTO products (type, name, price, stock, department ) VALUES(@type, @name, @price, @stock, @department)";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@type", p.Type);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
            cmd.Parameters.AddWithValue("@stock", p.Stock);
            cmd.Parameters.AddWithValue("@department", p.Department);

            cmd.ExecuteNonQuery();
        }

        public void UpdateProduct(Product p)
        {
            string sql = "UPDATE products SET type = @type, name = @name, price = @price, department = @department WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@type", p.Type);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@price", p.Price);
            cmd.Parameters.AddWithValue("@department", p.Department);

            cmd.ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            conn.Close();
        }

        public List<Product> GetAllProducts()
        {
            string sql = "SELECT id, type, name, price, stock, department FROM Products";
            List<Product> returnedProducts = new List<Product>();
            MySqlCommand cmd = new MySqlCommand(sql, conn);



            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                Product p = new Product(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDouble(dr[3]), Convert.ToInt32(dr[4]), dr[5].ToString());
                returnedProducts.Add(p);

            }
            return returnedProducts;
        }
        public void DeleteProduct(Product p)
        {
            string sql = "DELETE FROM products WHERE products.id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.ExecuteNonQuery();
        }

        public void IncreaseStock(Product p, int value)
        {
            string sql = "UPDATE products SET stock = (@stock + @value) WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@stock", p.Stock);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.ExecuteNonQuery();
        }
        public void DecreaseStock(Product p, int value)
        {
            string sql = "UPDATE products SET stock = (@stock - @value) WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@stock", p.Stock);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@value", value);
            cmd.ExecuteNonQuery();
        }

    }


}

