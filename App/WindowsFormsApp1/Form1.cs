﻿using MySql.Data.MySqlClient;
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
using System.Globalization;

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
        RestockItem restockItem;

        public MediaBazaar()
        {
            InitializeComponent();

            //initialize the controller objects
            productcontroller = new ProductController();
            calenderManager = new CalenderManager();
            employeeController = new EmployeeController();
            departmentcontroller = new DepartmentController();
            restockItem = new RestockItem();
            stats = new Stats();
            usr = new User();

            LoadAtStart();

        }

        private void LoadAtStart() // Everything that needs to be filled at start!
        {
            // lsbEmployees.DataSource = employeeController.GetEmployees();
            cmbStatEmployee.DataSource = employeeController.GetEmployees();

            //Comment out this to disable the login
            tbcMain.TabPages.Remove(tabEmployees);
            tbcMain.TabPages.Remove(tabProducts);
            tbcMain.TabPages.Remove(tabProductRestock);
            tbcMain.TabPages.Remove(tabSchedule);
            tbcMain.TabPages.Remove(tabStatistics);
            tbcMain.TabPages.Remove(tabDepartments);
            tbcMain.TabPages.Remove(tabLogout);
            foreach (Personal p in employeeController.GetAllEmployees())
            {
                cbManager.Items.Add(p);
            }

            foreach (Department d in departmentcontroller.GetDepartments())
            {
                cmbEmployeeDepartment.Items.Add(d);
            }

            updateEmployeeList();
            updateListOutstandingRequests();
            updateListCompletedRequests();
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tbcMain.SelectedTab == tabLogout)
            {
                //Reset user permissions
                stats.userRole = 0;

                tbcMain.TabPages.Remove(tabEmployees);
                tbcMain.TabPages.Remove(tabProducts);
                tbcMain.TabPages.Remove(tabProductRestock);
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

                txbTempYear.Text = DateTime.Now.Year.ToString();
                txbTempWeek.Text = (DateTime.Now.DayOfYear / 7).ToString();

                lsbScheduleEmployees.DataSource = employeeController.GetEmployees();

                LoadSchedule();
            }
            if (tbcMain.SelectedTab == tabProducts)
            {
                UpdateProductsList();
                btnProductRemove.Hide();
                btnProductUpdate.Hide();

                btnProductstockRequest.Hide();
            }
            if (tbcMain.SelectedTab == tabEmployees)
            {
                btUpdateEmployee.Hide();
                btRemoveEmployee.Hide();

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
            UpdateProductForm addForm = new UpdateProductForm(productcontroller, departmentcontroller);
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
                lblProductBuyPrice.Text = selectedProduct.Buyingprice.ToString();
                lblSellPrice.Text = selectedProduct.Sellingprice.ToString();
                if (selectedProduct.Stock < 10)
                {
                    lblProductStock.BackColor = Color.Red;
                }
                else
                {
                    lblProductStock.BackColor = Color.Transparent;
                }
                btnProductUpdate.Show();
                btnProductRemove.Show();
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

            UpdateProductForm addForm = new UpdateProductForm(productcontroller, departmentcontroller, selectedProduct);
            addForm.Show();
            addForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);

        }

        //private void btCrease_Click(object sender, EventArgs e)
        //{
        //    Product selectedProduct = (Product)lsbProducts.SelectedItem;
        //    Increase creaseForm = new Increase(selectedProduct, productcontroller);

        //    creaseForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
        //    creaseForm.Show();
        //}

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
            LoadSchedule();
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
        private void btClear_Click(object sender, EventArgs e)
        {

            txbEmployeeEmail.Clear();
            txbEmployeeFirstname.Clear();
            txbEmployeeLastname.Clear();
            cmbEmployeePrivilege.SelectedIndex = 0;
            txbEmployeeAdress.Clear();
            dtpEmployeeBirthday.Value = DateTime.Now;
            cmbEmployeeContract.SelectedIndex = 0;
            cmbEmployeeDepartment.SelectedItem = -1;
            txbEmployeeAllergies.Clear();
            dtpEmployeeHire.Value = DateTime.Now;
            phoneNoBox.Clear();
            txbEmployeeWage.Clear();

        }
        private void btAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txbEmployeeEmail.Text;
                string firstname = txbEmployeeFirstname.Text;
                string lastname = txbEmployeeLastname.Text;
                int privilage = cmbEmployeePrivilege.SelectedIndex;
                string username = txbEmployeeUsername.Text;
                string adress = txbEmployeeAdress.Text;
                DateTime birthDay = dtpEmployeeBirthday.Value;
                string allergies = txbEmployeeAllergies.Text;
                int contract = (int)cmbEmployeeContract.SelectedIndex;
                Department department = cmbEmployeeDepartment.SelectedItem as Department;
                DateTime hiredate = dtpEmployeeHire.Value;
                string phoneNumber = phoneNoBox.Text;
                string password = txbEmployeePassword.Text;
                double wage = Convert.ToDouble(txbEmployeeWage.Text);

                Employee newEmployee = new Employee(email, firstname, lastname, privilage, username, password, adress, birthDay, allergies, contract, department, hiredate, phoneNumber, wage);
                employeeController.saveEmployeeData(newEmployee);
                MessageBox.Show("Employee added");

            }
            catch (Exception)
            {

                MessageBox.Show("Did you fill in everything correct? Check again");
            }
            updateEmployeeList();
        }

        private void btUpdateEmployee_Click(object sender, EventArgs e)
        {
            Employee SelectedEmployee = (Employee)lsbEmployees.SelectedItem;
            try
            {
                if (SelectedEmployee != null)
                {
                    SelectedEmployee.Email = txbEmployeeEmail.Text;
                    SelectedEmployee.FirstName = txbEmployeeFirstname.Text;
                    SelectedEmployee.LastName = txbEmployeeLastname.Text;
                    SelectedEmployee.Privilage = cmbEmployeePrivilege.SelectedIndex;
                    SelectedEmployee.Adress = txbEmployeeAdress.Text;
                    SelectedEmployee.Birthday = dtpEmployeeBirthday.Value;
                    SelectedEmployee.Allergies = txbEmployeeAllergies.Text;
                    SelectedEmployee.Contract = (int)cmbEmployeeContract.SelectedIndex;
                    SelectedEmployee.Department = cmbEmployeeDepartment.SelectedItem as Department;
                    SelectedEmployee.Hiredate = dtpEmployeeHire.Value;
                    SelectedEmployee.PhoneNumber = phoneNoBox.Text;
                    SelectedEmployee.Wage = Convert.ToDouble(txbEmployeeWage.Text);
                    employeeController.UpdateEmployee(SelectedEmployee);
                    MessageBox.Show("Employee updated");
                }
                updateEmployeeList();
            }
            catch (Exception)
            {

                MessageBox.Show("Did you fill in everything correct? Check again");
            }
        }

        private void btRemoveEmployee_Click(object sender, EventArgs e)
        {
            Employee SelectedEmployee = (Employee)lsbEmployees.SelectedItem;
            if (SelectedEmployee != null)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this employee ??",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // If 'Yes', do something here.
                    employeeController.RemoveEmployee(SelectedEmployee);


                    updateEmployeeList();
                }
                else
                {
                    updateEmployeeList();
                }
            }
        }
        public void updateEmployeeList()
        {
            lsbEmployees.DataSource = null;


            lsbEmployees.DataSource = employeeController.GetEmployees();



        }
        private void lsbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            btUpdateEmployee.Show();
            btRemoveEmployee.Show();

            Employee selectedEmployee = lsbEmployees.SelectedItem as Employee;
            try
            {
                if (selectedEmployee != null)
                {
                    txbEmployeeFirstname.Text = selectedEmployee.FirstName;
                    txbEmployeeLastname.Text = selectedEmployee.LastName;
                    dtpEmployeeBirthday.Value = selectedEmployee.Birthday;
                    txbEmployeeAdress.Text = selectedEmployee.Adress;
                    txbEmployeeEmail.Text = selectedEmployee.Email;
                    phoneNoBox.Text = selectedEmployee.PhoneNumber.ToString();
                    dtpEmployeeHire.Value = selectedEmployee.Hiredate;
                    cmbEmployeeContract.SelectedIndex = selectedEmployee.Contract;
                    foreach (Department department in cmbEmployeeDepartment.Items)
                    {
                        if (department.Id == selectedEmployee.Department.Id)
                        {
                            cmbEmployeeDepartment.SelectedItem = department;
                        }
                    }
                    txbEmployeeAllergies.Text = selectedEmployee.Allergies;
                    cmbEmployeePrivilege.SelectedIndex = selectedEmployee.Privilage;
                    txbEmployeeWage.Text = selectedEmployee.Wage.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong, try again");
            }

        }

        private void refreshListView()
        {
            employeeController.GetEmployees();
        }

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
                chartProfit.Series["Profit"].Points.AddXY(item.Month, item.SalesIn - (item.EmployeeCosts + item.ProdCosts));

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
                chartProfit.Series["Profit"].Points.AddXY(item.Month, item.SalesIn - (item.EmployeeCosts + item.ProdCosts));

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
                tbcMain.TabPages.Add(tabProductRestock);
                tbcMain.TabPages.Add(tabSchedule);
                tbcMain.TabPages.Add(tabStatistics);
                tbcMain.TabPages.Add(tabLogout);
            }

            //Manager can view a few tabs but not edit them (So he cant mess anything up)
            // Mail from Andre "The manager of the shop will only see the statistics. The actual management of the business process is delegated to the administration. "
            else if (stats.userRole == 3)
            {
                //tbcMain.TabPages.Add(tabStatistics);
                //tbcMain.TabPages.Add(tabEmployees);
                //tbcMain.TabPages.Add(tabSchedule);
                //tbcMain.TabPages.Add(tabLogout);
            }

            //Employee has the least privilages can only acces products page
            else if (stats.userRole == 1)
            {
                tbcMain.TabPages.Remove(tabLogin);
                tbcMain.TabPages.Add(tabProductRestock);
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

        private void btnRestockManage_Click(object sender, EventArgs e)
        {
            try
            {
                RestockItem selectedRestockItem = lsbRequestsOutstanding.SelectedItem as RestockItem;

                // Increase increaseForm = new Increase(selectedProduct, productcontroller);

                //increaseForm.FormClosing += new FormClosingEventHandler(ChildFormClosing);
                //increaseForm.Show();
                //selectedProduct. Convert(ToInt32(txtBoxRestock.Text));
                int amount = Convert.ToInt32(txtBoxRestock.Text);
                selectedRestockItem.IncreaseRestockItem(selectedRestockItem, amount);

                updateListOutstandingRequests();
                updateListCompletedRequests();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("format"))
                {
                    MessageBox.Show("Increase/Decrease with a valid numerical value");
                }
                MessageBox.Show("Select a product to initiate the restock");
            }
        }

        private void btnRejectRestock_Click(object sender, EventArgs e)
        {
            //todo not finished

            RestockItem restockItemToReject = lsbRequestsOutstanding.SelectedItem as RestockItem;


            //TODO rejected "tag", add date of rejection, error handling
            try
            {
                restockItemToReject.RejectRequest(restockItemToReject, 0, rejectMessage.Text);
                updateListOutstandingRequests();
                updateListCompletedRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong, use numbers and add a message!");
            }

            // lbCompletedRequests.Items.Add(rejectedProduct);

            //?List view version
            // lvCompletedRequests.Columns.Add("Status", 20, HorizontalAlignment.Left); 

            //ListViewItem item = new ListViewItem();

            //item.Text = rejectedProduct.ToString(); // Or whatever display text you need
            //item.Tag = rejectedProduct;

            // Setup other things like SubItems, Font, ...

            //lvCompletedRequests.Items.Add(item);


        }

        #region restockMethods

        public void updateListOutstandingRequests()
        {
            //TODO check
            lsbRequestsOutstanding.Items.Clear();
            if (restockItem.GetOutstandingData().Count > 0)
            {
                foreach (RestockItem item in restockItem.GetOutstandingData())
                {
                    lsbRequestsOutstanding.Items.Add(item);
                }
            }

        }
        public void updateListCompletedRequests()
        {
            //TODO check

            lbCompletedRequests.Items.Clear();

            foreach (RestockItem item in restockItem.GetCompeletedData())
            {
                lbCompletedRequests.Items.Add(item);
            }
        }
        #endregion

        private void btnProductstockRequest_Click(object sender, EventArgs e)
        {
            if (lsbProducts.SelectedIndex >= 0)
            {
                Product restockRequestProduct = (Product)lsbProducts.SelectedItem;
                //TODO get the name or username of the user initiating the request
                restockItem.RequestRestockOfitem(restockRequestProduct, DateTime.Now);
                updateListOutstandingRequests(); // update the list
                MessageBox.Show("Product restock request successfull");
            }
            else
            {
                MessageBox.Show("No product selected");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var series in chartProfit.Series)
            {
                series.Points.Clear();
            }

            //crtStatProducts.
            //chartDepartSales
            foreach (var item in crtStatProducts.Series)
            {
                item.Points.Clear();
            }

            foreach (var item in chartDepartSales.Series)
            {
                item.Points.Clear();
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
                chartProfit.Series["Profit"].Points.AddXY(item.Month, item.SalesIn - (item.EmployeeCosts + item.ProdCosts));

            }
            decimal totalOut = monthList.Sum(item => item.EmployeeCosts);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dtpStatDate_ValueChanged(object sender, EventArgs e)
        {
            foreach (var series in chartProfit.Series)
            {
                series.Points.Clear();
            }

            reloadChart();
        }

        private void cmbStatEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            crtStatAttendence.Series["Attendance"].Points.Clear();

            Employee emp = cmbStatEmployee.SelectedItem as Employee;

            int absent = usr.checkAttendance(cmbStatEmployee.SelectedItem.ToString(), 0);
            int present = usr.checkAttendance(cmbStatEmployee.SelectedItem.ToString(), 1);

            crtStatAttendence.Series["Attendance"].Points.AddXY("Present", present);
            crtStatAttendence.Series["Attendance"].Points.AddXY("Absent", absent);
        }

        private void btnFillWeek_Click(object sender, EventArgs e)
        {
            int year = 2020;
            int week = 1;
            try
            {
                year = Convert.ToInt32(txbTempYear.Text);
                week = Convert.ToInt32(txbTempWeek.Text);
            }
            catch
            {
                MessageBox.Show("Non valid values entered defaults will be used");
            }

            MessageBox.Show($"Selected Year: {year}, Week: {week}");

            //lblScheduleStatus.Text = "Scheduling";
            AutoSchedule autoSchedule = new AutoSchedule();


            try
            {
                List<List<List<Personal>>> scheduled = autoSchedule.AutoScheduleEmployees(week, year);

                //List<ListBox> lists = new List<ListBox>() { lsbMonday, lsbThuesday, lsbWednesday, lsbThursday, lsbFriday, lsbSaturday, lblScheduleStatus };

                //loop days
                //for(int i = 0; i < scheduled.Count(); i++)
                //{
                //    lists[i].Items.Clear();
                //    //loop shifts
                //    for (int j = 0; j < scheduled[i].Count(); j++)
                //    {
                //        foreach(Personal personal in scheduled[i][j])
                //        {
                //            lists[i].Items.Add($"shift: {j} Person: {personal.ToString()}");
                //        }
                //    }
                //}
            }
            catch (MySqlException ex)
            {
                NoDatabaseConnection(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //lblScheduleStatus.Text = "Finished";

            LoadSchedule();
        }

        public void LoadSchedule()
        {
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
    }
}
