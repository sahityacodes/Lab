using System;
using BusinessEntityLayer.Model;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementation.OrderLogic;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class SalesOrderForm : RibbonForm
    {
        readonly IOrderBLL<SalesOrders> OrderBal = new OrderBAL();
        bool SortCounter = true;
        public SalesOrderForm()
        {
            InitializeComponent();
        }

        private void SalesOrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadGrid(OrderBal.GetAll());
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
                    ReloadGrid(OrderBal.GetOneByName(searchBox.Text));
                    /* orderGrid.Rows.Clear();
                     foreach (SalesOrders order in OrderBal.GetOneByName(searchBox.Text))
                     {
                         foreach (SalesOrdersRows row in order.OrderRows)
                         {
                             orderGrid.Rows.Add(new object[]{order.OrderID,
                           order.CustomerID, order.DateOrder, order.Payment ?? "",  row.RowID, row.ProductCode,
                             row.Qty, row.UnitPrice, row.TotalRowPrice, order.OrderSummary.ShippingCost,order.OrderSummary.DiscountAmount,order.OrderSummary.TotalOrder, order.OrderSummary.DeliveryDate,order.OrderSummary.ShippingAddress });
                         }
                     } */
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.Message);
                MessageBox.Show("Error in the system.");
            }
        }

        private void ReloadGrid(List<SalesOrders> orderList)
        {
            orderGrid.Rows.Clear();
            foreach (SalesOrders order in orderList)
            {
               
                    orderGrid.Rows.Add(new object[]{order.OrderID,
                          order.CustomerID, "", order.DateOrder, order.OrderSummary.TotalOrder,  order.OrderSummary.DeliveryDate,order.OrderSummary.ShippingAddress
                });
            }
        }

        public void UpdateOrder(SalesOrders orders)
        {
            try
            {
                if (OrderBal.UpdateOne(orders))
                {
                    DialogResult dialog = MessageBox.Show("Updated Successfully");
                    ReloadGrid(OrderBal.GetAll());
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                MessageBox.Show("Error in the system.");
            }
        }
        public void InsertOrder(SalesOrders orders)
        {
            try
            {
                if (OrderBal.InsertOne(orders))
                {
                    DialogResult dialog = MessageBox.Show("Inserted Successfully");
                    ReloadGrid(OrderBal.GetAll());
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                MessageBox.Show("Error in the system.");
            }
        }
        private void orderGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 3 ||e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                if (SortCounter)
                {
                    SortCounter = false;
                    ReloadGrid(OrderBal.SortByColumnAscending(Convert.ToString(e.ColumnIndex)));
                }
                else
                {
                    SortCounter = true;
                    ReloadGrid(OrderBal.SortByColumnDescending(Convert.ToString(e.ColumnIndex)));
                }
            }
        }

        private void add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SalesOrderDetailsForm detailsForm = new();
            int OrderID = Convert.ToInt32(orderGrid.CurrentRow.Cells[0].Value);
            SalesOrders originalOrder = OrderBal.GetOne(OrderID);
            detailsForm.InitializeFormValues(originalOrder);
            detailsForm.InitializeFormElements(false);
            DialogResult dialog = detailsForm.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                SalesOrders updatedOrder = detailsForm.getSaleOrderInfo();
                updatedOrder.OrderID = OrderID;
                for (int i = 0; i < originalOrder.OrderRows.Count; i++)
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

        private void delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Delete Order?", "Delete Record", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.OK)
            {
                if (OrderBal.DeleteAll(Convert.ToInt32(orderGrid.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Deleted Successfully");
                    ReloadGrid(OrderBal.GetAll());
                }
                /* if (orderController.DeleteOne(Convert.ToInt32(orderGrid.Rows[e.RowIndex].Cells[0].Value), Convert.ToInt32(orderGrid.Rows[e.RowIndex].Cells[4].Value)))
                 {
                     MessageBox.Show("Deleted Successfully");
                     ReloadGrid();
                 } */
            }
        }
    }
}
