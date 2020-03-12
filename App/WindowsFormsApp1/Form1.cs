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
    public partial class Form1 : Form
    {
        CalenderManager calenderManager = new CalenderManager();
        EmployeeController employeeController = new EmployeeController();

        public Form1()
        {
            InitializeComponent();
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcMain.SelectedTab == tabSchedule)
            {
                lsbScheduleEmployees.DataSource = employeeController.GetEmployees();

                ScheduleEnableButton();
                calenderManager.LoadShifts(mcdSchedule.ActiveMonth);
                LoadCalenderColors();
                ScheduleUnassignEnabble();
            }
        }

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

        #region functions
        private void LoadCalenderColors()
        {
            DateItem[] dateItems = calenderManager.SetDaysForMonth(mcdSchedule.ActiveMonth);
            foreach(DateItem dt in dateItems)
            {
                mcdSchedule.RemoveDateInfo(dt.Date);
                mcdSchedule.AddDateInfo(dt);
            }
        }

        private void LoadAssignedEmployees()
        {
            if(lblScheduleAssignedEmployee.Text != "Not Selected" && cmbScheduleAssignedShift.SelectedIndex >= 0)
            {
                SelectedDatesCollection sdc = mcdSchedule.SelectedDates;
                if(sdc.Count > 0)
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

    }
}
