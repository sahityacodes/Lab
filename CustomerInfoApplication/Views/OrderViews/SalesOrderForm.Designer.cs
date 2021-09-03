
namespace CustomerInfoApplication.Views.OrderViews
{
    partial class SalesOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesOrderForm));
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::CustomerInfoApplication.Views.Misc.WaitForm1), true, true, true);
            this.searchBox = new System.Windows.Forms.TextBox();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.add = new DevExpress.XtraBars.BarButtonItem();
            this.edit = new DevExpress.XtraBars.BarButtonItem();
            this.delete = new DevExpress.XtraBars.BarButtonItem();
            this.importDropdown = new DevExpress.XtraBars.BarListItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.Orders = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.orderPage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.orderGrid = new System.Windows.Forms.DataGridView();
            this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(49, 406);
            this.searchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(530, 36);
            this.searchBox.TabIndex = 18;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.add,
            this.edit,
            this.delete,
            this.importDropdown,
            this.barButtonGroup1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 31;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.Orders});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(3101, 305);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // add
            // 
            this.add.Caption = "Add";
            this.add.Id = 13;
            this.add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("add.ImageOptions.Image")));
            this.add.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("add.ImageOptions.LargeImage")));
            this.add.Name = "add";
            this.add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.add_ItemClick);
            // 
            // edit
            // 
            this.edit.Caption = "Edit";
            this.edit.Enabled = false;
            this.edit.Id = 18;
            this.edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("edit.ImageOptions.Image")));
            this.edit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("edit.ImageOptions.LargeImage")));
            this.edit.Name = "edit";
            this.edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.edit_ItemClick);
            // 
            // delete
            // 
            this.delete.Caption = "Delete";
            this.delete.Enabled = false;
            this.delete.Id = 21;
            this.delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("delete.ImageOptions.Image")));
            this.delete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("delete.ImageOptions.LargeImage")));
            this.delete.Name = "delete";
            this.delete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.delete_ItemClick);
            // 
            // importDropdown
            // 
            this.importDropdown.Caption = "Import Rows";
            this.importDropdown.Id = 24;
            this.importDropdown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("importDropdown.ImageOptions.Image")));
            this.importDropdown.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("importDropdown.ImageOptions.LargeImage")));
            this.importDropdown.Name = "importDropdown";
            this.importDropdown.Strings.AddRange(new object[] {
            "Excel",
            "File",
            "Clipboard"});
            this.importDropdown.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.importDropdown_ListItemClick);
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 30;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // Orders
            // 
            this.Orders.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.orderPage,
            this.ribbonPageGroup1});
            this.Orders.Name = "Orders";
            this.Orders.Text = "Orders";
            // 
            // orderPage
            // 
            this.orderPage.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.orderPage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("orderPage.ImageOptions.Image")));
            this.orderPage.ImageOptions.ImageIndex = 1;
            this.orderPage.ImageOptions.ImageUri.Uri = "AddItem";
            this.orderPage.ItemLinks.Add(this.add);
            this.orderPage.ItemLinks.Add(this.edit);
            this.orderPage.ItemLinks.Add(this.delete);
            this.orderPage.Name = "orderPage";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.importDropdown);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonGroup1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // orderGrid
            // 
            this.orderGrid.AllowDrop = true;
            this.orderGrid.AllowUserToAddRows = false;
            this.orderGrid.AllowUserToDeleteRows = false;
            this.orderGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.orderGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.orderGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderGrid.ColumnHeadersHeight = 56;
            this.orderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderID,
            this.CustomerID,
            this.CustomerName,
            this.date,
            this.TotalCost,
            this.DeliveryDate,
            this.ShippingAdd});
            this.orderGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderGrid.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.orderGrid.Location = new System.Drawing.Point(0, 0);
            this.orderGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.ReadOnly = true;
            this.orderGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.orderGrid.RowHeadersVisible = false;
            this.orderGrid.RowHeadersWidth = 92;
            this.orderGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.orderGrid.RowTemplate.Height = 30;
            this.orderGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderGrid.Size = new System.Drawing.Size(2977, 1008);
            this.orderGrid.TabIndex = 12;
            this.orderGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.orderGrid_ColumnHeaderMouseClick);
            // 
            // OrderID
            // 
            this.OrderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderID.FillWeight = 30F;
            this.OrderID.HeaderText = "Order ID";
            this.OrderID.MinimumWidth = 15;
            this.OrderID.Name = "OrderID";
            this.OrderID.ReadOnly = true;
            this.OrderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderID.ToolTipText = "Customer Identity Number";
            this.OrderID.Width = 130;
            // 
            // CustomerID
            // 
            this.CustomerID.FillWeight = 69.33961F;
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.MinimumWidth = 15;
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerID.ToolTipText = "Customer Name";
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.MinimumWidth = 11;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // date
            // 
            this.date.FillWeight = 69.33961F;
            this.date.HeaderText = "Order Date";
            this.date.MinimumWidth = 11;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.date.ToolTipText = "Tax Code";
            // 
            // TotalCost
            // 
            this.TotalCost.HeaderText = "Total Cost";
            this.TotalCost.MinimumWidth = 11;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            this.TotalCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.HeaderText = "Delivery Date";
            this.DeliveryDate.MinimumWidth = 11;
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.ReadOnly = true;
            this.DeliveryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ShippingAdd
            // 
            this.ShippingAdd.HeaderText = "Shipping Address";
            this.ShippingAdd.MinimumWidth = 11;
            this.ShippingAdd.Name = "ShippingAdd";
            this.ShippingAdd.ReadOnly = true;
            this.ShippingAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.orderGrid);
            this.panel1.Location = new System.Drawing.Point(49, 475);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2977, 1008);
            this.panel1.TabIndex = 20;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 23;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Location = new System.Drawing.Point(780, 1450);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1765, 838, 1462, 900);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(877, 43);
            this.dataLayoutControl1.TabIndex = 22;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(877, 43);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(3304, 368);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // SalesOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3101, 1539);
            this.ControlBox = false;
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SalesOrderForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SalesOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchBox;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem add;
        private DevExpress.XtraBars.BarButtonItem edit;
        private DevExpress.XtraBars.BarButtonItem delete;
        private DevExpress.XtraBars.Ribbon.RibbonPage Orders;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup orderPage;
        private System.Windows.Forms.DataGridView orderGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private DevExpress.XtraBars.BarListItem importDropdown;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
    }
}