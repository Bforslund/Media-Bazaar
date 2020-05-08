namespace WindowsFormsApp1
{
    partial class UpdateProductForm
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
            this.btAddUpdate = new System.Windows.Forms.Button();
            this.tbBuyPrice = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSellPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btAddUpdate
            // 
            this.btAddUpdate.BackColor = System.Drawing.Color.Red;
            this.btAddUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddUpdate.ForeColor = System.Drawing.Color.White;
            this.btAddUpdate.Location = new System.Drawing.Point(121, 206);
            this.btAddUpdate.Name = "btAddUpdate";
            this.btAddUpdate.Size = new System.Drawing.Size(179, 42);
            this.btAddUpdate.TabIndex = 32;
            this.btAddUpdate.Text = "Add new product";
            this.btAddUpdate.UseVisualStyleBackColor = false;
            this.btAddUpdate.Click += new System.EventHandler(this.btAddUpdate_Click);
            // 
            // tbBuyPrice
            // 
            this.tbBuyPrice.Location = new System.Drawing.Point(166, 96);
            this.tbBuyPrice.Name = "tbBuyPrice";
            this.tbBuyPrice.Size = new System.Drawing.Size(121, 22);
            this.tbBuyPrice.TabIndex = 29;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(166, 68);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 22);
            this.tbName.TabIndex = 28;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(166, 40);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(121, 22);
            this.tbType.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Department:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Buying price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(166, 150);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Selling price:";
            // 
            // tbSellPrice
            // 
            this.tbSellPrice.Location = new System.Drawing.Point(166, 125);
            this.tbSellPrice.Name = "tbSellPrice";
            this.tbSellPrice.Size = new System.Drawing.Size(121, 22);
            this.tbSellPrice.TabIndex = 35;
            // 
            // UpdateProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 260);
            this.Controls.Add(this.tbSellPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btAddUpdate);
            this.Controls.Add(this.tbBuyPrice);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateProductForm";
            this.Text = "Create new product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddUpdate;
        private System.Windows.Forms.TextBox tbBuyPrice;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSellPrice;
    }
}