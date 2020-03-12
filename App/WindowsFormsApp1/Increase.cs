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
        public Increase(Product p)
        {
            InitializeComponent();
            this.p = p;
            lblSelected.Text = $"{p.Type}, {p.Name}, {p.Price} {p.Stock} {p.Department}";
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}
