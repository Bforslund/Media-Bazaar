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
        ProductController productcontroller;
        CalenderManager calenderManager;
        EmployeeController employeeController;
        Stats stats;
        User usr;
        DepartmentController departmentcontroller;

        public MediaBazaar()
        {
            InitializeComponent();

            //initialize the controller objects
            productcontroller = new ProductController();
            calenderManager = new CalenderManager();
            employeeController = new EmployeeController();
            departmentcontroller = new DepartmentController();
            stats = new Stats();
            usr = new User();

            lsbEmployees.DataSource = employeeController.GetEmployees();
            cmbStatEmployee.DataSource = employeeController.GetEmployees();

            //Comment out this to disable the login
            tbcMain.TabPages.Remove(tabEmployees);
            tbcMain.TabPages.Remove(tabProducts);
            tbcMain.TabPages.Remove(tabSchedule);
            tbcMain.TabPages.Remove(tabStatistics);
            tbcMain.TabPages.Remove(tabDepartments);
            tbcMain.TabPages.Remove(tabLogout);
            foreach (Personal p in employeeController.GetAllEmployees())
            {
                cbManager.Items.Add(p);
            }

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
                tbcMain.TabPages.Remove(tabDepartments);
                tbcMain.TabPages.Add(tabLogin);
            }

            if (tbcMain.SelectedTab == tabSchedule)
            {
                //sets current month and year in the calender
                mcdSchedule.ActiveMonth.Month = DateTime.Now.Month;
                mcdSchedule.ActiveMonth.Year = DateTime.Now.Year;

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
                btnProductRemove.Hide();
                btnProductUpdate.Hide();
                btnProductStockManage.Hide();
                btnProductstockRequest.Hide();
            }
            if (tbcMain.SelectedTab == tabEmployees)
            {
                lsbEmployees.DataSource = employeeController.GetEmployees();
            }
            if (tbcMain.SelectedTab == tabStatistics)
            {
                loadData();
            }
            if (tbcMain.SelectedTab == tabDepartments)
            {
                UpdateDepartmentList();
                btRemoveDepartment.Hide();
                btUpdateDepartment.Hide();
                
            }
        }

        #region productsTab
        private void btAdd_Click(object sender, EventArgs e)
        {
            UpdateProductForm addForm = new UpdateProductForm(productcontroller);
            addForm.Show();
            addForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            UpdateProductsList();
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lsbProducts.SelectedItem;

            if (selectedProduct != null)
            {
                lblProductName.Text = selectedProduct.Name;
                lblProductType.Text = selectedProduct.Type;
                lblProductStock.Text = selectedProduct.Stock.ToString();
                lblProductDepartment.Text = selectedProduct.Department.Name;
                lblProductPrice.Text = selectedProduct.Price.ToString();
                btnProductUpdate.Show();
                btnProductRemove.Show();
                btnProductStockManage.Show();
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
                Product selectedProduct = (Product)lsbProducts.SelectedItem;
                productcontroller.DeleteProduct(selectedProduct);
                UpdateProductsList();
            }
            else
            {
                UpdateProductsList();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lsbProducts.SelectedItem;

            UpdateProductForm addForm = new UpdateProductForm(productcontroller, selectedProduct);
            addForm.Show();
            addForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);

        }

        private void btCrease_Click(object sender, EventArgs e)
        {
            Product selectedProduct = (Product)lsbProducts.SelectedItem;
            Increase creaseForm = new Increase(selectedProduct, productcontroller);

            creaseForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            creaseForm.Show();
        }

        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateProductsList();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            lsbProducts.DataSource = productcontroller.FilterProducts(txbProductsSearch.Text);
        }

        #region functions
        public void UpdateProductsList()
        {
            lsbProducts.DataSource = null;

            try
            {
                lsbProducts.DataSource = productcontroller.GetAllProducts();
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
                calenderManager.SetShift(mcdSchedule.SelectedDates[0], cmbScheduleAssign.SelectedIndex, ((Personal)lsbScheduleEmployees.SelectedItem).Id, mcdSchedule.ActiveMonth);
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
            calenderManager.RemoveEmployee(mcdSchedule.SelectedDates[0], cmbScheduleAssignedShift.SelectedIndex, ((Personal)lsbAssignedEmployees.SelectedItem).Id, mcdSchedule.ActiveMonth);
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
            if (!IsNumeric(txbEmployeeWage.Text))
            {
                MessageBox.Show("Fill in a correct wage amount!");
                return;
            }
            if (lsbEmployees.SelectedItem != null) //! when an emloyee IS selected, change his data
            {
                saveEmployeeData(); //TODO add the shift preference
                refreshListView();
            }

            //TODO add try catch for empty fields and display error message
            //TODO display confirmation for creation or saving

            lsbEmployees.DataSource = employeeController.GetEmployees();
        }

        private void deleteEmpButton_Click(object sender, EventArgs e)
        {
            employeeController.RemoveEmployee((Personal)lsbEmployees.SelectedItem);
            
            lsbEmployees.DataSource = employeeController.GetEmployees();

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
            tt.SetToolTip(this.btnEmployeeSave, "Save changes");
        }

        #region function
        public void saveEmployeeData()
        {
            //convert form fields to data
            string email = txbEmployeeEmail.Text;
            string firstname = txbEmployeeFirstname.Text;
            string lastname = txbEmployeeLastname.Text;
            int privilage = cmbEmployeePrivilege.SelectedIndex;
            string username = txbEmployeeUsername.Text;
            string adress = txbEmployeeAdress.Text;
            DateTime birthDay = dtpEmployeeBirthday.Value;
            bool contract = Convert.ToBoolean(cmbEmployeeContract.SelectedIndex);
            int department = 0/*departmentComboBox.SelectedIndex*/;
            DateTime hiredate = dtpEmployeeHire.Value;
            string phoneNumber = phoneNoBox.Text;
            string password = txbEmployeePassword.Text;
            double wage = Convert.ToDouble(txbEmployeeWage.Text);

            employeeController.saveEmployeeData(email, firstname, lastname, privilage, username, password, adress, birthDay, contract, department, hiredate, phoneNumber, wage);
            lsbEmployees.DataSource = employeeController.GetEmployees();
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

        }
        #region functions
        private void loadData()
        {
            try
            {
                foreach (Product item in stats.GetData())
                {
                    crtStatProducts.Series["Stock"].Points.AddXY(item.Name, item.Stock);
                    crtStatProducts.Series["Min_stock"].Points.AddXY(item.Name, item.Min_stock);


                }
                foreach (Product item in stats.GetDepartmentData())
                {
                    
                    chartDepartSales.Series["Amount"].Points.AddXY(item.Name, item.Stock);

                }
            }
            catch (MySqlException ex)
            {
                NoDatabaseConnection(ex);
            }


            List<StoreStats> monthList = new List<StoreStats>();



            for (int begin = 1, end = 2; begin <= 12; begin++, end++)
            {
                monthList.Add(stats.loadEmployeeCostStats("2020-" + begin + "-01", "2020-" + end + "-01"));
            }
            foreach (StoreStats item in monthList)
            {
                chartProfit.Series["Salary costs"].Points.AddXY(item.Month, item.EmployeeCosts);
                chartProfit.Series["Sales income"].Points.AddXY(item.Month, item.SalesIn);
                chartProfit.Series["Order costs"].Points.AddXY(item.Month, item.ProdCosts);
                chartProfit.Series["Profit"].Points.AddXY(item.Month, item.EmployeeCosts + item.ProdCosts - item.SalesIn);

            }
            decimal totalOut = monthList.Sum(item => item.EmployeeCosts);



        }

        private void reloadChart()
        {
            string test = Convert.ToString(dtpStatDate.Value);
            int month = Convert.ToInt32(test.Substring(0, 1));
            int lastMonth = month + 1;

            List<StoreStats> monthList = new List<StoreStats>();
            monthList.Add(stats.loadEmployeeCostStats("2020-" + month + "-01", "2020-" + lastMonth + "-01"));
            foreach (StoreStats item in monthList)
            {
                chartProfit.Series["Salary costs"].Points.AddXY(item.Month, item.EmployeeCosts);
                chartProfit.Series["Salary costs"].Points.AddXY(item.Month, item.EmployeeCosts);
                chartProfit.Series["Sales income"].Points.AddXY(item.Month, item.SalesIn);
                chartProfit.Series["Order costs"].Points.AddXY(item.Month, item.ProdCosts);
                chartProfit.Series["Profit"].Points.AddXY(item.Month, item.EmployeeCosts + item.ProdCosts - item.SalesIn);

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

                tbcMain.TabPages.Add(tabDepartments);
                tbcMain.TabPages.Add(tabEmployees);
                tbcMain.TabPages.Add(tabProducts);
                tbcMain.TabPages.Add(tabSchedule);
                tbcMain.TabPages.Add(tabStatistics);
                tbcMain.TabPages.Add(tabLogout);
            }

            //Manager can view a few tabs but not edit them (So he cant mess anything up)
            // Mail from Andre "The manager of the shop will only see the statistics. The actual management of the business process is delegated to the administration. "
            else if (stats.userRole == 3)
            {
                tbcMain.TabPages.Remove(tabLogin);
                tbcMain.TabPages.Add(tabStatistics);
                //tbcMain.TabPages.Add(tabEmployees);
                //tbcMain.TabPages.Add(tabSchedule);
                tbcMain.TabPages.Add(tabLogout);
            }

            //Employee has the least privilages can only acces products page
            else if (stats.userRole == 1)
            {
                tbcMain.TabPages.Remove(tabLogin);
                // tabPage request restock tab
               // tbcMain.TabPages.Add(tabProducts); 
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
            foreach (var series in chartProfit.Series)
            {
                series.Points.Clear();
            }

            reloadChart();
        }

        private void cbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            crtStatAttendence.Series["Attendance"].Points.Clear();

            int absent = usr.checkAttendance(cmbStatEmployee.SelectedValue.ToString(), 0);
            int present = usr.checkAttendance(cmbStatEmployee.SelectedValue.ToString(), 1);

            crtStatAttendence.Series["Attendance"].Points.AddXY("Present", present);
            crtStatAttendence.Series["Attendance"].Points.AddXY("Absent", absent);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lsbEmployees.DataSource = employeeController.FilterEmployees(txbEmployeeSearch.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txbEmployeeUsername.Text = RandomString(5);
            txbEmployeePassword.Text = RandomString(8);
        }

        public static string RandomString(int length)
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        #region departmentsTab
        private void btAddDepartment_Click(object sender, EventArgs e)
        {
            bool success;
            success = AddDepartments();
            if (success)
            {
                MessageBox.Show("Department successfully added!");
                tbDepartmentName.Clear();
                UpdateDepartmentList();
            }
            else
            {
                MessageBox.Show("Try again!");
            }
        }
        private bool AddDepartments()
        {
            bool success;
            try
            {
            
                string name = tbDepartmentName.Text;
                Personal manager = (Personal)cbManager.SelectedItem;
                int min = Convert.ToInt32(tbMin.Text);
                int max = Convert.ToInt32(tbMax.Text);
              
                Department newDepartment = new Department(name, manager.Id, min, max);
                departmentcontroller.AddDepartment(newDepartment);
                success = true;
            }
            catch
            {
                success = false;
            }
            return success;

        }
        private void btUpdateDepartment_Click(object sender, EventArgs e)
        {
            Department selectedDepartment = (Department)lbDepartments.SelectedItem;

            bool success;
            success = UpdateDepartments();
            if (success)
            {
                MessageBox.Show("Department successfully Updated!");
                UpdateDepartmentList();
                tbDepartmentName.Clear();
            }
            else
            {
                MessageBox.Show("Try again!");
            }
        }
        private bool UpdateDepartments()
        {
            bool success;
            Department selectedDepartment = (Department)lbDepartments.SelectedItem;
            try
            {
             
                selectedDepartment.Name = tbDepartmentName.Text;
                selectedDepartment.Manager_id = ((Personal)cbManager.SelectedItem).Id;
                selectedDepartment.Min_employees = Convert.ToInt32(tbMin.Text);
                selectedDepartment.Max_employees = Convert.ToInt32(tbMax.Text);
                departmentcontroller.UpdateDepartment(selectedDepartment);
                success = true;
            }
            catch
            {
                
                success = false;
            }
            return success;
        }

        private void btRemoveDepartment_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this department ??",
                                                "Confirm Delete!!",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                Department selectedDepartment = (Department)lbDepartments.SelectedItem;
                departmentcontroller.DeleteDepartment(selectedDepartment);
                UpdateDepartmentList();
            }
            else
            {
                UpdateDepartmentList();
            }
        }
        private void lbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department selectedDepartment = (Department)lbDepartments.SelectedItem;

            if (selectedDepartment != null)
            {
                tbDepartmentName.Text = selectedDepartment.Name;
                cbManager.SelectedItem = employeeController.GetEmployee(selectedDepartment.Manager_id);
                tbMax.Text = selectedDepartment.Max_employees.ToString();
                tbMin.Text = selectedDepartment.Min_employees.ToString();
               
                btUpdateDepartment.Show();
                btRemoveDepartment.Show();
            }
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            lbDepartments.DataSource = departmentcontroller.FilterDepartments(textBox1.Text);
        }
        public void UpdateDepartmentList()
        {
            lbDepartments.DataSource = null;

            try
            {
                lbDepartments.DataSource = departmentcontroller.GetDepartments();
            }
            catch (MySqlException ex)
            {
                NoDatabaseConnection(ex);
            }
         
        }

        #endregion


    }
}
