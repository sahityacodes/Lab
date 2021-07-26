namespace CustomerInfoApplication.Forms
{
    partial class CustomerInformationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customerGrid = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.searchByName = new System.Windows.Forms.Button();
            this.btn_addNewRecord = new System.Windows.Forms.Button();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.contactPersonName = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.textID = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerGrid
            // 
            this.customerGrid.AllowDrop = true;
            this.customerGrid.AllowUserToResizeColumns = false;
            this.customerGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.customerGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.customerGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerGrid.ColumnHeadersHeight = 52;
            this.customerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.customerGrid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.customerGrid.Location = new System.Drawing.Point(615, 171);
            this.customerGrid.Name = "customerGrid";
            this.customerGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.customerGrid.RowHeadersVisible = false;
            this.customerGrid.RowHeadersWidth = 92;
            this.customerGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerGrid.RowTemplate.Height = 45;
            this.customerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerGrid.Size = new System.Drawing.Size(1030, 508);
            this.customerGrid.TabIndex = 11;
            this.customerGrid.SelectionChanged += new System.EventHandler(this.CustomerGrid_SelectionChanged);
            this.customerGrid.Click += new System.EventHandler(this.customerGrid_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(408, 43);
            this.textBox1.TabIndex = 3;
            // 
            // searchByName
            // 
            this.searchByName.Location = new System.Drawing.Point(537, 78);
            this.searchByName.Name = "searchByName";
            this.searchByName.Size = new System.Drawing.Size(294, 43);
            this.searchByName.TabIndex = 4;
            this.searchByName.Text = "Search By Name";
            this.searchByName.UseVisualStyleBackColor = true;
            this.searchByName.Click += new System.EventHandler(this.SearchByName_Click);
            // 
            // btn_addNewRecord
            // 
            this.btn_addNewRecord.Location = new System.Drawing.Point(68, 653);
            this.btn_addNewRecord.Name = "btn_addNewRecord";
            this.btn_addNewRecord.Size = new System.Drawing.Size(239, 52);
            this.btn_addNewRecord.TabIndex = 5;
            this.btn_addNewRecord.Text = "Add New Record";
            this.btn_addNewRecord.UseVisualStyleBackColor = true;
            this.btn_addNewRecord.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Enabled = false;
            this.txtBoxName.Location = new System.Drawing.Point(68, 324);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(433, 43);
            this.txtBoxName.TabIndex = 6;
            // 
            // contactPersonName
            // 
            this.contactPersonName.Enabled = false;
            this.contactPersonName.Location = new System.Drawing.Point(68, 415);
            this.contactPersonName.Name = "contactPersonName";
            this.contactPersonName.Size = new System.Drawing.Size(433, 43);
            this.contactPersonName.TabIndex = 7;
            // 
            // phone
            // 
            this.phone.Enabled = false;
            this.phone.Location = new System.Drawing.Point(68, 512);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(433, 43);
            this.phone.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(313, 653);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 52);
            this.button2.TabIndex = 9;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(68, 653);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(214, 52);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update Record";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(68, 653);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(239, 52);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "Insert Record";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Visible = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // textID
            // 
            this.textID.Enabled = false;
            this.textID.Location = new System.Drawing.Point(68, 243);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(100, 43);
            this.textID.TabIndex = 13;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(68, 726);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(214, 52);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "Delete Record";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(313, 725);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(188, 53);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // CustomerInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 921);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.contactPersonName);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.btn_addNewRecord);
            this.Controls.Add(this.searchByName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.customerGrid);
            this.Name = "CustomerInformationForm";
            this.Text = "Customer Information Form";
            this.Load += new System.EventHandler(this.CustomerInformationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public System.Windows.Forms.DataGridView customerGrid;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button searchByName;
        public System.Windows.Forms.Button btn_addNewRecord;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.Button button2;
         public System.Windows.Forms.TextBox txtBoxName;
        public System.Windows.Forms.TextBox contactPersonName;
        public System.Windows.Forms.TextBox phoneName;
        public System.Windows.Forms.TextBox phone;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnInsert;
        public System.Windows.Forms.TextBox textID;
        public System.Windows.Forms.Button btnDel;
        public System.Windows.Forms.Button btnReset;
    }
}

