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
    public partial class Form1 : Form
    {
        ProductController pc;
        public Form1()
        {
            InitializeComponent();
            pc = new ProductController();
            Dummy();
            btRemove.Hide();
            btUpdate.Hide();
            btCrease.Hide();
            btRequest.Hide();
        }

        private void Dummy()
        {
            pc.AddProduct(new Product("TV", "Philips", 560.20, 40, "Electronics"));
            pc.AddProduct(new Product("Computer", "Philips", 200.2, 25, "Electronics"));
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            UpdateProductForm addForm = new UpdateProductForm(pc);
            addForm.Show();
            
        }


        public void UpdateList()
        {
            lbProducts.Items.Clear();
            foreach(Product p in pc.GetListOfProducts())
            {
                lbProducts.Items.Add(p);
            }
        }

        private void btAllProducts_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lbProducts.SelectedItem;

            lblName.Text = selectedProduct.Name;
            lblType.Text = selectedProduct.Type;
            lblStock.Text = selectedProduct.Stock.ToString();
            lblDepartment.Text = selectedProduct.Department;
            lblPrice.Text = selectedProduct.Price.ToString();

            btUpdate.Show();
            btRemove.Show();
            btCrease.Show();

        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lbProducts.SelectedItem;

            // add confirmbutton
            pc.RemoveProduct(selectedProduct);
            UpdateList();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lbProducts.SelectedItem;

            UpdateProductForm addForm = new UpdateProductForm(pc, selectedProduct);
            addForm.Show();
        }

        private void btCrease_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lbProducts.SelectedItem;
            Increase creaseForm = new Increase(selectedProduct);
            creaseForm.Show();
        }
    }
}
