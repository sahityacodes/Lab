using System;
using BusinessLogic.Implementation.OrderLogic;
using BusinessEntityLayer.Model;
using BusinessLogic.Interfaces;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Exceptions;
using BusinessLogic.Implementation.CustomerLogic;
using DevExpress.XtraBars;
using System.Windows.Controls;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class SalesOrderDetailForm : DevExpress.XtraEditors.XtraForm
    {

        readonly IOrderBLL<SalesOrders> OrderBal = new OrderBAL();
        readonly ICustomerBLL<Customer> CustomerBal = new CustomerBAL();
        public SalesOrderDetailForm()
        {
            InitializeComponent();
        }
        public void InitializeFormValues(SalesOrders orders)
        {
            customerID.Text = Convert.ToString(orders.CustomerID);
            datePicker.Value = orders.DateOrder;
            textPayment.Text = Convert.ToString(orders.Payment) ?? "";
            textAddress.Text = Convert.ToString(orders.OrderSummary.ShippingAddress) ?? "";
            textShippingCost.Text = Convert.ToString(orders.OrderSummary.ShippingCost) ?? "";
            deliveryDate.Value = orders.OrderSummary.DeliveryDate;
            textDiscountAmount.Text = Convert.ToString(orders.OrderSummary.DiscountAmount) ?? "";
            textTotalAmount.Text = Convert.ToString(orders.OrderSummary.TotalOrder) ?? "";
            foreach (SalesOrdersRows row in orders.OrderRows)
            {
                orderRowsGrid.Rows.Add(row.ProductCode, row.Description, row.Qty, row.UnitPrice, row.TotalRowPrice);
            }

        }

        public void InitializeFormElements(bool enable)
        {
            if (enable)
            {
                pictureBox1.Enabled = true;
                pictureBox1.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            orderRowsGrid.Rows.Add();
        }

        public SalesOrders getSaleOrderInfo()
        {
            List<SalesOrdersRows> rows = new();
            foreach (DataGridViewRow row in orderRowsGrid.Rows)
            {
                if (Convert.ToString(row.Cells[0].EditedFormattedValue) != "" && Convert.ToString(row.Cells[2].EditedFormattedValue) != "" &&
                       Convert.ToString(row.Cells[3].EditedFormattedValue) != "")
                {
                    rows.Add(new SalesOrdersRows
                    {
                        ProductCode = Convert.ToString(row.Cells[0].EditedFormattedValue),
                        Description = row.Cells[1].Value.ToString(),
                        Qty = Convert.ToDecimal(row.Cells[2].EditedFormattedValue),
                        UnitPrice = Convert.ToDecimal(row.Cells[3].EditedFormattedValue),
                        TotalRowPrice = row.Cells[4].EditedFormattedValue != "" ? Convert.ToDecimal(row.Cells[4].EditedFormattedValue) : 0
                    });
                }
            }
            SalesOrders salesOrder = new SalesOrders
            {
                CustomerID = Convert.ToInt32(customerID.Text),
                DateOrder = Convert.ToDateTime(datePicker.Value),
                Payment = textPayment.Text,
                OrderRows = rows,
                OrderSummary = new SalesOrdersTail
                {
                    ShippingAddress = textAddress.Text,
                    ShippingCost = textShippingCost.Text.Length > 0 ? Convert.ToDecimal(textShippingCost.Text) : 0,
                    DeliveryDate = Convert.ToDateTime(deliveryDate.Value),
                    DiscountAmount = textDiscountAmount.Text.Length > 0 ? Convert.ToDecimal(textDiscountAmount.Text) : 0,
                    TotalOrder = textTotalAmount.Text.Length > 0 ? Convert.ToDecimal(textTotalAmount.Text) : 0,
                }
            };
            return salesOrder;
        }

        private void orderRowsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calculatecosts();
        }

        private void calculatecosts()
        {
            List<decimal> costs = new();
            if (orderRowsGrid.CurrentRow != null)
            {
                decimal Qty = Convert.ToDecimal(orderRowsGrid.CurrentRow.Cells[2].Value);
                decimal UnitPrice = Convert.ToDecimal(orderRowsGrid.CurrentRow.Cells[3].Value);
                orderRowsGrid.CurrentRow.Cells[4].Value = OrderBal.CalculateTotalUnitCost(Qty, UnitPrice);
                costs = orderRowsGrid.Rows
                        .OfType<DataGridViewRow>()
                        .Select(r => Convert.ToDecimal(r.Cells[4].Value))
                        .ToList();
            }
            textTotalAmount.Text = Convert.ToString(OrderBal.CalculateTotalCost(costs, textDiscountAmount.Text.Length > 0 ? Convert.ToDecimal(textDiscountAmount.Text) : 0,
                                        textShippingCost.Text.Length > 0 ? Convert.ToDecimal(textShippingCost.Text) : 0));

        }
        private void Save_Click(object sender, EventArgs e)
        {
            IOrderBLL<SalesOrders> OrderBal = new OrderBAL();
            SalesOrders order = getSaleOrderInfo();
            try
            {
                if (OrderBal.ValidateOrder(order))
                {
                    Save.DialogResult = DialogResult.OK;
                }
            }
            catch (BusinessLogicException ud)
            {
                MessageBox.Show(ud.Message);
            }
        }

        private void customerID_TextUpdate(object sender, EventArgs e)
        {
            customerID.DroppedDown = true;
            customerID.Items.Clear();
            customerID.Items.AddRange(CustomerBal.GetOneByName(customerID.Text).Select(o => o.Id + " - " + o.Name).
                                          ToArray());
        }

        private void textShippingCost_Leave(object sender, EventArgs e)
        {
            calculatecosts();
        }

        private void textDiscountAmount_Leave(object sender, EventArgs e)
        {
            calculatecosts();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            IImportFeature<List<SalesOrdersRows>> fileToObj = new FileToObjectExcel();
            SalesOrders originalOrder = new();
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalOrder.OrderRows = fileToObj.ConvertExcelToObject(openFileDialog.FileName);
                originalOrder.OrderSummary.TotalOrder = OrderBal.CalculateTotalCost(originalOrder.OrderRows.Select(o => o.TotalRowPrice).ToList(), originalOrder.OrderSummary.DiscountAmount, originalOrder.OrderSummary.ShippingCost);
                InitializeFormValues(originalOrder);
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            IImportFeature<List<SalesOrdersRows>> fileToObj = new FileToObjectExcel();
            SalesOrders originalOrder = new();
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Text|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalOrder.OrderRows = fileToObj.ConvertTextFileToObject(openFileDialog.FileName);
                originalOrder.OrderSummary.TotalOrder = OrderBal.CalculateTotalCost(originalOrder.OrderRows.Select(o => o.TotalRowPrice).ToList(), originalOrder.OrderSummary.DiscountAmount, originalOrder.OrderSummary.ShippingCost);
                InitializeFormValues(originalOrder);
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClipboardForm clipboardForm = new();
            IImportFeature<List<SalesOrdersRows>> fileToObj = new FileToObjectExcel();
            SalesOrders originalOrder = new();
            OpenFileDialog openFileDialog = new();
            if (clipboardForm.ShowDialog(this) == DialogResult.OK)
            {
                originalOrder.OrderRows = fileToObj.ConvertClipboardDataToObject(clipboardForm.getPastedData());
                originalOrder.OrderSummary.TotalOrder = OrderBal.CalculateTotalCost(originalOrder.OrderRows.Select(o => o.TotalRowPrice).ToList(), originalOrder.OrderSummary.DiscountAmount, originalOrder.OrderSummary.ShippingCost);
                InitializeFormValues(originalOrder);
            }
        }
    }
}