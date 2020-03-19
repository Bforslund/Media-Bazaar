using MySql.Data.MySqlClient;
using Pabo.Calendar;
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
        CalenderManager calenderManager;
        EmployeeController employeeController;

        public MediaBazaar()
        {
            InitializeComponent();

            //initialize the controller objects
            pc = new ProductController();
            calenderManager = new CalenderManager();
            employeeController = new EmployeeController();
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcMain.SelectedTab == tabSchedule)
            {
                lsbScheduleEmployees.DataSource = employeeController.GetEmployees();

                ScheduleEnableButton();

                try
                {
                    calenderManager.LoadShifts(mcdSchedule.ActiveMonth);
                }
                catch (MySqlException ex)
                {
                    NoDatabaseConnection();
                }

                LoadCalenderColors();
                ScheduleUnassignEnabble();
            }
            if(tbcMain.SelectedTab == tabProducts)
            {
                UpdateProductsList();
                btRemove.Hide();
                btUpdate.Hide();
                btCrease.Hide();
                btRequest.Hide();
            }
        }

        #region productsTab
        private void btAdd_Click(object sender, EventArgs e)
        {
            UpdateProductForm addForm = new UpdateProductForm(pc);
            addForm.Show();
            addForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            UpdateProductsList();
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
                UpdateProductsList();
            }
            else
            {
                UpdateProductsList();
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
            UpdateProductsList();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            lbProducts.DataSource = pc.FilterProducts(tbSearch.Text);
        }

        #region functions
        public void UpdateProductsList()
        {
            lbProducts.DataSource = null;

            try
            {
                lbProducts.DataSource = pc.GetListOfProducts();
            }
            catch(MySqlException ex)
            {
                NoDatabaseConnection();
            }
        }
        #endregion
        #endregion


        #region schedule tab
        private void mcdSchedule_DayClick(object sender, Pabo.Calendar.DayClickEventArgs e)
        {
            try
            {
                string selectedDate = mcdSchedule.SelectedDates[0].ToString("MMMM dd yyyy");
                lblScheduleDateAssign.Text = selectedDate;
                lblScheduleDateInfo.Text = selectedDate;
            }
            catch
            {
                lblScheduleDateAssign.Text = "Not Selected";
                lblScheduleDateInfo.Text = "Not Selected";
            }
            finally
            {
                ScheduleEnableButton();
                LoadAssignedEmployees();
                ScheduleUnassignEnabble();
            }
        }

        private void lsbScheduleEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblScheduleAssignedEmployee.Text = lsbScheduleEmployees.SelectedItem.ToString();

            ScheduleEnableButton();
        }

        private void cmbScheduleAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleEnableButton();
        }

        private void txbScheduleEmployeeSearch_TextChanged(object sender, EventArgs e)
        {
            lsbScheduleEmployees.DataSource = employeeController.FilterEmployees(txbScheduleEmployeeSearch.Text);
        }

        private void mcdSchedule_MonthChanged(object sender, Pabo.Calendar.MonthChangedEventArgs e)
        {
            LoadCalenderColors();
        }
        private void cmbScheduleAssignedShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAssignedEmployees();
        }
        private void btnScheduleAssign_Click(object sender, EventArgs e)
        {
            try
            {
                calenderManager.SetShift(mcdSchedule.SelectedDates[0], cmbScheduleAssign.SelectedIndex, ((Personal)lsbScheduleEmployees.SelectedItem).Id(), mcdSchedule.ActiveMonth);
            }
            catch(MySqlException ex)
            {
                NoDatabaseConnection();
            }
            LoadAssignedEmployees();
            LoadCalenderColors();
        }
        private void btnScheduleUnassign_Click(object sender, EventArgs e)
        {
            calenderManager.RemoveEmployee(mcdSchedule.SelectedDates[0], cmbScheduleAssignedShift.SelectedIndex, ((Personal)lsbAssignedEmployees.SelectedItem).Id(), mcdSchedule.ActiveMonth);
            LoadAssignedEmployees();
            LoadCalenderColors();
        }

        #region functions
        private void LoadCalenderColors()
        {
            DateItem[] dateItems = calenderManager.SetDaysForMonth(mcdSchedule.ActiveMonth);
            foreach (DateItem dt in dateItems)
            {
                mcdSchedule.RemoveDateInfo(dt.Date);
                mcdSchedule.AddDateInfo(dt);
            }
        }

        private void LoadAssignedEmployees()
        {
            if (cmbScheduleAssignedShift.SelectedIndex >= 0)
            {
                SelectedDatesCollection sdc = mcdSchedule.SelectedDates;
                if (sdc.Count > 0)
                {
                    lsbAssignedEmployees.DataSource = calenderManager.GetPersonalAssigned(sdc[0], cmbScheduleAssignedShift.SelectedIndex);

                }

                ScheduleUnassignEnabble();
            }
        }

        private void ScheduleEnableButton()
        {
            if (lblScheduleAssignedEmployee.Text != "Not Selected" && lblScheduleDateAssign.Text != "Not Selected" && cmbScheduleAssign.SelectedIndex >= 0)
            {
                btnScheduleAssign.Enabled = true;
            }
            else
            {
                btnScheduleAssign.Enabled = false;
            }
        }

        private void ScheduleUnassignEnabble()
        {
            if (lsbAssignedEmployees.Items.Count <= 0)
            {
                btnScheduleUnassign.Hide();
            }
            else
            {
                btnScheduleUnassign.Show();
            }
        }

        #endregion
        #endregion

        public void NoDatabaseConnection()
        {
            MessageBox.Show("No connection to Database\nAppliction will be closed");
            this.Close();
        }
    }
}
