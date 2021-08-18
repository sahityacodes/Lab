using BusinessEntityLayer.Model;
using BusinessLogic.Implementation.CustomerLogic;
using BusinessLogic.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CustomerInfoApplication.Views.ChartViews
{
    public partial class ChartForm : XtraForm
    {
        readonly ICustomerBLL<Customer> CustomerBal = new CustomerBAL();
        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            List<Customer> customerInfo = CustomerBal.GetCustomerOrdersCost();
            Series series = new("Total Orders", ViewType.Bar);
            foreach (Customer cust in customerInfo)
            {
                series.Points.Add(new SeriesPoint(Convert.ToString(cust.Id), cust.OrderCount)
                {
                    Tag = new { Test = cust.TotalAmount }
                });
            }
            series.ArgumentScaleType = ScaleType.Qualitative;
            barChart.Series.AddRange(series);
            barChart.CrosshairEnabled = DefaultBoolean.False;
            barChart.ToolTipEnabled = DefaultBoolean.True;

            ToolTipController controller = new ToolTipController();
            barChart.ToolTipController = controller;
            controller.ShowBeak = true;

            ToolTipRelativePosition relativePosition = new ToolTipRelativePosition();
            barChart.ToolTipOptions.ToolTipPosition = relativePosition;

            relativePosition.OffsetX = 2;
            relativePosition.OffsetY = 2;
            series.ToolTipPointPattern = "CustomerID : {V} TotalCost : {Test}";

            XYDiagram diagram = (XYDiagram)barChart.Diagram;
            diagram.AxisY.WholeRange.SideMarginsValue = 0;
            diagram.AxisY.GridLines.Visible = false;
            diagram.AxisY.WholeRange.MinValue = 0;
            diagram.AxisY.WholeRange.MaxValue = customerInfo.Select(o => o.OrderCount).ToArray().Max() + 1;
            diagram.AxisY.NumericScaleOptions.GridSpacing = 1;
            diagram.AxisX.Title.Alignment = StringAlignment.Center;
            diagram.AxisX.Title.Visibility = DefaultBoolean.True;
            diagram.AxisX.Title.Text = "Customer IDs";
            diagram.AxisX.Title.TextColor = Color.Red;
            diagram.AxisY.Title.Alignment = StringAlignment.Center;
            diagram.AxisY.Title.Text = "Total Orders";
            diagram.AxisY.Title.TextColor = Color.Red;
            diagram.AxisY.Title.Visibility = DefaultBoolean.True;

        }
    }
}