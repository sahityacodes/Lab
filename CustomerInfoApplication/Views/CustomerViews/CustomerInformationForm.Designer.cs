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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInformationForm));
            this.searchBox = new System.Windows.Forms.TextBox();
            this.customerGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnnualRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.add = new DevExpress.XtraBars.BarButtonItem();
            this.edit = new DevExpress.XtraBars.BarButtonItem();
            this.delete = new DevExpress.XtraBars.BarButtonItem();
            this.customerPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.custPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(97, 426);
            this.searchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(530, 36);
            this.searchBox.TabIndex = 17;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
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
            this.customerGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.customerGrid.ColumnHeadersHeight = 52;
            this.customerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.customerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CustomerName,
            this.VAT,
            this.Phone,
            this.Address,
            this.City,
            this.AnnualRevenue});
            this.customerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerGrid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.customerGrid.Location = new System.Drawing.Point(0, 0);
            this.customerGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerGrid.Name = "customerGrid";
            this.customerGrid.ReadOnly = true;
            this.customerGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.customerGrid.RowHeadersVisible = false;
            this.customerGrid.RowHeadersWidth = 92;
            this.customerGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerGrid.RowTemplate.Height = 45;
            this.customerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerGrid.ShowEditingIcon = false;
            this.customerGrid.Size = new System.Drawing.Size(2584, 900);
            this.customerGrid.TabIndex = 11;
            this.customerGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.customerGrid_ColumnHeaderMouseClick);
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
            this.Id.Width = 225;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.customerGrid);
            this.panel1.Location = new System.Drawing.Point(88, 518);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2584, 900);
            this.panel1.TabIndex = 19;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ribbonControl1.AllowContentChangeAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.AllowTrimPageText = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.add,
            this.edit,
            this.delete});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.customerPage});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(2751, 344);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbonControl1.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // add
            // 
            this.add.Id = 13;
            this.add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("add.ImageOptions.Image")));
            this.add.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("add.ImageOptions.LargeImage")));
            this.add.Name = "add";
            this.add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.add_ItemClick);
            // 
            // edit
            // 
            this.edit.Id = 18;
            this.edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("edit.ImageOptions.Image")));
            this.edit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("edit.ImageOptions.LargeImage")));
            this.edit.Name = "edit";
            this.edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.edit_Clicked);
            // 
            // delete
            // 
            this.delete.Id = 21;
            this.delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("delete.ImageOptions.Image")));
            this.delete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("delete.ImageOptions.LargeImage")));
            this.delete.Name = "delete";
            this.delete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.delClicked);
            // 
            // customerPage
            // 
            this.customerPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.custPage});
            this.customerPage.Name = "customerPage";
            this.customerPage.Text = "Customer";
            // 
            // custPage
            // 
            this.custPage.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.custPage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("custPage.ImageOptions.Image")));
            this.custPage.ImageOptions.ImageIndex = 1;
            this.custPage.ImageOptions.ImageUri.Uri = "AddItem";
            this.custPage.ItemLinks.Add(this.add);
            this.custPage.ItemLinks.Add(this.edit);
            this.custPage.ItemLinks.Add(this.delete);
            this.custPage.Name = "custPage";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonPageGroup3.ImageOptions.SvgImage")));
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonPageGroup2.ImageOptions.SvgImage")));
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.ImageOptions.Image")));
            this.ribbonPageGroup1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonPageGroup1.ImageOptions.SvgImage")));
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // CustomerInformationForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2751, 1510);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CustomerInformationForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CustomerInformationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox phoneName;
        public System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView customerGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnnualRevenue;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPage customerPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup custPage;
        private DevExpress.XtraBars.BarButtonItem add;
        private DevExpress.XtraBars.BarButtonItem edit;
        private DevExpress.XtraBars.BarButtonItem delete;
    }
}

