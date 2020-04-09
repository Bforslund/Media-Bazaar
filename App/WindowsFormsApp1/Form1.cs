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
using System.Net.Mail;


namespace WindowsFormsApp1
{
    public partial class MediaBazaar : Form
    {
        ProductController pc;
        CalenderManager calenderManager;
        EmployeeController employeeController;
        Stats stats;
        User usr;

        public MediaBazaar()
        {
            InitializeComponent();

            //initialize the controller objects
            pc = new ProductController();
            calenderManager = new CalenderManager();
            employeeController = new EmployeeController();
            stats = new Stats();
            usr = new User();

            employeesListBox.DataSource = employeeController.GetEmployees();
            cbEmployees.DataSource = employeeController.GetEmployees();

            //Comment out this to disable the login
            tbcMain.TabPages.Remove(tabEmployees);
            tbcMain.TabPages.Remove(tabProducts);
            tbcMain.TabPages.Remove(tabSchedule);
            tbcMain.TabPages.Remove(tabStatistics);
            tbcMain.TabPages.Remove(tabLogout);

        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tbcMain.SelectedTab == tabLogout)
            {
                //Reset user permissions
                stats.userRole = 0;

                tbcMain.TabPages.Remove(tabEmployees);
                tbcMain.TabPages.Remove(tabProducts);
                tbcMain.TabPages.Remove(tabSchedule);
                tbcMain.TabPages.Remove(tabStatistics);
                tbcMain.TabPages.Remove(tabLogout);

                tbcMain.TabPages.Add(tabLogin);
            }

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
                    NoDatabaseConnection(ex);
                }

