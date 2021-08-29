using BusinessEntityLayer.Model;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using DevExpress.XtraBars.Ribbon;
using BusinessLogic.Interfaces;
using BusinessLogic.Implementation.CustomerLogic;
using System.Data.SqlClient;

namespace CustomerInfoApplication.Views.CustomerViews
{
    public partial class CustomerInformationForm : RibbonForm
    {
        readonly ICustomerBLL<Customer> CustomerBal = new CustomerBAL();
        bool SortCounter = true;

        public CustomerInformationForm()
        {
            InitializeComponent();
        }

        private void LoadGrid(List<Customer> custlist)
        {
            customerGrid.Rows.Clear();
            foreach (Customer customer in custlist)
            {
                customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
            }
        }
        private void CustomerInformationForm_Load(object sender, EventArgs e)
        {
            FetchAllRecords();
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchBox.Text != null || searchBox.Text.Length != 0)
                {
                    LoadGrid(CustomerBal.GetOneByName(searchBox.Text));
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.Message);
                Debug.WriteLine("Error in searchBox_TextChanged", io);
                MessageBox.Show("Error in the system.");
            }
        }

        private void FetchAllRecords()
        {
            try
            {
                LoadGrid(CustomerBal.GetAll());
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.StackTrace);
                MessageBox.Show("Error while fetching data");
            }
        }

        private void customerGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 6)
            {
                try
                {
                    if (SortCounter)
                    {
                        SortCounter = false;
                        LoadGrid(CustomerBal.SortByColumnAscending(Convert.ToString(e.ColumnIndex)));
                    }
                    else if (!SortCounter)
                    {
                        LoadGrid(CustomerBal.SortByColumnDescending(Convert.ToString(e.ColumnIndex)));
                        SortCounter = true;
                    }
                }
                catch (Exception io)
                {
                    Debug.WriteLine(io.StackTrace);
                    MessageBox.Show("Error while fetching data");
                }
            }
        }
        private Customer RowToObject(DataGridViewRow customerGridRow)
        {
            Customer cust = new();
            cust.Id = Convert.ToInt32(customerGridRow.Cells[0].Value.ToString().Trim());
            cust.Name = customerGridRow.Cells[1].Value.ToString().Trim();
            cust.VAT = customerGridRow.Cells[2].Value.ToString().Trim();
            cust.Phone = customerGridRow.Cells[3].Value.ToString().Trim();
            cust.Address = customerGridRow.Cells[4].Value.ToString().Trim();
            cust.City = customerGridRow.Cells[5].Value.ToString().Trim();
            cust.AnnualRevenue = Convert.ToDecimal(customerGridRow.Cells[6].Value.ToString().Trim());
            return cust;
        }

     /*   private void customerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 8)
            {
                CustomerUpdateForm updateForm = new();
                updateForm.initializeForm(true, true, RowToObject(customerGrid.Rows[e.RowIndex]));
                DialogResult dialog = updateForm.ShowDialog();
                if (dialog == DialogResult.OK)
                {
                    UpdateCustomer(updateForm.getCustomerData());
                }
                else
                {
                    updateForm.Close();
                }
            }
            if (e.RowIndex > -1 && e.ColumnIndex == 7)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult dialog = MessageBox.Show("Are you sure you want to delete?", "Delete Record", buttons);
                if (dialog == DialogResult.Yes)
                {
                    DeleteCustomer(Convert.ToInt32(customerGrid.Rows[e.RowIndex].Cells[0].Value.ToString()));
                }

            }
        } */

        private void DeleteCustomer(int ID)
        {
            try
            {
                if (CustomerBal.DeleteAll(ID))
                {
                    MessageBox.Show("Deleted Successfully");
                    FetchAllRecords();
                }
            }
            catch (SqlException sqlExc)
            {
                Debug.WriteLine(sqlExc.Message);
                if (sqlExc.Number == 547)
                {
                    MessageBox.Show("Customer has orders, please delete the orders first to proceed.");
                }
                else
                {
                    MessageBox.Show("Error in the System");
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine("Error in btnDel_Click", io.Message);
                MessageBox.Show("Error in the system.");
            }
        }

        private void InsertCustomer(Customer customer)
        {
            try
            {
                if (CustomerBal.InsertOne(customer))
                {
                    DialogResult dialog = MessageBox.Show("Inserted Successfully");
                    add.Enabled = true;
                    FetchAllRecords();
                }
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Number == 2627)
                {
                    MessageBox.Show("VAT already present in the system.");
                }
                else throw;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                MessageBox.Show("Error in the system.");
            }
        }

        private void UpdateCustomer(Customer customer)
        {
            try
            {
                if (CustomerBal.InsertOne(customer))
                {
                    DialogResult dialog = MessageBox.Show("Updated Successfully");
                    FetchAllRecords();
                }
            }
            catch (SqlException sqlExc)
            {
                if (sqlExc.Number == 2627)
                {
                    MessageBox.Show("VAT already present in the system.");
                }
                else throw;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                MessageBox.Show("Error in the system.");
            }
        }

        private void add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomerUpdateForm updateForm = new();
            updateForm.initializeForm(false, false, new Customer());
            DialogResult dialog = updateForm.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                InsertCustomer(updateForm.getCustomerData());
            }
            else
            {
                updateForm.Close();
            }
        }

        private void edit_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomerUpdateForm updateForm = new();
            updateForm.initializeForm(true, true, RowToObject(customerGrid.CurrentRow));
            DialogResult dialog = updateForm.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                UpdateCustomer(updateForm.getCustomerData());
            }
            else
            {
                updateForm.Close();
            }
        }

        private void delClicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult dialog = MessageBox.Show("Are you sure you want to delete?", "Delete Record", buttons);
            if (dialog == DialogResult.Yes)
            {
                DeleteCustomer(Convert.ToInt32(customerGrid.CurrentRow.Cells[0].Value.ToString()));
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
