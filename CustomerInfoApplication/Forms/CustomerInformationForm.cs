using BusinessEntityLayer.Model;
using BusinessLogic.CustomerInfoLogic;
using System;
using System.Windows.Forms;

namespace CustomerInfoApplication.Forms
{
    public partial class CustomerInformationForm : Form
    {
        FormComponents _componentClass;
        Customer Customer = new();
        CustomerBAL CustomerBAL = new();

        public CustomerInformationForm()
        {
            InitializeComponent();
            _componentClass = new FormComponents(this);
        }

        private void CustomerInformationForm_Load(object sender, EventArgs e)
        {
            customerGrid.DataSource = CustomerBAL.GetCustomers();
            _componentClass.ChangeVisibility(false, false, false, true, true, false, false, true);
        }

        private void SearchByName_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null || textBox1.Text.Length != 0)
            {
                customerGrid.DataSource = CustomerBAL.GetCustomersByName(textBox1.Text);
            }
        }

        private void CustomerGrid_SelectionChanged(object sender, EventArgs e)
        {
            ShowCurrentClickedData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _componentClass.ChangeVisibility(true, true, true, false, false, false, true, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textID.Text = ((int)customerGrid.Rows[customerGrid.Rows.Count - 1].Cells[0].Value + 1).ToString();
            txtBoxName.Clear();
            contactPersonName.Clear();
            phone.Clear();
            _componentClass.ChangeVisibility(true, true, true, false, false, true, false, true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtBoxName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a Customer Name");
            }
            else
            {
                Customer.Id = int.Parse(textID.Text);
                Customer.CustomerName = txtBoxName.Text;
                Customer.ContactName = contactPersonName.Text;
                Customer.Phone = phone.Text;
                if (CustomerBAL.UpdateCustomer(Customer))
                {
                    MessageBox.Show("Updated Successfully");
                    customerGrid.DataSource = null;
                    customerGrid.DataSource = CustomerBAL.GetCustomers();
                }
                else
                {
                    MessageBox.Show("Failed to update");
                }
                _componentClass.ChangeVisibility(false, false, false, true, true, false, false, true);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtBoxName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a Customer Name");
            }
            else
            {
                Customer.Id = int.Parse(textID.Text);
                Customer.CustomerName = txtBoxName.Text;
                Customer.ContactName = contactPersonName.Text;
                Customer.Phone = phone.Text;
                if (CustomerBAL.InsertCustomer(Customer))
                {
                    MessageBox.Show("Inserted Successfully");
                    customerGrid.Refresh();
                    customerGrid.DataSource = CustomerBAL.GetCustomers();
                }
                else
                {
                    MessageBox.Show("Failed to Insert");
                }
                ShowCurrentClickedData();
                _componentClass.ChangeVisibility(false, false, false, true, true, false, false, true);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Customer = customerGrid.CurrentRow.DataBoundItem as Customer;
            if (CustomerBAL.DeleteCustomer(Customer))
            {
                MessageBox.Show("Deleted Successfully");
                customerGrid.Refresh();
                customerGrid.DataSource = CustomerBAL.GetCustomers();
            }
            else
            {
                MessageBox.Show("Failed to Delete");
            }
        }

        private void customerGrid_Click(object sender, EventArgs e)
        {
            ShowCurrentClickedData();
            _componentClass.ChangeVisibility(false, false, false, true, true, false, false, true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ShowCurrentClickedData();
            _componentClass.ChangeVisibility(false, false, false, true, true, false, false, true);
        }

        private void ShowCurrentClickedData()
        {
            Customer = customerGrid.CurrentRow.DataBoundItem as Customer;
            textID.Text = Customer.Id.ToString();
            txtBoxName.Text = Customer.CustomerName;
            contactPersonName.Text = Customer.ContactName;
            phone.Text = Customer.Phone;
        }
    }
}
