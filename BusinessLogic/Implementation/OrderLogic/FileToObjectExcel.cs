using BusinessEntityLayer.Model;
using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace BusinessLogic.Implementation.OrderLogic
{
    public class FileToObjectExcel : IImportFeature<List<SalesOrdersRows>>
    {
        public List<SalesOrdersRows> ConvertExcelToObject(string FilePath)
        {
            Excel.Application xlApp = new();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@FilePath,null,true);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range range = xlWorkSheet.UsedRange;
            List<SalesOrdersRows> rows = new();
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                try
                {
                    rows.Add(new SalesOrdersRows
                    {
                        ProductCode = range.Cells[i, 1] != null ? Convert.ToString(range.Cells[i, 1].Value2) : "",
                        Description = range.Cells[i, 2] != null ? Convert.ToString(range.Cells[i, 2].Value2) : "",
                        Qty = range.Cells[i, 3] != null ? Convert.ToDecimal(range.Cells[i, 3].Value2) : 0,
                        UnitPrice = range.Cells[i, 4] != null ? Convert.ToDecimal(range.Cells[i, 4].Value2) : 0
                    });
                }
                catch (FormatException)
                {
                    Debug.WriteLine(rows);
                }
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            return validateData(rows);
        }
        public List<SalesOrdersRows> ConvertTextFileToObject(string FilePath)
        {
            List<SalesOrdersRows> rows = new();
            StreamReader reader = File.OpenText(FilePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    if (line.Length > 0)
                    {
                        string[] values = line.Split(",");
                        rows.Add(new SalesOrdersRows(values[0], values[1], Convert.ToDecimal(values[2]), Convert.ToDecimal(values[3])));
                    }
                }
                catch (FormatException)
                {
                    Debug.WriteLine(rows);
                }
            }
            return validateData(rows);
        }

        public List<SalesOrdersRows> ConvertClipboardDataToObject(string Data)
        {
            if(Data.Length < 1)
            {
                throw new BusinessLogicException("Data entered is invalid");
            }
            List<SalesOrdersRows> rows = new();
            string[] lines = Data.Split('\n');
            foreach(string line in lines)
            {
                try
                {
                    if (line.Length > 0)
                    {
                        string[] values = line.Split(",");
                        rows.Add(new SalesOrdersRows(values[0], values[1], Convert.ToDecimal(values[2]), Convert.ToDecimal(values[3])));
                    }
                }
                catch (FormatException)
                {
                    Debug.WriteLine("Error while converting");
                }
            }
            return validateData(rows);
        }

        private List<SalesOrdersRows> validateData(List<SalesOrdersRows> rows)
        {
            if(rows.Count == 0)
            {
                throw new BusinessLogicException("Please enter valid data");
            }
            return rows;
        }
    }
}
