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
        private double price;
        private int stock;
        private int min_stock;
        private string department;

        public string Type { get => type; set => type = value; }
        
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public int Min_stock
        {
            get { return min_stock; }
            set { min_stock = value; }
        }

        public int Stock 
        { 
            get
            {
                return stock;
            } 
            set 
            { 
                if(value < 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    stock = value;
                }
            }
        }
        public int Id { get => id; set => id = value; }
        public string Department { get => department; set => department = value; }

        public Product(string type, string name, double price, int stock, int min_stock, string department) 
            : this(0, type, name, price, stock, min_stock, department)
        {
        }

        public Product(int id, string type,  string name, double price, int stock, int min_stock, string department)
        {
            this.id = id;
            this.Type = type;
            this.Stock = stock;
            this.Name = name;
            this.Price = price;
            this.min_stock = min_stock;


            this.Department = department;
        }

      

        public override string ToString()
        {
            return $"{Id}:{Type} {Name}";
        }
    }
}
