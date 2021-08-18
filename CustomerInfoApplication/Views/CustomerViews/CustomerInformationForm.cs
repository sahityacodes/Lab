using BusinessEntityLayer.Model;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using BusinessLogic.Exceptions;
using System.Data.SqlClient;
using CustomerInfoApplication.Controllers;

namespace CustomerInfoApplication.Views.CustomerViews
{
    public partial class CustomerInformationForm : Form
    {
        CustomerController custController = new();
        bool SortCounter = true;    

        public CustomerInformationForm()
        {
            InitializeComponent();
        }

        private void CustomerInformationForm_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Customer customer in custController.GetAll())
                {
                    customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.StackTrace);
                MessageBox.Show("Error while fetching data");
            }
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (searchBox.Text != null || searchBox.Text.Length != 0)
                {
                    customerGrid.Rows.Clear();
                    foreach (Customer customer in custController.GetOneByName(searchBox.Text))
                    {
                        customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                    }
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.Message);
                Debug.WriteLine("Error in searchBox_TextChanged", io);
                MessageBox.Show("Error in the system.");
            }
        }

        private void UpdateFormClosing()
        {
            addBtn.Enabled = true;
            customerGrid.Rows.Clear();
            foreach (Customer customer in custController.GetAll())
            {
                customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
            }
        }

        private void customerGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 6)
            {
                if (SortCounter)
                {
                    SortCounter = false;
                    customerGrid.Rows.Clear();
                    foreach (Customer customer in custController.SortByColumnAscending("Id"))
                    {
                        customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                    }
                }
                else if (!SortCounter)
                {
                    customerGrid.Rows.Clear();
                    foreach (Customer customer in custController.SortByColumnDescending(Convert.ToString(customerGrid.Columns[e.ColumnIndex].HeaderText)))
                    {
                        customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                    }
                    SortCounter = true;
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
                try
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult dialog = MessageBox.Show("Are you sure you want to delete?", "Delete Record", buttons);
                    if (dialog == DialogResult.Yes)
                    {
                        if (custController.DeleteCustomer(Convert.ToInt32(customerGrid.Rows[e.RowIndex].Cells[0].Value.ToString())))
                        {
                            MessageBox.Show("Deleted Successfully");
                            customerGrid.Rows.Clear();
                            foreach (Customer customer in custController.SortByColumnAscending("Id"))
                            {
                                Debug.WriteLine(customer.Name, customer.VAT, customer.Phone, customer.Address, customer.City, customer.AnnualRevenue);
                                customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                            }
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

        public void InsertCustomer(Customer customer)
        {
            try
            {
                if (custController.InsertCustomer(customer))
                {
                    DialogResult dialog = MessageBox.Show("Inserted Successfully");
                    UpdateFormClosing();
                }
            }
            catch (UserDefinedException ud)
            {
                MessageBox.Show(ud.Message);
            }
            catch (SqlException sqlExc)
            {
                Debug.WriteLine(sqlExc.Message);
                if (sqlExc.Number == 2627)
                {
                    MessageBox.Show("VAT already present in the system.");
                }
                else
                {
                    MessageBox.Show("Error in the System");
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                MessageBox.Show("Error in the system.");
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                if (custController.UpdateCustomer(customer))
                {
                    DialogResult dialog = MessageBox.Show("Updated Successfully");
                    UpdateFormClosing();
                }
            }
            catch (UserDefinedException ude)
            {
                MessageBox.Show(ude.Message);
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
                Debug.WriteLine(exc.StackTrace);
                MessageBox.Show("Error in the system.");
            }
        }
    }
}
