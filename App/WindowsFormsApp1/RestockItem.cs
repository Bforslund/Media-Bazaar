using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    class RestockItem
    {
        private int restockId;
        private string userName;
        //private string productId; //id of the product being restocked
        private Product product = new Product(); //would be better if there was no inheritance but rather composition, passing this line, but lack of time does not allow to change everything without affecting the rest of the team
        private DateTime dateOfRestock;
        private int amountOfRestock;
        private int status;
        private string message;

        public int RestockId
        {
            get { return this.restockId; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                restockId = value;
            }
        }
        public string UserName
        {
            get { return this.userName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                userName = value;
            }
        }
        public Product Product
        {
            get { return this.product; }
            set
            {
                if (product == null)
                {
                    throw new ArgumentNullException();
                }
                product = value;
            }
        }
        //public string ProductId { get { return this.productId; } set {
        //        if (value == null)
        //        {
        //            throw new ArgumentNullException();
        //        }
        //        productId = value;
        //    } }
        public DateTime DateOfRestock
        {
            get { return this.dateOfRestock; }
            set
            {

                dateOfRestock = value;
            }
        }
        public int AmountOfRestock
        {
            get { return this.amountOfRestock; }
            set
            {
                amountOfRestock = value;
            }
        }
        public int Status
        {
            get { return this.status; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                status = value;
            }
        }
        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
            }
        }

        public RestockItem(int restockId, int productID, string userName, string productName, DateTime dateOfRestock, int amountOfRestock, int status, string message) 
        {
            this.RestockId = restockId;
            this.Product.Id = productID;
            this.UserName = userName;
            this.Product.Name = productName;
            this.DateOfRestock = dateOfRestock;
            this.Status = status;
            this.Message = message;
            this.AmountOfRestock = amountOfRestock;

        }
        public RestockItem(int restockId, int productID, string userName, string productName, DateTime dateOfRestock) 
        {
            this.RestockId = restockId;
            this.Product.Id = productID;
            this.UserName = userName;
            this.Product.Name = productName;
            this.DateOfRestock = dateOfRestock;
        }
        public RestockItem()
        {

        }

        public override string ToString()
        {

            return $"{this.RestockId}, {this.UserName}, {this.Product.Name}, {this.DateOfRestock.ToString("dd MMMM yyyy")}";

        }
        public string ToStringWithMsg()
        {
            return $"{this.RestockId}, {this.UserName}, {this.Product.Name}, {this.DateOfRestock.ToString("dd MMMM yyyy")}, Q: {this.AmountOfRestock}, S: {this.Status} \n {this.Message}";
        }

    }
}
