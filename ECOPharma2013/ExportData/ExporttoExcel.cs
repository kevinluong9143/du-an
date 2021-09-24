
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Export_POS
{
    public class ExporttoExcel
    {
        public bool exportDataToExcel(DataTable dt)
        {
            bool result = false;

                //Create Excel Objects
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Excel file (*.xls)|*.xls";
            if (f.ShowDialog() == DialogResult.OK)
            {
                //Create New Excel WorkBook
                oExcel.Visible = false;
                oExcel.DisplayAlerts = false;
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
                oSheet.Name = "FinalData";

                // Create Array to hold the data of DataTable
                object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

                //điền tiêu đề cho các cột trong file excel
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    oSheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }

                //Fill DataTable in Array
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    DataRow dr = dt.Rows[r];
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        if (c == 7)
                        {
                            arr[r, c] = " " + dr[c];
                        }
                        else
                        {
                            arr[r, c] = dr[c];
                        }
                    }
                }

                //Set Excel Range to Paste the Data
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[2, 1];
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[2 + dt.Rows.Count - 1, dt.Columns.Count];
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                //Fill Array in Excel
                range.Value2 = arr;
                //}

                //save file
                oBook.SaveAs(f.FileName);
                oBook.Close(true);
                oExcel.Quit();
                result = true;
            }
            return result;
        }
    }
}
