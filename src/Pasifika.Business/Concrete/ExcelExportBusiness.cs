using OfficeOpenXml;
using Pasifika.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasifika.Business.DataAccess.Concrete
{
    public class ExcelExportBusiness : IExcelExportBusiness
    {
        public Byte[] GetExcel(DataTable tbl)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Mails");

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(tbl, true);

                //Format the header for column 1-3
                /* using (ExcelRange rng = ws.Cells["A1:C1"])
                 {                    
                     rng.Style.Font.Bold = true;
                     rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                     //rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                     //rng.Style.Font.Color.SetColor(Color.White);
                 }

                 //Example how to Format Column 1 as numeric 
                 using (ExcelRange col = ws.Cells[2, 1, 2 + tbl.Rows.Count, 1])
                 {
                     col.Style.Numberformat.Format = "#,##0.00";
                     col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                 }*/
                return pck.GetAsByteArray();

                //Write it back to the client

            }
        }
    }
}
