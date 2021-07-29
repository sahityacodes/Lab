using BusinessEntityLayer.Model;
using BusinessLogic.Interfaces;
using BusinessLogic.CustomerInfoLogic;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using BusinessLogic.Exceptions;
namespace CustomerInfoApplication.Forms
{
    public partial class CustomerInformationForm : Form
    {
        FormComponents _componentClass = new();
        readonly IBLL<Customer> CustomerBal = new CustomerBAL();

        public CustomerInformationForm()
        {
            InitializeComponent();
        }

        private void CustomerInformationForm_Load(object sender, EventArgs e)
        {
            try
            {
                customerGrid.DataSource = CustomerBal.GetAll();
            }
            catch (Exception io)
            {
                Debug.WriteLine("Error in CustomerInformationForm_Load", io);
                MessageBox.Show("Error while fetching data");
            }
            _componentClass.ChangeVisibility(this, false, false, false, true, true, false, false, true);
        }

        private void SearchByName_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null || textBox1.Text.Length != 0)
                {
                    customerGrid.DataSource = CustomerBal.GetOneByName(textBox1.Text);
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine("Error in btnDel_Click", io);
                MessageBox.Show("Error while searching for records");
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
                if (CustomerBal.UpdateOne(Customer))
                {
                    MessageBox.Show("Updated Successfully");
                    customerGrid.DataSource = null;
                    customerGrid.DataSource = CustomerBal.GetAll();
                }
            }
            catch (UserDefinedException)
            {
                MessageBox.Show("Please enter a valid name.");
            }
            catch (Exception exc)
            {
                Debug.WriteLine("Error in btnUpdate_Click", exc);
                MessageBox.Show(exc.Message);
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
                if (CustomerBal.InsertOne(Customer))
                {
                    MessageBox.Show("Inserted Successfully");
                    customerGrid.Refresh();
                    customerGrid.DataSource = CustomerBal.GetAll();
                }
            }
            catch (UserDefinedException)
            {
                MessageBox.Show("Please enter a valid name.");
            }
            catch (Exception exc)
            {
                Debug.WriteLine("Error in btnInsert_Click", exc);
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
                if (CustomerBal.DeleteOne(Customer))
                {
                    MessageBox.Show("Deleted Successfully");
                    customerGrid.Refresh();
                    customerGrid.DataSource = CustomerBal.GetAll();
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine("Error in btnDel_Click", io);
                MessageBox.Show("Error :", io.Message);
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
                    customerGrid.DataSource = CustomerBal.GetOneByName(textBox1.Text);
                }
            }
            catch (Exception io)
            {
                Debug.WriteLine("Error in btnDel_Click", io);
                MessageBox.Show("Error :", io.Message);
            }
        }
    }
}
