using System.Windows.Forms;
using BusinessLogic.Interfaces;
using BusinessEntityLayer.Model;
using BusinessLogic.CustomerInfoLogic;
using BusinessLogic.Exceptions;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CustomerInfoApplication.Forms
{
    public partial class UpdateForm : Form
    {
        readonly IBLL<Customer> CustomerBal = new CustomerBAL();
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Customer Customer = new();
                Customer.Id = int.Parse(txtID.Text);
                Customer.Name = inputName.Text;
                Customer.Phone = txtPhone.Text ?? "";
                Customer.VAT = txtVAT.Text;
                Customer.Address = txtAddress.Text ?? "";
                Customer.City = txtCity.Text ?? "";
                if (txtIncome.Text.Length > 0)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(txtIncome.Text, "^[a-zA-Z ]"))
                        throw new UserDefinedException("Alphabets not allowed in Income field.");
                    else
                    {
                        Customer.AnnualRevenue = Convert.ToDecimal(txtIncome.Text);
                    }
                }
                if (CustomerBal.UpdateOne(Customer))
                {
                    DialogResult dialog = MessageBox.Show("Updated Successfully");
                    if (dialog == DialogResult.OK || dialog == DialogResult.Cancel)
                    {
                        this.Close();
                    }
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

        public void showData(DataGridViewRow customerGridRow)
        {
            txtID.Text = customerGridRow.Cells[0].Value.ToString().Trim() ?? "";
            inputName.Text = customerGridRow.Cells[1].Value.ToString().Trim();
            txtVAT.Text = customerGridRow.Cells[2].Value.ToString().Trim();
            txtPhone.Text = customerGridRow.Cells[3].Value.ToString().Trim();
            txtAddress.Text = customerGridRow.Cells[4].Value.ToString().Trim();
            txtCity.Text = customerGridRow.Cells[5].Value.ToString().Trim();
            txtIncome.Text = customerGridRow.Cells[6].Value.ToString().Trim();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Customer Customer = new();
                Customer.Name = inputName.Text;
                Customer.Phone = txtPhone.Text ?? "";
                Customer.VAT = txtVAT.Text;
                Customer.Address = txtAddress.Text ?? "";
                Customer.City = txtCity.Text ?? "";
                if (txtIncome.Text.Length > 0)
                {
                    if(System.Text.RegularExpressions.Regex.IsMatch(txtIncome.Text, "^[a-zA-Z ]"))
                        throw new UserDefinedException("Alphabets not allowed in Income field.");
                    else
                    {
                        Customer.AnnualRevenue = Convert.ToDecimal(txtIncome.Text);
                    }
                }
                if (CustomerBal.InsertOne(Customer))
                {
                    DialogResult dialog = MessageBox.Show("Inserted Successfully");
                    if (dialog == DialogResult.OK || dialog == DialogResult.Cancel)
                    {
                        this.Close();
                    }
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
    }
}
