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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 503);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Salmon;
            this.tabPage2.Controls.Add(this.lblPSearch);
            this.tabPage2.Controls.Add(this.tbSearch);
            this.tabPage2.Controls.Add(this.lblDepartment);
            this.tabPage2.Controls.Add(this.lblStock);
            this.tabPage2.Controls.Add(this.lblPrice);
            this.tabPage2.Controls.Add(this.lblName);
            this.tabPage2.Controls.Add(this.lblType);
            this.tabPage2.Controls.Add(this.lablePInormation);
            this.tabPage2.Controls.Add(this.labelPProducts);
            this.tabPage2.Controls.Add(this.btUpdate);
            this.tabPage2.Controls.Add(this.btRequest);
            this.tabPage2.Controls.Add(this.labelPDepartment);
            this.tabPage2.Controls.Add(this.labelPCurrentlyInStock);
            this.tabPage2.Controls.Add(this.labelPPrice);
            this.tabPage2.Controls.Add(this.labelPName);
            this.tabPage2.Controls.Add(this.labelPType);
            this.tabPage2.Controls.Add(this.btAdd);
            this.tabPage2.Controls.Add(this.btRemove);
            this.tabPage2.Controls.Add(this.btCrease);
            this.tabPage2.Controls.Add(this.lbProducts);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(790, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Products";
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
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(790, 470);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Schedule";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(790, 470);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Statistics";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // MediaBazaar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 527);
            this.Controls.Add(this.tabControl1);
            this.Name = "MediaBazaar";
            this.Text = "MediaBazaar";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
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
    }
}

