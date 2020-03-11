using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class Product
    {
        private string type;
        private string brand;
        private string name;
        private double price;
        private int stock;
        private int minStock;

        public string Name { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }
        public int MinStock { get; set; }

        public Product()
        {

        }

        public Product(string _name, double _price, int _stock, int _minStock)
        {
            this.name = _name;
            this.price = _price;
            this.stock = _stock;
            this.minStock = _minStock;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
