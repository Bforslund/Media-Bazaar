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
    public partial class Increase : Form
    {
        Product p;
        ProductController pc;
        public Increase(Product p, ProductController pc)
        {
            InitializeComponent();
            this.p = p;
            this.pc = pc;
            lblSelected.Text = $"{p.Type}, {p.Name} with current stock: {p.Stock}";
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                bool value = false;
                int howMuch = Convert.ToInt32(nUDStock.Value);
                if (rbDecrease.Checked)
                {
                    value = pc.DecreaseStock(p, howMuch);
                }
                else if (rbIncrease.Checked)
                {
                    value = pc.IncreaseStock(p, howMuch);
                }
                else
                {
                    MessageBox.Show("Please select whether to increase or decrease");
                }
                if (value == false)
                {
                    MessageBox.Show("Please enter a vailed number!");
                }
                else
                {
                    MessageBox.Show($"Success! You have now updated {p}'s stock!");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        
            
        }

      
    }
}
