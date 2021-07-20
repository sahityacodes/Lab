using BusinessEntityLayer;
using BusinessLogic;
using System;
using System.Windows.Forms;

namespace CustomerInfoApplication
{
    public partial class CustomerInformationForm : Form
    {
        Customer Customer = new();
        CustomerBAL CustomerBAL = new();

        public CustomerInformationForm()
        {
            InitializeComponent();
        }

        private void CustomerInformationForm_Load(object sender, EventArgs e)
        {
            customerGrid.DataSource = CustomerBAL.GetCustomers();
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
            GetCustomerToShow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBoxName.Enabled = true;
            contactPersonName.Enabled = true;
            phone.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            btnInsert.Visible = false;
            btnUpdate.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBoxName.Enabled = true;
            contactPersonName.Enabled = true;
            phone.Enabled = true;

            button1.Visible = false;
            button2.Visible = false;
            btnInsert.Visible = true;
            btnUpdate.Visible = false;
            textID.Text = ((int)customerGrid.Rows[customerGrid.Rows.Count - 1].Cells[0].Value + 1).ToString();
            txtBoxName.Text = "";
            contactPersonName.Text = "";
            phone.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {   
            Customer.Id = int.Parse(textID.Text);
            Customer.CustomerName = txtBoxName.Text;
            Customer.ContactName = contactPersonName.Text;
            Customer.Phone = phone.Text;
            if (txtBoxName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a Customer Name");
            }
            else
            {
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
                button1.Visible = true;
                button2.Visible = true;
                btnInsert.Visible = false;
                btnUpdate.Visible = false;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        { 
            Customer.Id = int.Parse(textID.Text);
            Customer.CustomerName = txtBoxName.Text;
            Customer.ContactName = contactPersonName.Text;
            Customer.Phone = phone.Text;
            if (txtBoxName.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a Customer Name");
            }
            else
            {
                if (CustomerBAL.InsertCustomer(Customer))
                {
                    MessageBox.Show("Inserted Successfully");
                    customerGrid.DataSource = null;
                    customerGrid.DataSource = CustomerBAL.GetCustomers();
                }
                else
                {
                    MessageBox.Show("Failed to Insert");
                }
                button1.Visible = true;
                button2.Visible = true;
                btnInsert.Visible = false;
                btnUpdate.Visible = false;
                GetCustomerToShow();
            }
        }

        private void GetCustomerToShow()
        {
            Customer = customerGrid.CurrentRow.DataBoundItem as Customer;
            textID.Text = Customer.Id.ToString();
            txtBoxName.Text = Customer.CustomerName;
            contactPersonName.Text = Customer.ContactName;
            phone.Text = Customer.Phone;
            txtBoxName.Enabled = false;
            contactPersonName.Enabled = false;
            phone.Enabled = false;
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
            btnUpdate.Visible = false;
            button2.Visible = true;
            button1.Visible = true;
        }
    }
}
