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
    public partial class MediaBazaar : Form
    {
        ProductController pc;
     
        public MediaBazaar()
        {
            InitializeComponent();
            pc = new ProductController();
               
           
            UpdateList();
            btRemove.Hide();
            btUpdate.Hide();
            btCrease.Hide();
            btRequest.Hide();
        }

   

        private void btAdd_Click(object sender, EventArgs e)
        {
            UpdateProductForm addForm = new UpdateProductForm(pc);
            addForm.Show();
            addForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            UpdateList();
        }


        public void UpdateList()
        {
            lbProducts.DataSource = null;

            lbProducts.DataSource = pc.GetListOfProducts();
        }


        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lbProducts.SelectedItem;

            if (selectedProduct != null)
            {
                lblName.Text = selectedProduct.Name;
                lblType.Text = selectedProduct.Type;
                lblStock.Text = selectedProduct.Stock.ToString();
                lblDepartment.Text = selectedProduct.Department;
                lblPrice.Text = selectedProduct.Price.ToString();
                btUpdate.Show();
                btRemove.Show();
                btCrease.Show();
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this product ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                Product selectedProduct = (Product)lbProducts.SelectedItem;
                pc.DeleteProduct(selectedProduct);
                UpdateList();
            }
            else
            {
                UpdateList();
            }
            
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lbProducts.SelectedItem;

            UpdateProductForm addForm = new UpdateProductForm(pc, selectedProduct);
            addForm.Show();
            addForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);

        }

        private void btCrease_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lbProducts.SelectedItem;
            Increase creaseForm = new Increase(selectedProduct, pc);
           
            creaseForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            creaseForm.Show();
        }
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateList();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            
          lbProducts.DataSource = pc.FilterProducts(tbSearch.Text);
           
        }

    }
}