                LoadCalenderColors();
                ScheduleUnassignEnabble();
            }
            if (tbcMain.SelectedTab == tabProducts)
            {
                UpdateProductsList();
                btRemove.Hide();
                btUpdate.Hide();
                btCrease.Hide();
                btRequest.Hide();
            }
            if (tbcMain.SelectedTab == tabEmployees)
            {
                employeesListBox.DataSource = employeeController.GetEmployees();
            }
            if (tbcMain.SelectedTab == tabStatistics)
            {
                loadData();
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
            catch (MySqlException ex)
            {
                NoDatabaseConnection(ex);
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
            catch (MySqlException ex)
            {
                NoDatabaseConnection(ex);
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

        public void NoDatabaseConnection(MySqlException ex)
        {
            MessageBox.Show("No connection to Database\nAppliction will be closed\n" + ex.ToString());
            this.Close();
        }

        #region employee tab
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!IsNumeric(wageBox.Text))
            {
                MessageBox.Show("Fill in a correct wage amount!");
                return;
            }
            if (employeesListBox.SelectedItem != null) //! when an emloyee IS selected, change his data
            {
                saveEmployeeData(); //TODO add the shift preference
                refreshListView();
            }

            //TODO add try catch for empty fields and display error message
            //TODO display confirmation for creation or saving

            employeesListBox.DataSource = employeeController.GetEmployees();
        }

        private void deleteEmpButton_Click(object sender, EventArgs e)
        {
            employeeController.RemoveEmployee((Personal)employeesListBox.SelectedItem);
            
            employeesListBox.DataSource = employeeController.GetEmployees();

        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender; // TODO explain and understand
            string currentValue = (string)checkBox.Tag; // assign the value of the checkbox with the passed tag to the string currentValue
            //switch (checkBox.Checked) // TODO make sure this works
            //{
            //    case true:
            //        preferredShift += "," + currentValue;
            //        break;
            //    case false:
            //        preferredShift = preferredShift.Replace(currentValue, ""); // IF false, remove the string of that case with nothing
            //        break;
            //    default:
            //        break;
            //}
        }

        private void saveButton_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.saveButton, "Save changes");
        }

        #region function
        public void saveEmployeeData()
        {
            //convert form fields to data
            string email = emailBox.Text;
            string firstname = firstNameBox.Text;
            string lastname = lastNameBox.Text;
            int privilage = privilegeComboBox.SelectedIndex;
            string username = usernameBox.Text;
            string adress = addressBox.Text;
            DateTime birthDay = dtpEmployeeBirthday.Value;
            bool contract = Convert.ToBoolean(contractComboBox.SelectedIndex);
            int department = 0/*departmentComboBox.SelectedIndex*/;
            DateTime hiredate = dtpEmployeeHire.Value;
            string phoneNumber = phoneNoBox.Text;
            string password = passwordBox.Text;
            double wage = Convert.ToDouble(wageBox.Text);

            employeeController.saveEmployeeData(email, firstname, lastname, privilage, username, password, adress, birthDay, contract, department, hiredate, phoneNumber, wage);
            employeesListBox.DataSource = employeeController.GetEmployees();
        }

        private void refreshListView()
        {
            employeeController.GetEmployees();
        }
        #endregion

        #endregion

        #region stats tab


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            foreach (var item in stats.loadSchedule(theDate, 0))
            {
                lbNight.Items.Add(item);
            }
            lblmorshift.Text = theDate;
        }
        #region functions
        private void loadData()
        {
            try
            {
                foreach (Product item in stats.GetData())
                {
                    chartProd.Series["Stock"].Points.AddXY(item.Name, item.Stock);
                    chartProd.Series["Min_stock"].Points.AddXY(item.Name, item.Min_stock);

                    //Business logic for low_on_stock products
                    if (item.Stock < (item.Min_stock * 1.25))
                    {
                        lbLowProd.Items.Add(item.Name);
                    }
                }
            }
            catch (MySqlException ex)
            {
                NoDatabaseConnection(ex);
            }
        }
        #endregion

        #endregion


        private void btnLogin_Click(object sender, EventArgs e)
        {
            stats.login(txbLoginUsername.Text, txbLoginPassword.Text);

            //Administration has all tabs and the most privilages
            if (stats.userRole == 2)
            {
                tbcMain.TabPages.Remove(tabLogin);

                tbcMain.TabPages.Add(tabEmployees);
                tbcMain.TabPages.Add(tabProducts);
                tbcMain.TabPages.Add(tabSchedule);
                tbcMain.TabPages.Add(tabStatistics);
                tbcMain.TabPages.Add(tabLogout);
            }

            //Manager can view a few tabs but not edit them (So he cant mess anything up)
            else if (stats.userRole == 1)
            {
                tbcMain.TabPages.Remove(tabLogin);

                tbcMain.TabPages.Add(tabEmployees);
                tbcMain.TabPages.Add(tabSchedule);
                tbcMain.TabPages.Add(tabLogout);
            }

            //Employee has the least privilages can only acces products page
            else if (stats.userRole == 0)
            {
                tbcMain.TabPages.Remove(tabLogin);

                tbcMain.TabPages.Add(tabProducts);
                tbcMain.TabPages.Add(tabLogout);
            }
        }

        public static bool IsNumeric(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    MessageBox.Show("Enter a correct number");
                    return false;
                }
            }

            return true;
        }
        public static bool IsValid(string emailaddress)
        {
            try
            {

                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a valid email adress!");
                return false;
            }
        }

        private void dateTimePicker1_ValueChanged_2(object sender, EventArgs e)
        {
            lbMorning.Items.Clear();
            lbAfternoon.Items.Clear();
            lbNight.Items.Clear();

            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            foreach (var item in stats.loadSchedule(theDate, 0))
            {
                lbMorning.Items.Add(item);
            }
            foreach (var item in stats.loadSchedule(theDate, 1))
            {
                lbAfternoon.Items.Add(item);
            }
            foreach (var item in stats.loadSchedule(theDate, 2))
            {
                lbNight.Items.Add(item);
            }
            lblmorshift.Text = theDate;
        }

        private void cbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartAttendance.Series["Attendance"].Points.Clear();

            int absent = usr.checkAttendance(cbEmployees.SelectedValue.ToString(), 0);
            int present = usr.checkAttendance(cbEmployees.SelectedValue.ToString(), 1);

            chartAttendance.Series["Attendance"].Points.AddXY("Present", present);
            chartAttendance.Series["Attendance"].Points.AddXY("Absent", absent);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            employeesListBox.DataSource = employeeController.FilterEmployees(tbEmployeeSearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usernameBox.Text = RandomString(5);
            passwordBox.Text = RandomString(8);
        }

        public static string RandomString(int length)
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    }
}
