namespace WindowsFormsApp1
{
    partial class Increase
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
            this.nUDStock = new System.Windows.Forms.NumericUpDown();
            this.btConfirm = new System.Windows.Forms.Button();
            this.rbIncrease = new System.Windows.Forms.RadioButton();
            this.rbDecrease = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStock)).BeginInit();
            this.SuspendLayout();
            // 
            // nUDStock
            // 
            this.nUDStock.Location = new System.Drawing.Point(30, 172);
            this.nUDStock.Name = "nUDStock";
            this.nUDStock.Size = new System.Drawing.Size(120, 22);
            this.nUDStock.TabIndex = 0;
            // 
            // btConfirm
            // 
            this.btConfirm.Location = new System.Drawing.Point(177, 171);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(177, 23);
            this.btConfirm.TabIndex = 2;
            this.btConfirm.Text = "Confirm";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // rbIncrease
            // 
            this.rbIncrease.AutoSize = true;
            this.rbIncrease.Location = new System.Drawing.Point(40, 135);
            this.rbIncrease.Name = "rbIncrease";
            this.rbIncrease.Size = new System.Drawing.Size(120, 21);
            this.rbIncrease.TabIndex = 3;
            this.rbIncrease.TabStop = true;
            this.rbIncrease.Text = "Increase stock";
            this.rbIncrease.UseVisualStyleBackColor = true;
            // 
            // rbDecrease
            // 
            this.rbDecrease.AutoSize = true;
            this.rbDecrease.Location = new System.Drawing.Point(177, 135);
            this.rbDecrease.Name = "rbDecrease";
            this.rbDecrease.Size = new System.Drawing.Size(127, 21);
            this.rbDecrease.TabIndex = 4;
            this.rbDecrease.TabStop = true;
            this.rbDecrease.Text = "Decrease stock";
            this.rbDecrease.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Increase or decrease stock";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "You have selected:";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(27, 73);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(23, 17);
            this.lblSelected.TabIndex = 7;
            this.lblSelected.Text = "***";
            // 
            // Increase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 214);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbDecrease);
            this.Controls.Add(this.rbIncrease);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.nUDStock);
            this.Name = "Increase";
            this.Text = "Increase/Decrease stock";
            ((System.ComponentModel.ISupportInitialize)(this.nUDStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDStock;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.RadioButton rbIncrease;
        private System.Windows.Forms.RadioButton rbDecrease;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelected;
    }
}