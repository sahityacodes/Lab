
namespace CustomerInfoApplication.Views.OrderViews
{
    partial class SalesOrderDetailsForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.deliveryDate = new System.Windows.Forms.DateTimePicker();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textPayment = new System.Windows.Forms.ComboBox();
            this.customerIdText = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.calCostBtn = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textTotalAmount = new System.Windows.Forms.TextBox();
            this.productDts = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orderRowsGrid = new System.Windows.Forms.DataGridView();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalRowPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDiscountAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textShippingCost = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderRowsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.deliveryDate);
            this.splitContainer1.Panel1.Controls.Add(this.datePicker);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.textPayment);
            this.splitContainer1.Panel1.Controls.Add(this.customerIdText);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.textAddress);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.calCostBtn);
            this.splitContainer1.Panel2.Controls.Add(this.Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.Save);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.textTotalAmount);
            this.splitContainer1.Panel2.Controls.Add(this.productDts);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.textDiscountAmount);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textShippingCost);
            this.splitContainer1.Size = new System.Drawing.Size(2409, 1058);
            this.splitContainer1.SplitterDistance = 836;
            this.splitContainer1.TabIndex = 0;
            // 
            // deliveryDate
            // 
            this.deliveryDate.Location = new System.Drawing.Point(302, 965);
            this.deliveryDate.Name = "deliveryDate";
            this.deliveryDate.Size = new System.Drawing.Size(464, 36);
            this.deliveryDate.TabIndex = 9;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(302, 707);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(464, 36);
            this.datePicker.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(45, 597);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(352, 43);
            this.label10.TabIndex = 20;
            this.label10.Text = "Shipping Information";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(45, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(246, 43);
            this.label9.TabIndex = 19;
            this.label9.Text = "Customer Info";
            // 
            // textPayment
            // 
            this.textPayment.FormattingEnabled = true;
            this.textPayment.Items.AddRange(new object[] {
            "CreditCard/DebitCard",
            "PayPal",
            "Cash"});
            this.textPayment.Location = new System.Drawing.Point(302, 791);
            this.textPayment.Name = "textPayment";
            this.textPayment.Size = new System.Drawing.Size(464, 37);
            this.textPayment.TabIndex = 7;
            // 
            // customerIdText
            // 
            this.customerIdText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerIdText.FormattingEnabled = true;
            this.customerIdText.Location = new System.Drawing.Point(302, 118);
            this.customerIdText.Name = "customerIdText";
            this.customerIdText.Size = new System.Drawing.Size(464, 37);
            this.customerIdText.TabIndex = 1;
            this.customerIdText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.customerIdText_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 965);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 29);
            this.label7.TabIndex = 10;
            this.label7.Text = "Delivery Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 879);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Shipping Addres";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 791);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Payment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 707);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date of Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer ID";
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(302, 876);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(464, 36);
            this.textAddress.TabIndex = 8;
            // 
            // calCostBtn
            // 
            this.calCostBtn.Location = new System.Drawing.Point(89, 540);
            this.calCostBtn.Name = "calCostBtn";
            this.calCostBtn.Size = new System.Drawing.Size(238, 52);
            this.calCostBtn.TabIndex = 17;
            this.calCostBtn.Text = "View Costs";
            this.calCostBtn.UseVisualStyleBackColor = true;
            this.calCostBtn.Click += new System.EventHandler(this.calCostBtn_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(959, 965);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(169, 52);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Save.Location = new System.Drawing.Point(1333, 965);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(169, 52);
            this.Save.TabIndex = 10;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CustomerInfoApplication.Properties.Resources.add;
            this.pictureBox1.InitialImage = global::CustomerInfoApplication.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(35, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textTotalAmount
            // 
            this.textTotalAmount.Enabled = false;
            this.textTotalAmount.Location = new System.Drawing.Point(1258, 689);
            this.textTotalAmount.Name = "textTotalAmount";
            this.textTotalAmount.Size = new System.Drawing.Size(92, 36);
            this.textTotalAmount.TabIndex = 5;
            // 
            // productDts
            // 
            this.productDts.AutoSize = true;
            this.productDts.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productDts.Location = new System.Drawing.Point(613, 28);
            this.productDts.Name = "productDts";
            this.productDts.Size = new System.Drawing.Size(258, 43);
            this.productDts.TabIndex = 1;
            this.productDts.Text = "Product Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1040, 609);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "Shipping Cost";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1040, 689);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 29);
            this.label8.TabIndex = 14;
            this.label8.Text = "Total Amount";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.orderRowsGrid);
            this.panel1.Location = new System.Drawing.Point(89, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1439, 381);
            this.panel1.TabIndex = 0;
            // 
            // orderRowsGrid
            // 
            this.orderRowsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.orderRowsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderRowsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCode,
            this.Description,
            this.Qty,
            this.UnitPrice,
            this.TotalRowPrice});
            this.orderRowsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderRowsGrid.Location = new System.Drawing.Point(0, 0);
            this.orderRowsGrid.Name = "orderRowsGrid";
            this.orderRowsGrid.RowHeadersVisible = false;
            this.orderRowsGrid.RowHeadersWidth = 92;
            this.orderRowsGrid.RowTemplate.Height = 45;
            this.orderRowsGrid.Size = new System.Drawing.Size(1439, 381);
            this.orderRowsGrid.TabIndex = 2;
            // 
            // ProductCode
            // 
            this.ProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductCode.HeaderText = "ProductCode";
            this.ProductCode.MinimumWidth = 11;
            this.ProductCode.Name = "ProductCode";
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 11;
            this.Description.Name = "Description";
            // 
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Qty.HeaderText = "Quantity";
            this.Qty.MinimumWidth = 11;
            this.Qty.Name = "Qty";
            // 
            // UnitPrice
            // 
            this.UnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnitPrice.HeaderText = "UnitPrice";
            this.UnitPrice.MinimumWidth = 11;
            this.UnitPrice.Name = "UnitPrice";
            // 
            // TotalRowPrice
            // 
            this.TotalRowPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalRowPrice.HeaderText = "Total Product Price";
            this.TotalRowPrice.MinimumWidth = 11;
            this.TotalRowPrice.Name = "TotalRowPrice";
            this.TotalRowPrice.ReadOnly = true;
            // 
            // textDiscountAmount
            // 
            this.textDiscountAmount.Location = new System.Drawing.Point(1258, 537);
            this.textDiscountAmount.Name = "textDiscountAmount";
            this.textDiscountAmount.Size = new System.Drawing.Size(92, 36);
            this.textDiscountAmount.TabIndex = 3;
            this.textDiscountAmount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1040, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Discount Amount";
            // 
            // textShippingCost
            // 
            this.textShippingCost.Location = new System.Drawing.Point(1258, 609);
            this.textShippingCost.Name = "textShippingCost";
            this.textShippingCost.Size = new System.Drawing.Size(92, 36);
            this.textShippingCost.TabIndex = 4;
            this.textShippingCost.Text = "0";
            // 
            // SalesOrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2409, 1058);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SalesOrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SalesOrderDetailsForm";
            this.TopMost = true;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderRowsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textShippingCost;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label productDts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox textPayment;
        private System.Windows.Forms.ComboBox customerIdText;
        private System.Windows.Forms.DataGridView orderRowsGrid;
        private System.Windows.Forms.TextBox textTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textDiscountAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalRowPrice;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button calCostBtn;
        private System.Windows.Forms.DateTimePicker deliveryDate;
    }
}