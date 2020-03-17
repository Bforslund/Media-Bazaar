namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.mcdSchedule = new Pabo.Calendar.MonthCalendar();
            this.label19 = new System.Windows.Forms.Label();
            this.txbScheduleEmployeeSearch = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnScheduleUnassign = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblScheduleDateInfo = new System.Windows.Forms.Label();
            this.cmbScheduleAssignedShift = new System.Windows.Forms.ComboBox();
            this.lsbAssignedEmployees = new System.Windows.Forms.ListBox();
            this.lsbScheduleEmployees = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnScheduleAssign = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblScheduleAssignedEmployee = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblScheduleDateAssign = new System.Windows.Forms.Label();
            this.cmbScheduleAssign = new System.Windows.Forms.ComboBox();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.tbcMain.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabEmployees);
            this.tbcMain.Controls.Add(this.tabProducts);
            this.tbcMain.Controls.Add(this.tabSchedule);
            this.tbcMain.Controls.Add(this.tabStatistics);
            this.tbcMain.Location = new System.Drawing.Point(12, 12);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(845, 503);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tabEmployees
            // 
            this.tabEmployees.Location = new System.Drawing.Point(4, 25);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(837, 474);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Employees";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.Color.Salmon;
            this.tabProducts.Controls.Add(this.button6);
            this.tabProducts.Controls.Add(this.textBox7);
            this.tabProducts.Controls.Add(this.textBox5);
            this.tabProducts.Controls.Add(this.textBox4);
            this.tabProducts.Controls.Add(this.textBox3);
            this.tabProducts.Controls.Add(this.textBox2);
            this.tabProducts.Controls.Add(this.textBox1);
            this.tabProducts.Controls.Add(this.label7);
            this.tabProducts.Controls.Add(this.label6);
            this.tabProducts.Controls.Add(this.label4);
            this.tabProducts.Controls.Add(this.label3);
            this.tabProducts.Controls.Add(this.label2);
            this.tabProducts.Controls.Add(this.label1);
            this.tabProducts.Controls.Add(this.button5);
            this.tabProducts.Controls.Add(this.button4);
            this.tabProducts.Controls.Add(this.button3);
            this.tabProducts.Controls.Add(this.button2);
            this.tabProducts.Controls.Add(this.button1);
            this.tabProducts.Controls.Add(this.listBox1);
            this.tabProducts.Location = new System.Drawing.Point(4, 25);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(837, 474);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Text = "Products";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(498, 353);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(125, 33);
            this.button6.TabIndex = 20;
            this.button6.Text = "Requst restock";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(457, 195);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 19;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(457, 167);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 17;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(457, 139);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(457, 111);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(457, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(457, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Department:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Currently in stock;";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(394, 313);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 34);
            this.button5.TabIndex = 5;
            this.button5.Text = "Decrease";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(414, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 35);
            this.button4.TabIndex = 4;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(498, 272);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(498, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Increase";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(6, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 452);
            this.listBox1.TabIndex = 0;
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.mcdSchedule);
            this.tabSchedule.Controls.Add(this.label19);
            this.tabSchedule.Controls.Add(this.txbScheduleEmployeeSearch);
            this.tabSchedule.Controls.Add(this.groupBox2);
            this.tabSchedule.Controls.Add(this.lsbScheduleEmployees);
            this.tabSchedule.Controls.Add(this.groupBox1);
            this.tabSchedule.Location = new System.Drawing.Point(4, 25);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(837, 474);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Schedule";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // mcdSchedule
            // 
            this.mcdSchedule.ActiveMonth.Month = 3;
            this.mcdSchedule.ActiveMonth.Year = 2020;
            this.mcdSchedule.Culture = new System.Globalization.CultureInfo("en");
            this.mcdSchedule.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mcdSchedule.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mcdSchedule.Header.TextColor = System.Drawing.Color.White;
            this.mcdSchedule.ImageList = null;
            this.mcdSchedule.Location = new System.Drawing.Point(3, 16);
            this.mcdSchedule.MaxDate = new System.DateTime(2030, 3, 11, 10, 12, 7, 673);
            this.mcdSchedule.MinDate = new System.DateTime(2010, 3, 11, 10, 12, 7, 673);
            this.mcdSchedule.Month.BackgroundImage = null;
            this.mcdSchedule.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mcdSchedule.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mcdSchedule.Name = "mcdSchedule";
            this.mcdSchedule.SelectionMode = Pabo.Calendar.mcSelectionMode.One;
            this.mcdSchedule.SelectTrailingDates = false;
            this.mcdSchedule.ShowTrailingDates = false;
            this.mcdSchedule.Size = new System.Drawing.Size(251, 200);
            this.mcdSchedule.TabIndex = 15;
            this.mcdSchedule.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.mcdSchedule.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mcdSchedule.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler(this.mcdSchedule_MonthChanged);
            this.mcdSchedule.DayClick += new Pabo.Calendar.DayClickEventHandler(this.mcdSchedule_DayClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(570, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 17);
            this.label19.TabIndex = 14;
            this.label19.Text = "Search:";
            // 
            // txbScheduleEmployeeSearch
            // 
            this.txbScheduleEmployeeSearch.Location = new System.Drawing.Point(629, 11);
            this.txbScheduleEmployeeSearch.Name = "txbScheduleEmployeeSearch";
            this.txbScheduleEmployeeSearch.Size = new System.Drawing.Size(195, 22);
            this.txbScheduleEmployeeSearch.TabIndex = 13;
            this.txbScheduleEmployeeSearch.TextChanged += new System.EventHandler(this.txbScheduleEmployeeSearch_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnScheduleUnassign);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblScheduleDateInfo);
            this.groupBox2.Controls.Add(this.cmbScheduleAssignedShift);
            this.groupBox2.Controls.Add(this.lsbAssignedEmployees);
            this.groupBox2.Location = new System.Drawing.Point(9, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 233);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information for selected date";
            // 
            // btnScheduleUnassign
            // 
            this.btnScheduleUnassign.Location = new System.Drawing.Point(327, 204);
            this.btnScheduleUnassign.Name = "btnScheduleUnassign";
            this.btnScheduleUnassign.Size = new System.Drawing.Size(222, 23);
            this.btnScheduleUnassign.TabIndex = 16;
            this.btnScheduleUnassign.Text = "Unassign Employee";
            this.btnScheduleUnassign.UseVisualStyleBackColor = true;
            this.btnScheduleUnassign.Click += new System.EventHandler(this.btnScheduleUnassign_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(197, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "Max num employees assigned";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Min num employees assigned";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(267, 133);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 17);
            this.label18.TabIndex = 15;
            this.label18.Text = "03";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 133);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(258, 17);
            this.label17.TabIndex = 14;
            this.label17.Text = "Number of employees for selected shift:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 17);
            this.label16.TabIndex = 10;
            this.label16.Text = "Selected Shift:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(222, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Number of employees for the day:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(267, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 17);
            this.label15.TabIndex = 13;
            this.label15.Text = "09";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Selected date:";
            // 
            // lblScheduleDateInfo
            // 
            this.lblScheduleDateInfo.AutoSize = true;
            this.lblScheduleDateInfo.Location = new System.Drawing.Point(111, 50);
            this.lblScheduleDateInfo.Name = "lblScheduleDateInfo";
            this.lblScheduleDateInfo.Size = new System.Drawing.Size(89, 17);
            this.lblScheduleDateInfo.TabIndex = 11;
            this.lblScheduleDateInfo.Text = "Not Selected";
            // 
            // cmbScheduleAssignedShift
            // 
            this.cmbScheduleAssignedShift.FormattingEnabled = true;
            this.cmbScheduleAssignedShift.Items.AddRange(new object[] {
            "Morning",
            "Evening",
            "Night"});
            this.cmbScheduleAssignedShift.Location = new System.Drawing.Point(114, 70);
            this.cmbScheduleAssignedShift.Name = "cmbScheduleAssignedShift";
            this.cmbScheduleAssignedShift.Size = new System.Drawing.Size(145, 24);
            this.cmbScheduleAssignedShift.TabIndex = 10;
            this.cmbScheduleAssignedShift.SelectedIndexChanged += new System.EventHandler(this.cmbScheduleAssignedShift_SelectedIndexChanged);
            // 
            // lsbAssignedEmployees
            // 
            this.lsbAssignedEmployees.FormattingEnabled = true;
            this.lsbAssignedEmployees.ItemHeight = 16;
            this.lsbAssignedEmployees.Location = new System.Drawing.Point(327, 21);
            this.lsbAssignedEmployees.Name = "lsbAssignedEmployees";
            this.lsbAssignedEmployees.Size = new System.Drawing.Size(222, 180);
            this.lsbAssignedEmployees.TabIndex = 0;
            // 
            // lsbScheduleEmployees
            // 
            this.lsbScheduleEmployees.FormattingEnabled = true;
            this.lsbScheduleEmployees.ItemHeight = 16;
            this.lsbScheduleEmployees.Location = new System.Drawing.Point(570, 35);
            this.lsbScheduleEmployees.Name = "lsbScheduleEmployees";
            this.lsbScheduleEmployees.Size = new System.Drawing.Size(252, 436);
            this.lsbScheduleEmployees.TabIndex = 11;
            this.lsbScheduleEmployees.SelectedIndexChanged += new System.EventHandler(this.lsbScheduleEmployees_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnScheduleAssign);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblScheduleAssignedEmployee);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblScheduleDateAssign);
            this.groupBox1.Controls.Add(this.cmbScheduleAssign);
            this.groupBox1.Location = new System.Drawing.Point(260, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 207);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Assigning Schedule";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Selected date:";
            // 
            // btnScheduleAssign
            // 
            this.btnScheduleAssign.Location = new System.Drawing.Point(11, 128);
            this.btnScheduleAssign.Name = "btnScheduleAssign";
            this.btnScheduleAssign.Size = new System.Drawing.Size(284, 23);
            this.btnScheduleAssign.TabIndex = 9;
            this.btnScheduleAssign.Text = "Assign employee to shift";
            this.btnScheduleAssign.UseVisualStyleBackColor = true;
            this.btnScheduleAssign.Click += new System.EventHandler(this.btnScheduleAssign_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Selected Employee:";
            // 
            // lblScheduleAssignedEmployee
            // 
            this.lblScheduleAssignedEmployee.AutoSize = true;
            this.lblScheduleAssignedEmployee.Location = new System.Drawing.Point(147, 60);
            this.lblScheduleAssignedEmployee.Name = "lblScheduleAssignedEmployee";
            this.lblScheduleAssignedEmployee.Size = new System.Drawing.Size(89, 17);
            this.lblScheduleAssignedEmployee.TabIndex = 8;
            this.lblScheduleAssignedEmployee.Text = "Not Selected";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Selected Shift:";
            // 
            // lblScheduleDateAssign
            // 
            this.lblScheduleDateAssign.AutoSize = true;
            this.lblScheduleDateAssign.Location = new System.Drawing.Point(147, 30);
            this.lblScheduleDateAssign.Name = "lblScheduleDateAssign";
            this.lblScheduleDateAssign.Size = new System.Drawing.Size(89, 17);
            this.lblScheduleDateAssign.TabIndex = 7;
            this.lblScheduleDateAssign.Text = "Not Selected";
            // 
            // cmbScheduleAssign
            // 
            this.cmbScheduleAssign.FormattingEnabled = true;
            this.cmbScheduleAssign.Items.AddRange(new object[] {
            "Morning",
            "Evening",
            "Night"});
            this.cmbScheduleAssign.Location = new System.Drawing.Point(150, 87);
            this.cmbScheduleAssign.Name = "cmbScheduleAssign";
            this.cmbScheduleAssign.Size = new System.Drawing.Size(145, 24);
            this.cmbScheduleAssign.TabIndex = 6;
            this.cmbScheduleAssign.SelectedIndexChanged += new System.EventHandler(this.cmbScheduleAssign_SelectedIndexChanged);
            // 
            // tabStatistics
            // 
            this.tabStatistics.Location = new System.Drawing.Point(4, 25);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Size = new System.Drawing.Size(837, 474);
            this.tabStatistics.TabIndex = 3;
            this.tabStatistics.Text = "Statistics";
            this.tabStatistics.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 527);
            this.Controls.Add(this.tbcMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tbcMain.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            this.tabSchedule.ResumeLayout(false);
            this.tabSchedule.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblScheduleDateInfo;
        private System.Windows.Forms.ComboBox cmbScheduleAssignedShift;
        private System.Windows.Forms.ListBox lsbAssignedEmployees;
        private System.Windows.Forms.ListBox lsbScheduleEmployees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnScheduleAssign;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblScheduleAssignedEmployee;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblScheduleDateAssign;
        private System.Windows.Forms.ComboBox cmbScheduleAssign;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txbScheduleEmployeeSearch;
        private Pabo.Calendar.MonthCalendar mcdSchedule;
        private System.Windows.Forms.Button btnScheduleUnassign;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
    }
}

