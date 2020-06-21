using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Product
    {
        private int id;
        private string type;
      
        private string name;
        private double buyingprice;
        private double sellingprice;
        private int stock;
        private int min_stock;
        private Department department;

        public string Type { get => type; set => type = value; }
        
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public Department Department { get => department; set => department = value; }
        public double Buyingprice
        {
            get
            {
                return buyingprice;
            }
            set
            {
                if (value > sellingprice)
                {
                    throw new Exception();
                }
                else
                {
                    buyingprice = value;
                }
            }
        }
        public double Sellingprice // So selling price cant be lower than the bought price
        {
            get
            {
                return sellingprice;
            }
            set
            {
                if (value < buyingprice)
                {
                    throw new Exception();
                }
                else
                {
                    sellingprice = value;
                }
            }
        }

        public int Stock
        {
            get
            {
                return stock;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    stock = value;
                }
            }
        }

        public int Min_stock
        {
            get { return min_stock; }
            set { min_stock = value; }
        }
        public Product(string name, double profit)
        {
            this.Name = name;
            this.Sellingprice = profit;
        }
        public Product(string name, int amount, double profit)
        {
            this.Name = name;
            this.Stock = amount;
            this.Sellingprice = profit;
        }
        public Product(string name, int amount)
        {
            this.Name = name;
            this.Stock = amount;
        }
        public Product(int id, int amount)
        {
            this.Id = id;
            this.Stock = amount;
        }
        public Product()
        {

        }

        public Product(string type, string name, double sellingPrice, double buyingPrice, int stock, int min_stock, Department department) 
            : this(0, type, name, sellingPrice, buyingPrice, stock, min_stock, department)
        {
        }

        public Product(int id, string type,  string name, double sellingPrice, double buyingPrice, int stock, int min_stock, Department department)
        {
            this.id = id;
            this.Type = type;
            this.Stock = stock;
            this.Name = name;
            this.Sellingprice = sellingPrice;
            this.Buyingprice = buyingPrice;
            this.min_stock = min_stock;


            this.Department = department;
        }

      

        public override string ToString()
        {
            return $"{Type} {Name}";
        }
    }
}
