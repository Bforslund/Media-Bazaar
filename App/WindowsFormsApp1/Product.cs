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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
