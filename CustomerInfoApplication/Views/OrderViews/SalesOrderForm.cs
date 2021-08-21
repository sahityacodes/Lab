using System;
using BusinessEntityLayer.Model;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using CustomerInfoApplication.Controllers;
using BusinessLogic.Exceptions;
using System.Collections.Generic;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class SalesOrderForm : Form
    {
        OrderController orderController = new OrderController();
        bool SortCounter = true;
        public SalesOrderForm()
        {
            InitializeComponent();
        }

        private void SalesOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadGrid(orderController.GetAll());
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.Message);
                MessageBox.Show("Error while fetching Order information");
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchBox.Text != null || searchBox.Text.Length != 0)
                {
                    orderGrid.Rows.Clear();
                    foreach (SalesOrders order in orderController.GetOneByName(searchBox.Text))
                    {
                        foreach (SalesOrdersRows row in order.OrderRows)
                        {
                            orderGrid.Rows.Add(new object[]{order.OrderID,
                          order.CustomerID, order.DateOrder, order.Payment ?? "",  row.RowID, row.ProductCode,
                            row.Qty, row.UnitPrice, row.TotalRowPrice, order.OrderSummary.ShippingCost,order.OrderSummary.DiscountAmount,order.OrderSummary.TotalOrder, order.OrderSummary.DeliveryDate,order.OrderSummary.ShippingAddress });
                        }
                    }
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.Message);
                MessageBox.Show("Error in the system.");
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            SalesOrderDetailsForm detailsForm = new();
            detailsForm.InitializeFormValues(new SalesOrders());
            detailsForm.InitializeFormElements(true);
            DialogResult dialog = detailsForm.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                InsertOrder(detailsForm.getSaleOrderInfo());
            }
            else
            {
                detailsForm.Close();
            }
        }

       

        private void ReloadGrid(List<SalesOrders> orderList)
        {
            addBtn.Enabled = true;
            orderGrid.Rows.Clear();
            foreach (SalesOrders order in orderList)
            {
                foreach (SalesOrdersRows row in order.OrderRows)
                {
                    orderGrid.Rows.Add(new object[]{order.OrderID,
                          order.CustomerID, order.DateOrder, order.Payment ?? "",  row.RowID, row.ProductCode,
                            row.Qty, row.UnitPrice, row.TotalRowPrice, order.OrderSummary.ShippingCost,order.OrderSummary.DiscountAmount,order.OrderSummary.TotalOrder,  order.OrderSummary.DeliveryDate,order.OrderSummary.ShippingAddress
                });
                }
            }
        }

        public void UpdateOrder(SalesOrders orders)
        {
            try
            {
                if (orderController.UpdateOne(orders))
                {
                    DialogResult dialog = MessageBox.Show("Updated Successfully");
                    ReloadGrid(orderController.GetAll());
                }
            }
            catch (BusinessLogicException ud)
            {
                MessageBox.Show(ud.Message);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                MessageBox.Show("Error in the system.");
            }
        }

        private void orderGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 15)
            {
                SalesOrderDetailsForm detailsForm = new();
                int OrderID = Convert.ToInt32(orderGrid.CurrentRow.Cells[0].Value);
                SalesOrders originalOrder = orderController.GetOne(OrderID);
                detailsForm.InitializeFormValues(originalOrder);
                detailsForm.InitializeFormElements(false);
                DialogResult dialog = detailsForm.ShowDialog();
                if (dialog == DialogResult.OK)
                {
                    SalesOrders updatedOrder = detailsForm.getSaleOrderInfo();
                    updatedOrder.OrderID = OrderID;
                    for(int i=0;i<originalOrder.OrderRows.Count; i++)
                    {
                        updatedOrder.OrderRows[i].RowID = originalOrder.OrderRows[i].RowID;
                    }
                    UpdateOrder(updatedOrder);
                }
                else
                {
                    detailsForm.Close();
                }
            }
            if (e.RowIndex > -1 && e.ColumnIndex == 14)
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Delete Order?", "Delete Record", MessageBoxButtons.OKCancel);
                    if (dialog == DialogResult.OK)
                    {
                       if (orderController.DeleteAll(Convert.ToInt32(orderGrid.Rows[e.RowIndex].Cells[0].Value)))
                        {
                            MessageBox.Show("Deleted Successfully");
                            ReloadGrid(orderController.GetAll());
                        } 
                       /* if (orderController.DeleteOne(Convert.ToInt32(orderGrid.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(orderGrid.Rows[e.RowIndex].Cells[4].Value)))
                        {
                            MessageBox.Show("Deleted Successfully");
                            ReloadGrid();
                        } */
                    }
                }
                catch (Exception io)
                {
                    Debug.WriteLine("Error in btnDel_Click", io.Message);
                    MessageBox.Show("Error in the system.");
                }
            }

        }

        private void orderGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 ||e.ColumnIndex == 11 || e.ColumnIndex == 12)
            {
                if (SortCounter)
                {
                    SortCounter = false;
                    ReloadGrid(orderController.SortByColumnAscending(Convert.ToString(e.ColumnIndex)));
                }
                else
                {
                    SortCounter = true;
                    ReloadGrid(orderController.SortByColumnDescending(Convert.ToString(e.ColumnIndex)));
                }
            }
        }
    }
}
