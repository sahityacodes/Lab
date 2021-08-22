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
using CustomerInfoApplication.Controllers;
using BusinessLogic.Exceptions;
using CustomerInfoApplication.Validators;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class SalesOrderDetailsForm : XtraForm
    {
        OrderController orderController = new();


        public SalesOrderDetailsForm()
        {
            InitializeComponent();
        }

        public void InitializeFormValues(SalesOrders orders)
        {
            customerIdText.Text = Convert.ToString(orders.CustomerID);
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
            decimal costs = 0;
            foreach (DataGridViewRow row in orderRowsGrid.Rows)
            {
                decimal Qty = Convert.ToDecimal(row.Cells[2].Value);
                decimal UnitPrice = Convert.ToDecimal(row.Cells[3].Value);
                row.Cells[4].Value = orderController.CalculateTotalUnitCost(Qty, UnitPrice);
                costs = orderRowsGrid.Rows
                        .OfType<DataGridViewRow>()
                        .Select(r => Convert.ToDecimal(r.Cells[4].Value))
                        .ToList().Sum();
            }
            textTotalAmount.Text = Convert.ToString(orderController.CalculateTotalCost(costs, textDiscountAmount.Text.Length > 0 ? Convert.ToDecimal(textDiscountAmount.Text) : 0,
                                        textShippingCost.Text.Length > 0 ? Convert.ToDecimal(textShippingCost.Text) : 0));
        }

        private void Save_Click(object sender, EventArgs e)
        {
            OrderValidator orderValidator = new();
            SalesOrders order = getSaleOrderInfo();
            try
            {
                if (orderValidator.ValidateOrder(order) && orderController.ValidateOrder(order))
                {
                    Save.DialogResult = DialogResult.OK;
                }
            }
            catch (BusinessLogicException ud)
            {
                MessageBox.Show(ud.Message);
            }
        }
    }
}