using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class UpdateProductForm : Form
    {
        ProductController pc;
        Product p;
        bool edit;
        public UpdateProductForm(ProductController pc)
        {
            edit = false;
            InitializeComponent();
            this.pc = pc;
        }
        public UpdateProductForm(ProductController pc, Product p)
            : this(pc)
        {
            edit = true;
            this.p = p;
            this.Text = "Update existing product";
            btAddUpdate.Text = "Update product";
            this.BackColor = Color.IndianRed;


            tbType.Text = p.Type;
            tbName.Text = p.Name;
            tbPrice.Text = p.Price.ToString();
            
            tbDepartment.Text = p.Department;
        }

        private bool UpdateProduct()
        {
            bool success;
            try
            {
                p.Type = tbType.Text;
                p.Name = tbName.Text;
                p.Price = Convert.ToDouble(tbPrice.Text);
                p.Department = tbDepartment.Text;
                pc.UpdateProduct(p);
                success = true;
            }
            catch
            {
                MessageBox.Show("Something went wrong");
                success = false;
            }
            return success;
        }
        private bool AddProduct()
        {
            bool success;
            try
            {
                string type = tbType.Text;
                string name = tbName.Text;

                double price = Convert.ToDouble(tbPrice.Text);

                string department = tbDepartment.Text;

                Product newProduct = new Product(type, name, price, 0, 0, department);
                pc.AddProduct(newProduct);
                success = true;
            }
            catch
            {
                MessageBox.Show("Something went wrong");
                success = false;
            }
            return success;

        }
        private void btAddUpdate_Click(object sender, EventArgs e)
        {
           
            if (edit)
            {
                bool success;
                success = UpdateProduct();
                if (success)
                {
                    MessageBox.Show("Product successfully Updated!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Try again!");
                }
                
            }
            else
            {
                bool success;
                success = AddProduct();
                if (success)
                {
                    MessageBox.Show("Product successfully added!");
                this.Close();
                }
                else
                {
                    MessageBox.Show("Try again!");
                }
            }
        }
    }
}
