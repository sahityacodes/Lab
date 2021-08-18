using System.Windows.Forms;
using BusinessEntityLayer.Model;
using System;

namespace CustomerInfoApplication.Views.CustomerViews
{
    public partial class CustomerUpdateForm : Form
    {
        public CustomerUpdateForm()
        {
            InitializeComponent();
        }

        public void initializeForm(bool enableLabel, bool enabletxtID, Customer cust)
        {
            label7.Visible = enableLabel;
            txtID.Visible = enabletxtID;
            txtID.Text = cust.Id.ToString() ?? "";
            inputName.Text = cust.Name ??"";
            txtVAT.Text = cust.VAT ?? "";
            txtPhone.Text = cust.Phone ?? "";
            txtAddress.Text = cust.Address ?? "";
            txtCity.Text = cust.City  ?? "";
            txtIncome.Text = cust.AnnualRevenue.ToString() ?? "";
        }

        public Customer getCustomerData()
        {
            Customer Customer = new();
            Customer.Id = (txtID.Text.Length > 0) ? Convert.ToInt32(txtID.Text) : -1;
            Customer.Name = inputName.Text;
            Customer.Phone = txtPhone.Text ?? "";
            Customer.VAT = txtVAT.Text;
            Customer.Address = txtAddress.Text ?? "";
            Customer.City = txtCity.Text ?? "";
            Customer.AnnualRevenue = (txtIncome.Text.Length > 0) ? Convert.ToDecimal(txtIncome.Text) : 0;
            return Customer;
        }
        private void txtIncome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                  (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
