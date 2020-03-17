namespace WindowsFormsApp1
{
    partial class MediaBazaar
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
            this.mcdSchedule = new Pabo.Calendar.MonthCalendar();
            this.lblSSearch = new System.Windows.Forms.Label();
            this.txbScheduleEmployeeSearch = new System.Windows.Forms.TextBox();
            this.groupSInformation = new System.Windows.Forms.GroupBox();
            this.btnScheduleUnassign = new System.Windows.Forms.Button();
            this.lblSMaxEmployee = new System.Windows.Forms.Label();
            this.labelSMinEmployee = new System.Windows.Forms.Label();
            this.labelSNumEmployeeShift = new System.Windows.Forms.Label();
            this.labelSShift1 = new System.Windows.Forms.Label();
            this.labelSNumEmployeeDay = new System.Windows.Forms.Label();
            this.labelSDate1 = new System.Windows.Forms.Label();
            this.lblScheduleDateInfo = new System.Windows.Forms.Label();
            this.cmbScheduleAssignedShift = new System.Windows.Forms.ComboBox();
            this.lsbAssignedEmployees = new System.Windows.Forms.ListBox();
            this.lsbScheduleEmployees = new System.Windows.Forms.ListBox();
            this.groupBoxSAssign = new System.Windows.Forms.GroupBox();
            this.labelSDate2 = new System.Windows.Forms.Label();
            this.btnScheduleAssign = new System.Windows.Forms.Button();
            this.labelSEmployee = new System.Windows.Forms.Label();
            this.lblScheduleAssignedEmployee = new System.Windows.Forms.Label();
            this.labelSShift2 = new System.Windows.Forms.Label();
            this.lblScheduleDateAssign = new System.Windows.Forms.Label();
            this.cmbScheduleAssign = new System.Windows.Forms.ComboBox();
            this.groupSInformation.SuspendLayout();
            this.groupBoxSAssign.SuspendLayout();

            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.lblPSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lablePInormation = new System.Windows.Forms.Label();
            this.labelPProducts = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btRequest = new System.Windows.Forms.Button();
            this.labelPDepartment = new System.Windows.Forms.Label();
            this.labelPCurrentlyInStock = new System.Windows.Forms.Label();
            this.labelPPrice = new System.Windows.Forms.Label();
            this.labelPName = new System.Windows.Forms.Label();
            this.labelPType = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btCrease = new System.Windows.Forms.Button();
            this.lbProducts = new System.Windows.Forms.ListBox();
            this.tbcMain.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabEmployees);
            this.tbcMain.Controls.Add(this.tabProducts);
            this.tbcMain.Controls.Add(this.tabSchedule);
            this.tbcMain.Controls.Add(this.tabStatistics);
            this.tbcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcMain.Location = new System.Drawing.Point(12, 12);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(845, 503);
            this.tbcMain.TabIndex = 0;
            //ixf this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabEmployees.Location = new System.Drawing.Point(4, 29);
            this.tabEmployees.Name = "tabPage1";
            this.tabEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployees.Size = new System.Drawing.Size(790, 470);
            this.tabEmployees.TabIndex = 0;
            this.tabEmployees.Text = "Employees";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabProducts.BackColor = System.Drawing.Color.Salmon;
            this.tabProducts.Controls.Add(this.lblPSearch);
            this.tabProducts.Controls.Add(this.tbSearch);
            this.tabProducts.Controls.Add(this.lblDepartment);
            this.tabProducts.Controls.Add(this.lblStock);
            this.tabProducts.Controls.Add(this.lblPrice);
            this.tabProducts.Controls.Add(this.lblName);
            this.tabProducts.Controls.Add(this.lblType);
            this.tabProducts.Controls.Add(this.lablePInormation);
            this.tabProducts.Controls.Add(this.labelPProducts);
            this.tabProducts.Controls.Add(this.btUpdate);
            this.tabProducts.Controls.Add(this.btRequest);
            this.tabProducts.Controls.Add(this.labelPDepartment);
            this.tabProducts.Controls.Add(this.labelPCurrentlyInStock);
            this.tabProducts.Controls.Add(this.labelPPrice);
            this.tabProducts.Controls.Add(this.labelPName);
            this.tabProducts.Controls.Add(this.labelPType);
            this.tabProducts.Controls.Add(this.btAdd);
            this.tabProducts.Controls.Add(this.btRemove);
            this.tabProducts.Controls.Add(this.btCrease);
            this.tabProducts.Controls.Add(this.lbProducts);
            this.tabProducts.Location = new System.Drawing.Point(4, 29);
            this.tabProducts.Name = "tabPage2";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(790, 470);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Text = "Products";
            // 
            // lblPSearch
            // 
            this.lblPSearch.AutoSize = true;
            this.lblPSearch.Location = new System.Drawing.Point(6, 437);
            this.lblPSearch.Name = "lblPSearch";
            this.lblPSearch.Size = new System.Drawing.Size(67, 20);
            this.lblPSearch.TabIndex = 31;
            this.lblPSearch.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(79, 434);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(185, 27);
            this.tbSearch.TabIndex = 30;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(463, 198);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(27, 20);
            this.lblDepartment.TabIndex = 29;
            this.lblDepartment.Text = "***";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(463, 171);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(27, 20);
            this.lblStock.TabIndex = 28;
            this.lblStock.Text = "***";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(463, 145);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(27, 20);
            this.lblPrice.TabIndex = 27;
            this.lblPrice.Text = "***";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(463, 114);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(27, 20);
            this.lblName.TabIndex = 26;
            this.lblName.Text = "***";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(463, 86);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(27, 20);
            this.lblType.TabIndex = 25;
            this.lblType.Text = "***";
            // 
            // lablePInormation
            // 
            this.lablePInormation.AutoSize = true;
            this.lablePInormation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablePInormation.Location = new System.Drawing.Point(410, 45);
            this.lablePInormation.Name = "lablePInormation";
            this.lablePInormation.Size = new System.Drawing.Size(98, 18);
            this.lablePInormation.TabIndex = 24;
            this.lablePInormation.Text = "Information:";
            // 
            // labelPProducts
            // 
            this.labelPProducts.AutoSize = true;
            this.labelPProducts.Location = new System.Drawing.Point(3, 3);
            this.labelPProducts.Name = "labelPProducts";
            this.labelPProducts.Size = new System.Drawing.Size(81, 20);
            this.labelPProducts.TabIndex = 23;
            this.labelPProducts.Text = "Products:";
            // 
            // btUpdate
            // 
            this.btUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdate.Location = new System.Drawing.Point(560, 273);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(214, 35);
            this.btUpdate.TabIndex = 21;
            this.btUpdate.Text = "Update product";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btRequest
            // 
            this.btRequest.Location = new System.Drawing.Point(560, 396);
            this.btRequest.Name = "btRequest";
            this.btRequest.Size = new System.Drawing.Size(214, 35);
            this.btRequest.TabIndex = 20;
            this.btRequest.Text = "Request restock";
            this.btRequest.UseVisualStyleBackColor = true;
            // 
            // labelPDepartment
            // 
            this.labelPDepartment.AutoSize = true;
            this.labelPDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPDepartment.Location = new System.Drawing.Point(352, 198);
            this.labelPDepartment.Name = "labelPDepartment";
            this.labelPDepartment.Size = new System.Drawing.Size(97, 17);
            this.labelPDepartment.TabIndex = 12;
            this.labelPDepartment.Text = "Department:";
            // 
            // labelPCurrentlyInStock
            // 
            this.labelPCurrentlyInStock.AutoSize = true;
            this.labelPCurrentlyInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPCurrentlyInStock.Location = new System.Drawing.Point(309, 171);
            this.labelPCurrentlyInStock.Name = "labelPCurrentlyInStock";
            this.labelPCurrentlyInStock.Size = new System.Drawing.Size(140, 17);
            this.labelPCurrentlyInStock.TabIndex = 9;
            this.labelPCurrentlyInStock.Text = "Currently in stock;";
            // 
            // labelPPrice
            // 
            this.labelPPrice.AutoSize = true;
            this.labelPPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPPrice.Location = new System.Drawing.Point(399, 145);
            this.labelPPrice.Name = "labelPPrice";
            this.labelPPrice.Size = new System.Drawing.Size(50, 17);
            this.labelPPrice.TabIndex = 8;
            this.labelPPrice.Text = "Price:";
            // 
            // labelPName
            // 
            this.labelPName.AutoSize = true;
            this.labelPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPName.Location = new System.Drawing.Point(395, 114);
            this.labelPName.Name = "labelPName";
            this.labelPName.Size = new System.Drawing.Size(54, 17);
            this.labelPName.TabIndex = 7;
            this.labelPName.Text = "Name:";
            // 
            // labelPType
            // 
            this.labelPType.AutoSize = true;
            this.labelPType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPType.Location = new System.Drawing.Point(400, 86);
            this.labelPType.Name = "labelPType";
            this.labelPType.Size = new System.Drawing.Size(49, 17);
            this.labelPType.TabIndex = 6;
            this.labelPType.Text = "Type:";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(560, 232);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(214, 35);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "Add new product";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(560, 314);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(214, 35);
            this.btRemove.TabIndex = 3;
            this.btRemove.Text = "Remove product";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btCrease
            // 
            this.btCrease.Location = new System.Drawing.Point(560, 355);
            this.btCrease.Name = "btCrease";
            this.btCrease.Size = new System.Drawing.Size(214, 35);
            this.btCrease.TabIndex = 2;
            this.btCrease.Text = "Increase/decrease stock";
            this.btCrease.UseVisualStyleBackColor = true;
            this.btCrease.Click += new System.EventHandler(this.btCrease_Click);
            // 
            // lbProducts
            // 
            this.lbProducts.BackColor = System.Drawing.Color.White;
            this.lbProducts.FormattingEnabled = true;
            this.lbProducts.ItemHeight = 20;
            this.lbProducts.Location = new System.Drawing.Point(10, 24);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(254, 404);
            this.lbProducts.TabIndex = 0;
            this.lbProducts.SelectedIndexChanged += new System.EventHandler(this.lbProducts_SelectedIndexChanged);
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.mcdSchedule);
            this.tabSchedule.Controls.Add(this.lblSSearch);
            this.tabSchedule.Controls.Add(this.txbScheduleEmployeeSearch);
            this.tabSchedule.Controls.Add(this.groupSInformation);
            this.tabSchedule.Controls.Add(this.lsbScheduleEmployees);
            this.tabSchedule.Controls.Add(this.groupBoxSAssign);
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
            //ixf this.mcdSchedule.MonthChanged += new Pabo.Calendar.MonthChangedEventHandler(this.mcdSchedule_MonthChanged);
            //ixf this.mcdSchedule.DayClick += new Pabo.Calendar.DayClickEventHandler(this.mcdSchedule_DayClick);
            // 
            // lblSSearch
            // 
            this.lblSSearch.AutoSize = true;
            this.lblSSearch.Location = new System.Drawing.Point(570, 15);
            this.lblSSearch.Name = "lblSSearch";
            this.lblSSearch.Size = new System.Drawing.Size(57, 17);
            this.lblSSearch.TabIndex = 14;
            this.lblSSearch.Text = "Search:";
            // 
            // txbScheduleEmployeeSearch
            // 
            this.txbScheduleEmployeeSearch.Location = new System.Drawing.Point(629, 11);
            this.txbScheduleEmployeeSearch.Name = "txbScheduleEmployeeSearch";
            this.txbScheduleEmployeeSearch.Size = new System.Drawing.Size(195, 22);
            this.txbScheduleEmployeeSearch.TabIndex = 13;
            //ixf this.txbScheduleEmployeeSearch.TextChanged += new System.EventHandler(this.txbScheduleEmployeeSearch_TextChanged);
            // 
            // groupSInformation
            // 
            this.groupSInformation.Controls.Add(this.btnScheduleUnassign);
            this.groupSInformation.Controls.Add(this.lblSMaxEmployee);
            this.groupSInformation.Controls.Add(this.labelSMinEmployee);
            this.groupSInformation.Controls.Add(this.labelSNumEmployeeShift);
            this.groupSInformation.Controls.Add(this.labelSShift1);
            this.groupSInformation.Controls.Add(this.labelSNumEmployeeDay);
            this.groupSInformation.Controls.Add(this.labelSDate1);
            this.groupSInformation.Controls.Add(this.lblScheduleDateInfo);
            this.groupSInformation.Controls.Add(this.cmbScheduleAssignedShift);
            this.groupSInformation.Controls.Add(this.lsbAssignedEmployees);
            this.groupSInformation.Location = new System.Drawing.Point(9, 228);
            this.groupSInformation.Name = "groupSInformation";
            this.groupSInformation.Size = new System.Drawing.Size(555, 233);
            this.groupSInformation.TabIndex = 12;
            this.groupSInformation.TabStop = false;
            this.groupSInformation.Text = "Information for selected date";
            // 
            // btnScheduleUnassign
            // 
            this.btnScheduleUnassign.Location = new System.Drawing.Point(327, 204);
            this.btnScheduleUnassign.Name = "btnScheduleUnassign";
            this.btnScheduleUnassign.Size = new System.Drawing.Size(222, 23);
            this.btnScheduleUnassign.TabIndex = 16;
            this.btnScheduleUnassign.Text = "Unassign Employee";
            this.btnScheduleUnassign.UseVisualStyleBackColor = true;
            //ixf this.btnScheduleUnassign.Click += new System.EventHandler(this.btnScheduleUnassign_Click);
            // 
            // lblSMaxEmployee
            // 
            this.lblSMaxEmployee.AutoSize = true;
            this.lblSMaxEmployee.Location = new System.Drawing.Point(6, 171);
            this.lblSMaxEmployee.Name = "lblSMaxEmployee";
            this.lblSMaxEmployee.Size = new System.Drawing.Size(197, 17);
            this.lblSMaxEmployee.TabIndex = 17;
            this.lblSMaxEmployee.Text = "Max num employees assigned";
            // 
            // labelSMinEmployee
            // 
            this.labelSMinEmployee.AutoSize = true;
            this.labelSMinEmployee.Location = new System.Drawing.Point(6, 154);
            this.labelSMinEmployee.Name = "labelSMinEmployee";
            this.labelSMinEmployee.Size = new System.Drawing.Size(194, 17);
            this.labelSMinEmployee.TabIndex = 16;
            this.labelSMinEmployee.Text = "Min num employees assigned";
            // 
            // labelSNumEmployeeShift
            // 
            this.labelSNumEmployeeShift.AutoSize = true;
            this.labelSNumEmployeeShift.Location = new System.Drawing.Point(6, 133);
            this.labelSNumEmployeeShift.Name = "labelSNumEmployeeShift";
            this.labelSNumEmployeeShift.Size = new System.Drawing.Size(258, 17);
            this.labelSNumEmployeeShift.TabIndex = 14;
            this.labelSNumEmployeeShift.Text = "Number of employees for selected shift:";
            // 
            // labelSShift1
            // 
            this.labelSShift1.AutoSize = true;
            this.labelSShift1.Location = new System.Drawing.Point(6, 73);
            this.labelSShift1.Name = "labelSShift1";
            this.labelSShift1.Size = new System.Drawing.Size(99, 17);
            this.labelSShift1.TabIndex = 10;
            this.labelSShift1.Text = "Selected Shift:";
            // 
            // labelSNumEmployeeDay
            // 
            this.labelSNumEmployeeDay.AutoSize = true;
            this.labelSNumEmployeeDay.Location = new System.Drawing.Point(6, 116);
            this.labelSNumEmployeeDay.Name = "labelSNumEmployeeDay";
            this.labelSNumEmployeeDay.Size = new System.Drawing.Size(222, 17);
            this.labelSNumEmployeeDay.TabIndex = 12;
            this.labelSNumEmployeeDay.Text = "Number of employees for the day:";
            // 
            // labelSDate1
            // 
            this.labelSDate1.AutoSize = true;
            this.labelSDate1.Location = new System.Drawing.Point(6, 50);
            this.labelSDate1.Name = "labelSDate1";
            this.labelSDate1.Size = new System.Drawing.Size(99, 17);
            this.labelSDate1.TabIndex = 10;
            this.labelSDate1.Text = "Selected date:";
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
            //ixf this.cmbScheduleAssignedShift.SelectedIndexChanged += new System.EventHandler(this.cmbScheduleAssignedShift_SelectedIndexChanged);
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
            //ixf this.lsbScheduleEmployees.SelectedIndexChanged += new System.EventHandler(this.lsbScheduleEmployees_SelectedIndexChanged);
            // 
            // groupBoxSAssign
            // 
            this.groupBoxSAssign.Controls.Add(this.labelSDate2);
            this.groupBoxSAssign.Controls.Add(this.btnScheduleAssign);
            this.groupBoxSAssign.Controls.Add(this.labelSEmployee);
            this.groupBoxSAssign.Controls.Add(this.lblScheduleAssignedEmployee);
            this.groupBoxSAssign.Controls.Add(this.labelSShift2);
            this.groupBoxSAssign.Controls.Add(this.lblScheduleDateAssign);
            this.groupBoxSAssign.Controls.Add(this.cmbScheduleAssign);
            this.groupBoxSAssign.Location = new System.Drawing.Point(260, 9);
            this.groupBoxSAssign.Name = "groupBoxSAssign";
            this.groupBoxSAssign.Size = new System.Drawing.Size(304, 207);
            this.groupBoxSAssign.TabIndex = 10;
            this.groupBoxSAssign.TabStop = false;
            this.groupBoxSAssign.Text = "Assigning Schedule";
            // 
            // labelSDate2
            // 
            this.labelSDate2.AutoSize = true;
            this.labelSDate2.Location = new System.Drawing.Point(8, 30);
            this.labelSDate2.Name = "labelSDate2";
            this.labelSDate2.Size = new System.Drawing.Size(99, 17);
            this.labelSDate2.TabIndex = 1;
            this.labelSDate2.Text = "Selected date:";
            // 
            // btnScheduleAssign
            // 
            this.btnScheduleAssign.Location = new System.Drawing.Point(11, 128);
            this.btnScheduleAssign.Name = "btnScheduleAssign";
            this.btnScheduleAssign.Size = new System.Drawing.Size(284, 23);
            this.btnScheduleAssign.TabIndex = 9;
            this.btnScheduleAssign.Text = "Assign employee to shift";
            this.btnScheduleAssign.UseVisualStyleBackColor = true;
            //ixf this.btnScheduleAssign.Click += new System.EventHandler(this.btnScheduleAssign_Click);
            // 
            // labelSEmployee
            // 
            this.labelSEmployee.AutoSize = true;
            this.labelSEmployee.Location = new System.Drawing.Point(8, 60);
            this.labelSEmployee.Name = "labelSEmployee";
            this.labelSEmployee.Size = new System.Drawing.Size(133, 17);
            this.labelSEmployee.TabIndex = 2;
            this.labelSEmployee.Text = "Selected Employee:";
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
            // labelSShift2
            // 
            this.labelSShift2.AutoSize = true;
            this.labelSShift2.Location = new System.Drawing.Point(8, 90);
            this.labelSShift2.Name = "labelSShift2";
            this.labelSShift2.Size = new System.Drawing.Size(99, 17);
            this.labelSShift2.TabIndex = 4;
            this.labelSShift2.Text = "Selected Shift:";
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
            //ixf this.cmbScheduleAssign.SelectedIndexChanged += new System.EventHandler(this.cmbScheduleAssign_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabStatistics.Location = new System.Drawing.Point(4, 29);
            this.tabStatistics.Name = "tabPage4";
            this.tabStatistics.Size = new System.Drawing.Size(790, 470);
            this.tabStatistics.TabIndex = 3;
            this.tabStatistics.Text = "Statistics";
            this.tabStatistics.UseVisualStyleBackColor = true;
            // 
            // MediaBazaar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 527);
            this.Controls.Add(this.tbcMain);
            this.Name = "MediaBazaar";
            this.Text = "MediaBazaar";
            this.tbcMain.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btRequest;
        private System.Windows.Forms.Label labelPDepartment;
        private System.Windows.Forms.Label labelPCurrentlyInStock;
        private System.Windows.Forms.Label labelPPrice;
        private System.Windows.Forms.Label labelPName;
        private System.Windows.Forms.Label labelPType;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btCrease;
        private System.Windows.Forms.ListBox lbProducts;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Label lablePInormation;
        private System.Windows.Forms.Label labelPProducts;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPSearch;
        private System.Windows.Forms.TextBox tbSearch;

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.GroupBox groupSInformation;
        private System.Windows.Forms.Label labelSNumEmployeeDay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelSDate1;
        private System.Windows.Forms.Label lblScheduleDateInfo;
        private System.Windows.Forms.ComboBox cmbScheduleAssignedShift;
        private System.Windows.Forms.ListBox lsbAssignedEmployees;
        private System.Windows.Forms.ListBox lsbScheduleEmployees;
        private System.Windows.Forms.GroupBox groupBoxSAssign;
        private System.Windows.Forms.Label labelSDate2;
        private System.Windows.Forms.Button btnScheduleAssign;
        private System.Windows.Forms.Label labelSEmployee;
        private System.Windows.Forms.Label lblScheduleAssignedEmployee;
        private System.Windows.Forms.Label labelSShift2;
        private System.Windows.Forms.Label lblScheduleDateAssign;
        private System.Windows.Forms.ComboBox cmbScheduleAssign;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labelSNumEmployeeShift;
        private System.Windows.Forms.Label labelSShift1;
        private System.Windows.Forms.Label lblSSearch;
        private System.Windows.Forms.TextBox txbScheduleEmployeeSearch;
        private Pabo.Calendar.MonthCalendar mcdSchedule;
        private System.Windows.Forms.Button btnScheduleUnassign;
        private System.Windows.Forms.Label lblSMaxEmployee;
        private System.Windows.Forms.Label labelSMinEmployee;
    }
}

