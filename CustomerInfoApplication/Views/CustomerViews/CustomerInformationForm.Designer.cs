namespace CustomerInfoApplication.Views.CustomerViews
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.PictureBox();
            this.customerGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnnualRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delBtn = new System.Windows.Forms.DataGridViewImageColumn();
            this.updateBtn = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(102, 56);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(611, 43);
            this.searchBox.TabIndex = 17;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // addBtn
            // 
            this.addBtn.Image = global::CustomerInfoApplication.Properties.Resources.add;
            this.addBtn.Location = new System.Drawing.Point(48, 150);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(61, 54);
            this.addBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addBtn.TabIndex = 18;
            this.addBtn.TabStop = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // customerGrid
            // 
            this.customerGrid.AllowDrop = true;
            this.customerGrid.AllowUserToAddRows = false;
            this.customerGrid.AllowUserToDeleteRows = false;
            this.customerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.customerGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.customerGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerGrid.ColumnHeadersHeight = 52;
            this.customerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.customerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CustomerName,
            this.VAT,
            this.Phone,
            this.Address,
            this.City,
            this.AnnualRevenue,
            this.delBtn,
            this.updateBtn});
            this.customerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerGrid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.customerGrid.Location = new System.Drawing.Point(0, 0);
            this.customerGrid.Name = "customerGrid";
            this.customerGrid.ReadOnly = true;
            this.customerGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.customerGrid.RowHeadersVisible = false;
            this.customerGrid.RowHeadersWidth = 92;
            this.customerGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerGrid.RowTemplate.Height = 45;
            this.customerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerGrid.Size = new System.Drawing.Size(2762, 819);
            this.customerGrid.TabIndex = 11;
            this.customerGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerGrid_CellClick);
            this.customerGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.customerGrid_ColumnHeaderMouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.customerGrid);
            this.panel1.Location = new System.Drawing.Point(102, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2762, 819);
            this.panel1.TabIndex = 19;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Id.FillWeight = 30F;
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 15;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Id.ToolTipText = "Customer Identity Number";
            // 
            // CustomerName
            // 
            this.CustomerName.FillWeight = 57.89191F;
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.MinimumWidth = 11;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerName.ToolTipText = "Customer Name";
            // 
            // VAT
            // 
            this.VAT.FillWeight = 57.89191F;
            this.VAT.HeaderText = "VAT";
            this.VAT.MinimumWidth = 11;
            this.VAT.Name = "VAT";
            this.VAT.ReadOnly = true;
            this.VAT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.VAT.ToolTipText = "Tax Code";
            // 
            // Phone
            // 
            this.Phone.FillWeight = 57.89191F;
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 11;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Phone.ToolTipText = "Phone Number";
            // 
            // Address
            // 
            this.Address.FillWeight = 57.89191F;
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 11;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Address.ToolTipText = "Address";
            // 
            // City
            // 
            this.City.FillWeight = 57.89191F;
            this.City.HeaderText = "City";
            this.City.MinimumWidth = 11;
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.City.ToolTipText = "City";
            // 
            // AnnualRevenue
            // 
            this.AnnualRevenue.FillWeight = 57.89191F;
            this.AnnualRevenue.HeaderText = "Annual Income";
            this.AnnualRevenue.MinimumWidth = 11;
            this.AnnualRevenue.Name = "AnnualRevenue";
            this.AnnualRevenue.ReadOnly = true;
            this.AnnualRevenue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.AnnualRevenue.ToolTipText = "Income";
            // 
            // delBtn
            // 
            this.delBtn.FillWeight = 15F;
            this.delBtn.HeaderText = "";
            this.delBtn.Image = global::CustomerInfoApplication.Properties.Resources.del;
            this.delBtn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.delBtn.MinimumWidth = 11;
            this.delBtn.Name = "delBtn";
            this.delBtn.ReadOnly = true;
            // 
            // updateBtn
            // 
            this.updateBtn.FillWeight = 14.19337F;
            this.updateBtn.HeaderText = "";
            this.updateBtn.Image = global::CustomerInfoApplication.Properties.Resources.account_edit;
            this.updateBtn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.updateBtn.MinimumWidth = 11;
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.ReadOnly = true;
            // 
            // CustomerInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2976, 1111);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.searchBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerInformationForm";
            this.Text = "Customer Information Form";
            this.Load += new System.EventHandler(this.CustomerInformationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox phoneName;
        public System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.PictureBox addBtn;
        private System.Windows.Forms.DataGridView customerGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnnualRevenue;
        private System.Windows.Forms.DataGridViewImageColumn delBtn;
        private System.Windows.Forms.DataGridViewImageColumn updateBtn;
    }
}

