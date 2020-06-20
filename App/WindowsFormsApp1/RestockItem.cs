using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    class RestockItem : Product
    {
        private int id;
        private string userId;
        private string productId; //id of the product being restocked
        private DateTime dateOfRestock;
        private int amountOfRestock;
        private int status;
        private string message;

        public int Id { get { return this.id; } set {
                if (value <0)
                {
                    throw new ArgumentNullException();
                }
                id = value;
            } }
        public string UserId { get { return this.userId; } set {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                userId = value;
            } }
        public string ProductId { get { return this.productId; } set {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                productId = value;
            } }
        public DateTime DateOfRestock { get { return this.dateOfRestock; } set{
                
                dateOfRestock = value;
            } }
        public int AmountOfRestock { get { return this.amountOfRestock; } set{
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                amountOfRestock = value;
            } }
        public int Status { get { return this.status; } set {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                status = value;
            } }
        public string Message { get { return this.message; } set {
            } }

        public RestockItem(int id, string userId, string productID, DateTime dateOfRestock, int amountOfRestock, int status, string message) : base(id, amountOfRestock)
        {
            this.UserId = userId;
            this.ProductId = productID;
            this.DateOfRestock = dateOfRestock;
            this.Status = status;
            this.Message = message;
            this.AmountOfRestock = amountOfRestock;

        }
        public RestockItem(int id, string userId, string productID, DateTime dateOfRestock, int amountOfRestock) : base(id, amountOfRestock)
        {
            this.UserId = userId;
            this.ProductId = productID;
            this.DateOfRestock = dateOfRestock;
            this.AmountOfRestock = amountOfRestock;

        }
        public RestockItem()
        {

        }
        
        public override string ToString()
        {

            return $"{base.Id} {this.UserId} {this.ProductId} {this.DateOfRestock.ToString("dddd, dd MMMM yyyy, hh:mm")} {this.AmountOfRestock}";

        }
        public string ToStringWithMsg()
        {
            return $"{base.Id} {this.UserId} {this.ProductId} {this.DateOfRestock.ToString("dddd, dd MMMM yyyy, hh:mm")} {this.AmountOfRestock} {this.Status} {this.Message}";
        }
        
    }
}
