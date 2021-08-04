using BusinessEntityLayer.Model;
using BusinessLogic.Interfaces;
using BusinessLogic.CustomerInfoLogic;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace CustomerInfoApplication.Forms
{
    public partial class CustomerInformationForm : Form
    {
        readonly IBLL<Customer> CustomerBal = new CustomerBAL();
        bool SortCounter = true;

        public CustomerInformationForm()
        {
            InitializeComponent();
        }

        private void CustomerInformationForm_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Customer customer in CustomerBal.GetAll())
                {
                    customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine(io.StackTrace);
                Debug.WriteLine("Error in CustomerInformationForm_Load", io);
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
                    foreach (Customer customer in CustomerBal.GetOneByName(searchBox.Text))
                    {
                        customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                    }
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine("Error in searchBox_TextChanged", io);
                MessageBox.Show("Error in the system.");
            }
        }

        private void UpdateFormClosing(object sender, FormClosingEventArgs e)
        {
            addBtn.Enabled = true;
            customerGrid.Rows.Clear();
            foreach (Customer customer in CustomerBal.GetOneByName(searchBox.Text))
            {
                customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
            }
        }

        private void customerGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (SortCounter)
                {
                    customerGrid.Rows.Clear();
                    foreach (Customer customer in CustomerBal.SortByColumnAscending())
                    {
                        Debug.WriteLine(customer.Name, customer.VAT, customer.Phone, customer.Address, customer.City, customer.AnnualRevenue);
                        customerGrid.Rows.Add(new object[]{customer.Id,
                          customer.Name, customer.VAT, customer.Phone ?? "", customer.Address ?? "", customer.City ?? "", customer.AnnualRevenue });
                    }
                    SortCounter = false;
                }
                else
                {
                    customerGrid.Rows.Clear();
                    foreach (Customer customer in CustomerBal.SortByColumnDescending())
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
            UpdateForm updateForm = new();
            updateForm.Show();
            updateForm.label7.Visible = false;
            updateForm.txtID.Visible = false;
            updateForm.btnInsert.Visible = true;
            updateForm.btnSave.Visible = false;
            updateForm.FormClosing += new FormClosingEventHandler(UpdateFormClosing);
        }

        private void customerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 8)
            {
                UpdateForm updateForm = new();
                updateForm.showData(customerGrid.Rows[e.RowIndex]);
                updateForm.Show();
                updateForm.btnSave.Visible = true;
                updateForm.btnInsert.Visible = false;
                updateForm.FormClosing += new FormClosingEventHandler(UpdateFormClosing);
            }
            if (e.RowIndex > -1 && e.ColumnIndex == 7)
            {
                try
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult dialog = MessageBox.Show("Are you sure you want to delete?", "Delete Record", buttons);
                    if (dialog == DialogResult.Yes)
                    {
                        if (CustomerBal.DeleteOne(Convert.ToInt32(customerGrid.Rows[e.RowIndex].Cells[0].Value.ToString())))
                        {
                            MessageBox.Show("Deleted Successfully");
                            customerGrid.Rows.Clear();
                            foreach (Customer customer in CustomerBal.SortByColumnAscending())
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
    }
}
