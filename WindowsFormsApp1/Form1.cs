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
        string preferredShift; // used for the checkbox event
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);


            //All data will be fetched from the database instead of hardcoded, data filtering will be done through SQL queries
            List<Product> prodList = new List<Product>
            {
                new Product { Name= "Sony TV 4k", Price = 1420.20, Stock = 100, MinStock = 25},
                new Product { Name= "Lenovo Laptop", Price = 320.20, Stock = 14, MinStock = 40},
                new Product { Name= "iPhone 8", Price = 600.20, Stock = 30, MinStock = 10}
            };

            foreach (var prod in prodList)
            {
                StockChart.Series["Stock"].Points.AddXY(prod.Name, prod.Stock);
                StockChart.Series["Minimum"].Points.AddXY(prod.Name, prod.MinStock);

                //Warn of products low in stock < 25%
                if (prod.Stock < (prod.MinStock * 1.25))
                {
                    lbLow.Items.Add(prod.Name);
                }

            }


        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

            preferredShift = "";
            //
            this.morningChkBx.Tag = "Morning";
            this.morningChkBx.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            this.afternoonChkBx.Tag = "Afternoon";
            this.afternoonChkBx.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            this.nightChkBx.Tag = "Night";
            this.nightChkBx.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
           
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void deleteEmpButton_Click(object sender, EventArgs e)
        {

        }
        private void deleteEmpButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.deleteEmpButton, "Delete employee");
        }


        private void saveButton_Click(object sender, EventArgs e)
        {

        }
        private void saveButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.saveButton, "Save changes");
        }

    }
}
