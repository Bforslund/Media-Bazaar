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
        private static int IdSeeder = 1;
        private string type;
      
        private string name;
        private double price;
        private int stock;
        private string department;

        public string Type { get => type; set => type = value; }
        
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Id { get => id; set => id = value; }
        public string Department { get => department; set => department = value; }

        public Product(string type,  string name, double price, int stock, string department)
        {
            this.Id = IdSeeder;
            this.Type = type;
           
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Department = department;
            IdSeeder++;
        }

      

        public override string ToString()
        {
            return $"{Id}:{Type} {Name}";
        }
    }
}
