using BusinessEntityLayer.Model;
using BusinessLogic.Implementation.CustomerLogic;
using BusinessLogic.Implementation.OrderLogic;
using BusinessLogic.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;

namespace CustomerInfoApplication.Views.ChartViews
{
    public partial class ChartForm : XtraForm
    {
       
        public ChartForm()
        {
            InitializeComponent();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            IBLL<Customer> CustomerBal = new CustomerBAL();
            IBLL<SalesOrders> ORderBAL = new OrderBAL();
            try
            {
                buildBarChart(CustomerBal.GetCustomerOrdersCost(), "Total Orders", "Customer IDs", "Total Orders", "TotalCost: {Test}");
                buildPivotGrid(ToDataTable(ORderBAL.GetAll()));
            }
            catch(Exception)
            {
                MessageBox.Show("Error in the system.");
            }
        }

        private void buildBarChart(List<Customer> customerInfo, string seriesName, string xAxisTitle, string yAxisTitle, string tooltipPattern)
        {
            Series series = new(seriesName, ViewType.Bar);
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
            series.ToolTipPointPattern = tooltipPattern;

            XYDiagram diagram = (XYDiagram)barChart.Diagram;
            diagram.AxisY.WholeRange.SideMarginsValue = 0;
            diagram.AxisY.GridLines.Visible = false;
            diagram.AxisY.WholeRange.MinValue = 0;
            diagram.AxisY.WholeRange.MaxValue = customerInfo.Select(o => o.OrderCount).ToArray().Max() + 1;
            diagram.AxisY.NumericScaleOptions.GridSpacing = 1;
            diagram.AxisX.Title.Alignment = StringAlignment.Center;
            diagram.AxisX.Title.Visibility = DefaultBoolean.True;
            diagram.AxisX.Title.Text = xAxisTitle;
            diagram.AxisX.Title.TextColor = Color.Green;
            diagram.AxisY.Title.Alignment = StringAlignment.Center;
            diagram.AxisY.Title.Text = yAxisTitle;
            diagram.AxisY.Title.TextColor = Color.Green;
            diagram.AxisY.Title.Visibility = DefaultBoolean.True;
        }

        private void buildPivotGrid(DataTable dataTable)
        {
            pivotGridControl1.DataSource = dataTable;
            PivotGridField name = new PivotGridField("CustomerName", PivotArea.RowArea);
            name.Caption = "Customer Name";
            PivotGridField Id = new PivotGridField("CustomerID", PivotArea.RowArea);
            name.Caption = "Customer Name";
            PivotGridField orderID = new PivotGridField("OrderID", PivotArea.ColumnArea);
            orderID.Caption = "Order ID";
            PivotGridField price = new PivotGridField("TotalOrder", PivotArea.DataArea);
            price.Caption = "TotalOrder";
            price.CellFormat.FormatType = FormatType.Numeric;
            pivotGridControl1.Fields.AddRange(new PivotGridField[] { Id, name, orderID, price, });
            pivotGridControl1.BestFit();
        }
        public DataTable ToDataTable(List<SalesOrders> items)
        {
            DataTable dataTable = new DataTable("Customer");
            dataTable.Columns.AddRange(new DataColumn[] { new DataColumn("OrderID"),
               new DataColumn("CustomerID"), new DataColumn("CustomerName") });
            DataColumn totalOrder = new DataColumn("TotalOrder");
            totalOrder.DataType = System.Type.GetType("System.Int32");
            dataTable.Columns.Add(totalOrder);
            foreach (SalesOrders item in items)
            {
                dataTable.Rows.Add(item.OrderID, item.CustomerID, item.CustomerName, item.OrderSummary.TotalOrder);
            }
            return dataTable;
        }
    }
}