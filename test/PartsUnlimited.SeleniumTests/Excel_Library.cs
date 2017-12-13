
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited
{
    class Excel_Library
    {
        
            //Import Data from Excel workbooks
            public static DataTable GetNumberOfRows(string filename, string sheetName)
            {
                string connectionString = String.Empty;
                DataTable dt = new DataTable();
                try
                {
                    dt = getDataTableFromExcel(filename, sheetName);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return dt;
            }
            public static DataTable getDataTableFromExcel(string path, string sheetName)
            {
                using (var pck = new OfficeOpenXml.ExcelPackage())
                {
                    using (var stream = File.OpenRead(path))
                    {
                        pck.Load(stream);
                    }
                    var ws = pck.Workbook.Worksheets[sheetName];
                    DataTable tbl = new DataTable();
                    bool hasHeader = true; // adjust it accordingly( i've mentioned that this is a simple approach)
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                    var startRow = hasHeader ? 2 : 1;
                    for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                        var row = tbl.NewRow();
                        foreach (var cell in wsRow)
                        {
                            try
                            {
                                row[cell.Start.Column - 1] = String.IsNullOrEmpty(cell.Text) == true ? String.Empty : cell.Text;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                        tbl.Rows.Add(row);
                    }
                    return tbl;
                }
            }
        

        }

    }
