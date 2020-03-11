namespace testproject
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
            this.monthCalendar2 = new Pabo.Calendar.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.ActiveMonth.Month = 3;
            this.monthCalendar2.ActiveMonth.Year = 2020;
            this.monthCalendar2.Culture = new System.Globalization.CultureInfo("nl-NL");
            this.monthCalendar2.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar2.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendar2.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendar2.ImageList = null;
            this.monthCalendar2.Location = new System.Drawing.Point(12, 12);
            this.monthCalendar2.MaxDate = new System.DateTime(2030, 3, 11, 9, 36, 34, 957);
            this.monthCalendar2.MinDate = new System.DateTime(2010, 3, 11, 9, 36, 34, 957);
            this.monthCalendar2.Month.BackgroundImage = null;
            this.monthCalendar2.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.SelectionMode = Pabo.Calendar.mcSelectionMode.One;
            this.monthCalendar2.Size = new System.Drawing.Size(305, 327);
            this.monthCalendar2.TabIndex = 1;
            this.monthCalendar2.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendar2.DayClick += new Pabo.Calendar.DayClickEventHandler(this.monthCalendar2_DayClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Pabo.Calendar.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Label label1;
    }
}

