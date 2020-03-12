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
    // ADD SQL & TRY CATCH
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
            tbStock.ReadOnly = true;
            
            tbType.Text = p.Type;
            tbName.Text = p.Name;
            tbPrice.Text = p.Price.ToString();
            tbStock.Text = p.Stock.ToString();
            tbDepartment.Text = p.Department;
        }

        private void UpdateProduct()
        {
            p.Stock = Convert.ToInt32(tbStock.Text);
            p.Type = tbType.Text;
            p.Name = tbName.Text;
            p.Price = Convert.ToDouble(tbPrice.Text);
            p.Department = tbDepartment.Text;
            MessageBox.Show("Product successfully updated!");
            this.Close();
        }
        private void AddProduct()
        {
            // add try thing
            string type = tbType.Text;
            string name = tbName.Text;

            double price = Convert.ToDouble(tbPrice.Text);
            int stock = Convert.ToInt32(tbStock.Text);
            string department = tbDepartment.Text;

            Product newProduct = new Product(type, name, price, stock, department);
            pc.AddProduct(newProduct);
            MessageBox.Show("Product successfully added!");
            this.Close();
        }
        private void btAddUpdate_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                UpdateProduct();
            }
            else
            {
                AddProduct();
            }
        }
    }
}
