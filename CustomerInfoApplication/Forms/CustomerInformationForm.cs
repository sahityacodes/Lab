using BusinessEntityLayer.Model;
using BusinessLogic.CustomerInfoLogic;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace CustomerInfoApplication.Forms
{
    public partial class CustomerInformationForm : Form
    {
        FormComponents _componentClass = new();
        readonly CustomerBAL CustomerBAL = new();

        public CustomerInformationForm()
        {
            InitializeComponent();
        }

        private void CustomerInformationForm_Load(object sender, EventArgs e)
        {
            try
            {
                customerGrid.DataSource = CustomerBAL.GetCustomers();
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show(io.Message);
            }
            _componentClass.ChangeVisibility(this, false, false, false, true, true, false, false, true);
        }

        private void SearchByName_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null || textBox1.Text.Length != 0)
                {
                    customerGrid.DataSource = CustomerBAL.GetCustomersByName(textBox1.Text);
                }
            }
            catch (IndexOutOfRangeException io)
            {
                MessageBox.Show(io.Message);
            }
        }

        private void CustomerGrid_SelectionChanged(object sender, EventArgs e)
        {
            ShowCurrentClickedData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _componentClass.ChangeVisibility(this, true, true, true, false, false, false, true, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textID.Text = ((int)customerGrid.Rows[customerGrid.Rows.Count - 1].Cells[0].Value + 1).ToString();
            txtBoxName.Clear();
            contactPersonName.Clear();
            phone.Clear();
            _componentClass.ChangeVisibility(this, true, true, true, false, false, true, false, true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer Customer = new();
            Customer.Id = int.Parse(textID.Text);
            Customer.CustomerName = txtBoxName.Text;
            Customer.ContactName = contactPersonName.Text;
            Customer.Phone = phone.Text;
            try
            {
                if (CustomerBAL.UpdateCustomer(Customer))
                {
                    MessageBox.Show("Updated Successfully");
                    customerGrid.DataSource = null;
                    customerGrid.DataSource = CustomerBAL.GetCustomers();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter a valid name.");
            }
            catch (IndexOutOfRangeException io)
            {
                Debug.WriteLine("Error in btnUpdate_Click", io);
                MessageBox.Show(io.Message);
            }
            _componentClass.ChangeVisibility(this, false, false, false, true, true, false, false, true);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Customer Customer = new();
            Customer.Id = int.Parse(textID.Text);
            Customer.CustomerName = txtBoxName.Text;
            Customer.ContactName = contactPersonName.Text;
            Customer.Phone = phone.Text;
            try
            {
                if (CustomerBAL.InsertCustomer(Customer))
                {
                    MessageBox.Show("Inserted Successfully");
                    customerGrid.Refresh();
                    customerGrid.DataSource = CustomerBAL.GetCustomers();
                }
            }
            catch (NullReferenceException ne)
            {
                Debug.WriteLine("Length of the name is 0", ne);
                MessageBox.Show(ne.Message);
            }
            catch (IndexOutOfRangeException ior)
            {
                Debug.WriteLine("Error in btnInsert_Click", ior);
                MessageBox.Show("Error while reading data");
            }
            ShowCurrentClickedData();
            _componentClass.ChangeVisibility(this, false, false, false, true, true, false, false, true);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Customer Customer = customerGrid.CurrentRow.DataBoundItem as Customer;
            try
            {
                if (CustomerBAL.DeleteCustomer(Customer))
                {
                    MessageBox.Show("Deleted Successfully");
                    customerGrid.Refresh();
                    customerGrid.DataSource = CustomerBAL.GetCustomers();
                }
            }
            catch (IndexOutOfRangeException io)
            {
                Debug.WriteLine("Error in btnDel_Click", io);
                MessageBox.Show(io.Message);
            }
        }

        private void customerGrid_Click(object sender, EventArgs e)
        {
            ShowCurrentClickedData();
            _componentClass.ChangeVisibility(this, false, false, false, true, true, false, false, true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ShowCurrentClickedData();
            _componentClass.ChangeVisibility(this, false, false, false, true, true, false, false, true);
        }

        private void ShowCurrentClickedData()
        {
            Customer Customer = customerGrid.CurrentRow.DataBoundItem as Customer;
            textID.Text = Customer.Id.ToString();
            txtBoxName.Text = Customer.CustomerName;
            contactPersonName.Text = Customer.ContactName;
            phone.Text = Customer.Phone;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null || textBox1.Text.Length != 0)
                {
                    customerGrid.DataSource = CustomerBAL.GetCustomersByName(textBox1.Text);
                }
            }
            catch (IndexOutOfRangeException io)
            {
                Debug.WriteLine("Error in intextBox1_TextChanged ", io);
                MessageBox.Show(io.Message);
            }
        }
    }
}
