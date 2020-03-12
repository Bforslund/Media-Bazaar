using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class ProductController
    {
            private List<Product> products = new List<Product>();
        private List<Product> deletedProducts = new List<Product>();

        public void AddProduct(Product p)
        {
            products.Add(p);
        }

            public void RemoveProduct(Product p)
            {
            products.Remove(p);
            deletedProducts.Add(p);
            }


            public List<Product> RemoveListOfProducts()
            {
            return deletedProducts;
            }

            public Product GetProduct(int id)
            {
                foreach(Product p in products)
                {
                if(p.Id == id)
                {
                    return p;
                }
                }
            return null;
            }

            public List<Product> GetListOfProducts()
            {
            return products;
            }
        }
}
