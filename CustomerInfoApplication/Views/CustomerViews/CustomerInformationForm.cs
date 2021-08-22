using BusinessEntityLayer.Model;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using BusinessLogic.Exceptions;
using System.Data.SqlClient;
using CustomerInfoApplication.Controllers;
using System.Collections.Generic;

namespace CustomerInfoApplication.Views.CustomerViews
{
    public partial class CustomerInformationForm : Form
    {
        readonly CustomerController custController = new();
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
                    LoadGrid(custController.GetOneByName(searchBox.Text));
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
                LoadGrid(custController.GetAll());
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
                        LoadGrid(custController.SortByColumnAscending(Convert.ToString(e.ColumnIndex)));
                    }
                    else if (!SortCounter)
                    {
                        LoadGrid(custController.SortByColumnDescending(Convert.ToString(e.ColumnIndex)));
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = false;
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

        private void customerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
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
        }

        private void DeleteCustomer(int ID)
        {
            try
            {
                if (custController.DeleteCustomer(ID))
                {
                    MessageBox.Show("Deleted Successfully");
                    FetchAllRecords();
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
                if (custController.InsertCustomer(customer))
                {
                    DialogResult dialog = MessageBox.Show("Inserted Successfully");
                    FetchAllRecords();
                }
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
                if (custController.UpdateCustomer(customer))
                {
                    DialogResult dialog = MessageBox.Show("Updated Successfully");
                    FetchAllRecords();
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                MessageBox.Show("Error in the system.");
            }
        }
    }
}
