using DevExpress.XtraEditors;
using System;
using BusinessLogic.Implementation.CustomerLogic;
using BusinessLogic.Implementation.OrderLogic;
using BusinessEntityLayer.Model;
using BusinessLogic.Interfaces;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class SalesOrderDetailsForm : XtraForm
    {
        ICustomerBLL<Customer> CustomerBal = new CustomerBAL();
        IOrderBLL<SalesOrders> OrderBal = new OrderBAL();

        public SalesOrderDetailsForm()
        {
            InitializeComponent();
        }

        public void InitializeFormValues(SalesOrders orders)
        {
            customerIdText.ValueMember = Convert.ToString(orders.CustomerID) ?? "";
            datePicker.Value = orders.DateOrder;
            textPayment.Text = Convert.ToString(orders.Payment) ?? "";
            textAddress.Text = Convert.ToString(orders.OrderSummary.ShippingAddress) ?? "";
            textShippingCost.Text = Convert.ToString(orders.OrderSummary.ShippingCost) ?? "";
            deliveryDate.Value = orders.OrderSummary.DeliveryDate;
            textDiscountAmount.Text = Convert.ToString(orders.OrderSummary.DiscountAmount) ?? "";
            textTotalAmount.Text = Convert.ToString(orders.OrderSummary.TotalOrder) ?? "";
            foreach ( SalesOrdersRows row in orders.OrderRows)
            {
                orderRowsGrid.Rows.Add(row.ProductCode,row.Description, row.Qty,row.UnitPrice, row.TotalRowPrice);
            }

        }

        public void InitializeFormElements(bool enable)
        {
            if (!enable)
            {
                customerIdText.Enabled = false;
                datePicker.Enabled = false;
                textPayment.Enabled = false;
                textAddress.Enabled = false;
                textShippingCost.Enabled = false;
                deliveryDate.Enabled = false;
                textDiscountAmount.Enabled = false;
                textTotalAmount.Enabled = false;
                orderRowsGrid.Enabled = false;
            }
        }

        private void customerIdText_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                customerIdText.Items.Clear();
                customerIdText.Items.AddRange(CustomerBal.SortByColumnAscending("Id").Select(o => Convert.ToString(o.Id)).ToArray());
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.StackTrace);
                MessageBox.Show("Error while fetching Customer Data");
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
                CustomerID = Convert.ToInt32(customerIdText.Text),
                DateOrder = Convert.ToDateTime(datePicker.Value),
                Payment = textPayment.Text,
                OrderRows = rows,
                OrderSummary = new SalesOrdersTail
                {
                    ShippingAddress = textAddress.Text,
                    ShippingCost = textShippingCost.Text.Length > 0? Convert.ToDecimal(textShippingCost.Text): 0,
                    DeliveryDate = Convert.ToDateTime(deliveryDate.Value),
                    DiscountAmount = textDiscountAmount.Text.Length > 0 ? Convert.ToDecimal(textDiscountAmount.Text) : 0,
                    TotalOrder = textTotalAmount.Text.Length > 0 ? Convert.ToDecimal(textTotalAmount.Text) : 0,
                }
            };
            return salesOrder;
        }

        private void calCostBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in orderRowsGrid.Rows)
            {
                string Qty = Convert.ToString(row.Cells[2].Value);
                string UnitPrice = Convert.ToString(row.Cells[3].Value);
                if (Qty.Length > 0 && UnitPrice.Length > 0)
                    row.Cells[4].Value = OrderBal.CalculateTotalUnitCost(Convert.ToDecimal(Qty), Convert.ToDecimal(UnitPrice));
                decimal costs = orderRowsGrid.Rows
                        .OfType<DataGridViewRow>()
                        .Select(r => Convert.ToDecimal(r.Cells[4].Value))
                        .ToList().Sum();
                textTotalAmount.Text = Convert.ToString(OrderBal.CalculateTotalCost(costs, textDiscountAmount.Text.Length > 0 ? Convert.ToDecimal(textDiscountAmount.Text) : 0,
                                        textShippingCost.Text.Length > 0 ? Convert.ToDecimal(textShippingCost.Text) : 0));
            }

        }
    }
}