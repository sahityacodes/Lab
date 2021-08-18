using System;
using BusinessEntityLayer.Model;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using CustomerInfoApplication.Controllers;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class SalesOrderForm : Form
    {
       // IBLL<SalesOrders> OrderBAL = new OrderBAL();
        OrderController orderController = new OrderController();
        public SalesOrderForm()
        {
            InitializeComponent();
        }

        private void SalesOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadGrid();
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
                Debug.WriteLine("Error in searchBox_TextChanged", io.StackTrace);
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

        private void InsertOrder(SalesOrders orders)
        {
            try
            {
                if (orderController.InsertOne(orders))
                {
                    DialogResult dialog = MessageBox.Show("Inserted Successfully");
                    ReloadGrid();
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                Debug.WriteLine(exc.StackTrace);
                MessageBox.Show("Error in the system.");
            }
        }

        private void ReloadGrid()
        {
            addBtn.Enabled = true;
            orderGrid.Rows.Clear();
            foreach (SalesOrders order in orderController.GetAll())
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
                    ReloadGrid();
                }
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
                DialogResult dialog = detailsForm.ShowDialog();
                if (dialog == DialogResult.OK)
                {
                    SalesOrders updatedOrder = detailsForm.getSaleOrderInfo();
                    updatedOrder.OrderID = OrderID;
                    int rowID = 1;
                    foreach (SalesOrdersRows updatedRow in updatedOrder.OrderRows)
                    {
                        if (originalOrder.OrderRows.Count > updatedOrder.OrderRows.Count)
                        {
                            updatedRow.RowID = originalOrder.OrderRows[rowID].RowID;
                        }
                        else
                        {
                            updatedRow.RowID = updatedOrder.OrderRows.Select(o => o.RowID).ToArray().Max() + 1;
                        }
                        rowID++;
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
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult dialog = MessageBox.Show("Are you sure you want to delete?", "Delete Record", buttons);
                    if (dialog == DialogResult.Yes)
                    {
                        if (orderController.DeleteOne(Convert.ToInt32(orderGrid.Rows[e.RowIndex].Cells[0].Value)))
                        {
                            MessageBox.Show("Deleted Successfully");
                            ReloadGrid();
                        }
                    }
                }
                catch (Exception io)
                {
                    Debug.WriteLine("Error in btnDel_Click", io.Message);
                    MessageBox.Show("Error in the system.");
                }
            }
        }
    }
}
