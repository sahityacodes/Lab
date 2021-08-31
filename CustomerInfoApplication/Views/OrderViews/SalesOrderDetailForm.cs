﻿using System;
using BusinessLogic.Implementation.OrderLogic;
using BusinessEntityLayer.Model;
using BusinessLogic.Interfaces;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Exceptions;
using BusinessLogic.Implementation.CustomerLogic;
using DevExpress.XtraBars;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class SalesOrderDetailForm : DevExpress.XtraEditors.XtraForm
    {

        IOrderBLL<SalesOrders> OrderBal = new OrderBAL();
        ICustomerBLL<Customer> CustomerBal = new CustomerBAL();
        public SalesOrderDetailForm()
        {
            InitializeComponent();
        }
        public void InitializeFormValues(SalesOrders orders)
        {
            customerName.Text = Convert.ToString(orders.CustomerID);
            datePicker.Value = orders.DateOrder;
            textPayment.Text = Convert.ToString(orders.Payment) ?? "";
            textAddress.Text = Convert.ToString(orders.OrderSummary.ShippingAddress) ?? "";
            textShippingCost.Text = Convert.ToString(orders.OrderSummary.ShippingCost) ?? "";
            deliveryDate.Value = orders.OrderSummary.DeliveryDate;
            textDiscountAmount.Text = Convert.ToString(orders.OrderSummary.DiscountAmount) ?? "";
            textTotalAmount.Text = Convert.ToString(orders.OrderSummary.TotalOrder) ?? "";
            setRows(orders.OrderRows);
        }
        private void setRows(List<SalesOrdersRows> rows)
        {
            foreach (SalesOrdersRows row in rows)
            {
                orderRowsGrid.Rows.Add(row.ProductCode, row.Description, row.Qty, row.UnitPrice, row.TotalRowPrice);
            }
        }
        private List<SalesOrdersRows> GetSalesOrdersRows()
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
            return rows;
        }
        public SalesOrders getSaleOrderInfo()
        {
            SalesOrders salesOrder = new();
            try
            {
                salesOrder = new SalesOrders
                {
                    CustomerID = customerName.Text.Split(" - ")[0].Length > 0 ? Convert.ToInt32(customerName.Text.Split(" - ")[0]) : 0,
                    DateOrder = Convert.ToDateTime(datePicker.Value),
                    Payment = textPayment.Text,
                    OrderRows = GetSalesOrdersRows(),
                    OrderSummary = new SalesOrdersTail
                    {
                        ShippingAddress = textAddress.Text,
                        ShippingCost = textShippingCost.Text.Length > 0 ? Convert.ToDecimal(textShippingCost.Text) : 0,
                        DeliveryDate = Convert.ToDateTime(deliveryDate.Value),
                        DiscountAmount = textDiscountAmount.Text.Length > 0 ? Convert.ToDecimal(textDiscountAmount.Text) : 0,
                        TotalOrder = textTotalAmount.Text.Length > 0 ? Convert.ToDecimal(textTotalAmount.Text) : 0,
                    }
                };
            }
            catch (FormatException)
            {
            }
            return salesOrder;
        }

        private void orderRowsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calculatecosts();
        }

        private void calculatecosts()
        {
            List<decimal> costs = new();
            try
            {
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
            catch (FormatException)
            {
            }
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
            SalesOrders importedRows = new();
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importedRows.OrderRows = fileToObj.ConvertExcelToObject(openFileDialog.FileName);
                importedRows.OrderRows.AddRange(GetSalesOrdersRows());
                orderRowsGrid.Rows.Clear();
                setRows(importedRows.OrderRows);
                calculatecosts();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            IImportFeature<List<SalesOrdersRows>> fileToObj = new FileToObjectExcel();
            SalesOrders importedRows = new();
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Text|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                importedRows.OrderRows = fileToObj.ConvertTextFileToObject(openFileDialog.FileName);
                importedRows.OrderRows.AddRange(GetSalesOrdersRows());
                orderRowsGrid.Rows.Clear();
                setRows(importedRows.OrderRows);
                calculatecosts();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClipboardForm clipboardForm = new();
            IImportFeature<List<SalesOrdersRows>> fileToObj = new FileToObjectExcel();
            SalesOrders importedRows = new();
            if (clipboardForm.ShowDialog(this) == DialogResult.OK)
            {
                importedRows.OrderRows = fileToObj.ConvertClipboardDataToObject(clipboardForm.getPastedData());
                importedRows.OrderRows.AddRange(GetSalesOrdersRows());
                setRows(importedRows.OrderRows);
                calculatecosts();
            }
        }

        private void deleteBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (orderRowsGrid.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in orderRowsGrid.SelectedRows)
                {
                    try
                    {
                        if (row.Index != -1)
                        {
                            orderRowsGrid.Rows.RemoveAt(row.Index);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                    }
                }
            }
        }

        private void orderRowsGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);
            if (orderRowsGrid.CurrentCell.ColumnIndex == 2 || orderRowsGrid.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textShippingCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void searchControl1_TextChanged(object sender, EventArgs e)
        {
            searchList.Visible = true;
            searchList.Items.Clear();
            foreach (Customer cust in CustomerBal.GetOneByName(searchControl1.Text))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = cust.Name;
                lvi.SubItems.Add(Convert.ToString(cust.Id));
                searchList.Items.Add(lvi);
            }
        }

        private void searchList_Click(object sender, EventArgs e)
        {
            if (searchList.SelectedItems.Count > 0)
            {
                ListViewItem customer = searchList.SelectedItems[0];
                searchControl1.Text = customer.Text;
                string txt = customer.SubItems[1].Text;
                customerName.Text = txt;
                searchList.Visible = false;
            }
        }
    }
}