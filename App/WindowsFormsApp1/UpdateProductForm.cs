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
        DepartmentController dc;
        Product p;
        bool edit;
        public UpdateProductForm(ProductController pc, DepartmentController dc)
        {
            edit = false;
            this.pc = pc;
            this.dc = dc;
            InitializeComponent();
            foreach(Department d in dc.GetDepartments())
            {
                comboBox1.Items.Add(d);
            }
            
        }
        public UpdateProductForm(ProductController pc, DepartmentController dc, Product p)
            : this(pc, dc)
        {
            edit = true;
            this.p = p;
            this.Text = "Update existing product";
            btAddUpdate.Text = "Update product";


            try
            {
                tbType.Text = p.Type;
                tbName.Text = p.Name;
                tbBuyPrice.Text = p.Buyingprice.ToString();
                tbSellPrice.Text = p.Sellingprice.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Error with selected product");
            }

            try
            {
                foreach (Department department in comboBox1.Items)
                {
                    if (department.Id == p.Department.Id)
                    {
                        comboBox1.SelectedItem = department;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error with selected product.");
            }

        }

        private bool UpdateProduct()
        {
            bool success;
            try
            {
                p.Type = tbType.Text;
                p.Name = tbName.Text;
                p.Buyingprice = Convert.ToDouble(tbBuyPrice.Text);
                p.Sellingprice = Convert.ToDouble(tbSellPrice.Text);
                p.Department = ((Department)comboBox1.SelectedItem);
                pc.UpdateProduct(p);
                success = true;
            }
            catch
            {
                
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
                double sell_price = Convert.ToDouble(tbSellPrice.Text);
                double buy_price = Convert.ToDouble(tbBuyPrice.Text);

                Department department = ((Department)comboBox1.SelectedItem);

                Product newProduct = new Product(type, name, sell_price,buy_price, 0, 0, department);
                pc.AddProduct(newProduct);
                success = true;
            }
            catch(Exception)
            {
                
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
                    MessageBox.Show("You did not fill everything\n" +
                                    "Please fill in everything and try again");
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
                    MessageBox.Show("You did not fill everything\n" +
                                    "Please fill in everything and try again");
                }
            }
        }
    }
}
