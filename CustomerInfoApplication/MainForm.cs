using System;
using CustomerInfoApplication.Views.CustomerViews;
using CustomerInfoApplication.Views.OrderViews;
using CustomerInfoApplication.Views.ChartViews;
using DevExpress.XtraBars.FluentDesignSystem;

namespace CustomerInfoApplication
{
    public partial class MainForm : FluentDesignForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void customerControl_Click(object sender, EventArgs e)
        {
            fluentDesignFormContainer1.Controls.Clear();
            CustomerInformationForm customerInfoForm = new();
            customerInfoForm.TopLevel = false;
            customerInfoForm.Dock = System.Windows.Forms.DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(customerInfoForm);
            customerInfoForm.Show();
        }

        private void orderControl_Click(object sender, EventArgs e)
        {
            fluentDesignFormContainer1.Controls.Clear();
            SalesOrderForm orderInfoForm = new();
            orderInfoForm.TopLevel = false;
            orderInfoForm.Dock = System.Windows.Forms.DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(orderInfoForm);
            orderInfoForm.Show();
        }

        private void analyticsControl_Click(object sender, EventArgs e)
        {
            fluentDesignFormContainer1.Controls.Clear();
            ChartForm costOrderChart = new();
            costOrderChart.TopLevel = false;
            costOrderChart.Dock = System.Windows.Forms.DockStyle.Fill;
            fluentDesignFormContainer1.Controls.Add(costOrderChart);
            costOrderChart.Show();
        }
    }
}
