using System;
using BusinessEntityLayer.Model;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementation.OrderLogic;
using System.Linq;
using DevExpress.XtraSplashScreen;
using System.Threading;
using CustomerInfoApplication.Views.Misc;
using System.Drawing;

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
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.Message);
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

        private void orderGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
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
            SalesOrderDetailForm detailsForm = new();
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
            SalesOrderDetailForm detailsForm = new();
            int OrderID = Convert.ToInt32(orderGrid.CurrentRow.Cells[0].Value);
            SalesOrders originalOrder = OrderBal.GetOne(OrderID);
            detailsForm.InitializeFormValues(originalOrder);
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
            }
        }

        private void importDropdown_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {
            IImportFeature<List<SalesOrdersRows>> fileToObj = new FileToObjectExcel();
            SalesOrderDetailForm detailsForm = new();
            SalesOrders originalOrder = new();
            OpenFileDialog openFileDialog = new();
            if (importDropdown.ItemIndex == 0)
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalOrder.OrderRows = fileToObj.ConvertExcelToObject(openFileDialog.FileName);
                    originalOrder.OrderSummary.TotalOrder = OrderBal.CalculateTotalCost(originalOrder.OrderRows.Select(o => o.TotalRowPrice).ToList(), originalOrder.OrderSummary.DiscountAmount, originalOrder.OrderSummary.ShippingCost);
                    detailsForm.InitializeFormValues(originalOrder);
                    //SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                    DialogResult dialog = detailsForm.ShowDialog();
                 /*   for (int i = 1; i <= 100; i++)
                    {
                        SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%");
                        Thread.Sleep(25);
                    }*/
                    
                }
            }
            else if (importDropdown.ItemIndex == 1)
            {
                openFileDialog.Filter = "Text|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalOrder.OrderRows = fileToObj.ConvertTextFileToObject(openFileDialog.FileName);
                    originalOrder.OrderSummary.TotalOrder = OrderBal.CalculateTotalCost(originalOrder.OrderRows.Select(o => o.TotalRowPrice).ToList(), originalOrder.OrderSummary.DiscountAmount, originalOrder.OrderSummary.ShippingCost);
                    detailsForm.InitializeFormValues(originalOrder);
                    DialogResult dialog = detailsForm.ShowDialog();
                }
            }
            else if (importDropdown.ItemIndex == 2)
            {
                ClipboardForm clipboardForm = new();
                if (clipboardForm.ShowDialog(this) == DialogResult.OK)
                {
                    originalOrder.OrderRows = fileToObj.ConvertClipboardDataToObject(clipboardForm.getPastedData());
                    originalOrder.OrderSummary.TotalOrder = OrderBal.CalculateTotalCost(originalOrder.OrderRows.Select(o => o.TotalRowPrice).ToList(), originalOrder.OrderSummary.DiscountAmount, originalOrder.OrderSummary.ShippingCost);
                    detailsForm.InitializeFormValues(originalOrder);
                    DialogResult dialog = detailsForm.ShowDialog();
                }
            }
        }
    }
}
