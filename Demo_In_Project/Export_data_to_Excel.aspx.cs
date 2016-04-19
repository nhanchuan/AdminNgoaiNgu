using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
public partial class Demo_In_Project_Export_data_to_Excel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ExportToExcel(object sender, EventArgs e)
    {
        // SET THE CONNECTION STRING.
        string sCon = "Data Source=DNA;Persist Security Info=False;Integrated Security=SSPI;" +
            "Initial Catalog=DNA_CLASSIFIED;User Id=sa;Password=;Connect Timeout=30;";

        using (SqlConnection con = new SqlConnection(sCon))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT *FROM dbo.EmployeeDetails"))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    sda.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string path = Server.MapPath("ExprotToExcel\\");

                        if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                        {
                            Directory.CreateDirectory(path);
                        }

                        File.Delete(path + "HocVien.xlsx"); // DELETE THE FILE BEFORE CREATING A NEW ONE.

                        // ADD A WORKBOOK USING THE EXCEL APPLICATION.
                        Excel.Application xlAppToExport = new Excel.Application();
                        xlAppToExport.Workbooks.Add("");

                        // ADD A WORKSHEET.
                        Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
                        xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

                        // ROW ID FROM WHERE THE DATA STARTS SHOWING.
                        int iRowCnt = 4;

                        // SHOW THE HEADER.
                        xlWorkSheetToExport.Cells[1, 1] = "Employee Details";

                        Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
                        range.EntireRow.Font.Name = "Calibri";
                        range.EntireRow.Font.Bold = true;
                        range.EntireRow.Font.Size = 20;

                        xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

                        // SHOW COLUMNS ON THE TOP.
                        xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "Employee Name";
                        xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "Mobile No.";
                        xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "PresentAddress";
                        xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "Email Address";


                        int i;
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            //xlWorkSheetToExport.Cells[iRowCnt, 1] = dt.Rows[i].Field<>("EmpName");
                            //xlWorkSheetToExport.Cells[iRowCnt, 2] = dt.Rows[i].Field("Mobile");
                            //xlWorkSheetToExport.Cells[iRowCnt, 3] = dt.Rows[i].Field("PresentAddress");
                            //xlWorkSheetToExport.Cells[iRowCnt, 4] = dt.Rows[i].Field("Email");

                            iRowCnt = iRowCnt + 1;
                        }

                        // FINALLY, FORMAT THE EXCEL SHEET USING EXCEL'S AUTOFORMAT FUNCTION.
                        Excel.Range range1 = xlAppToExport.ActiveCell.Worksheet.Cells[4, 1] as Excel.Range;
                        range1.AutoFormat(ExcelAutoFormat.xlRangeAutoFormatList3);

                        // SAVE THE FILE IN A FOLDER.
                        xlWorkSheetToExport.SaveAs(path + "EmployeeDetails.xlsx");

                        // CLEAR.
                        xlAppToExport.Workbooks.Close();
                        xlAppToExport.Quit();
                        xlAppToExport = null;
                        xlWorkSheetToExport = null;

                        lblConfirm.Text = "Data Exported Successfully";
                        lblConfirm.Attributes.Add("style", "color:green; font: normal 14px Verdana;");
                        btView.Attributes.Add("style", "display:block");
                        btDownLoadFile.Attributes.Add("style", "display:block");
                    }
                }
                catch (Exception ex)
                {
                    lblConfirm.Text = ex.Message.ToString();
                    lblConfirm.Attributes.Add("style", "color:red; font: bold 14px/16px Sans-Serif,Arial");
                }
                finally
                {
                    sda.Dispose();
                    sda = null;
                }
            }
        }
    }

    // VIEW THE EXPORTED EXCEL DATA.
    protected void ViewData(object sender, System.EventArgs e)
    {
        string path = Server.MapPath("exportedfiles\\");
        try
        {
            // CHECK IF THE FOLDER EXISTS.
            if (Directory.Exists(path))
            {
                // CHECK IF THE FILE EXISTS.
                if (File.Exists(path + "EmployeeDetails.xlsx"))
                {
                    // SHOW (NOT DOWNLOAD) THE EXCEL FILE.
                    Excel.Application xlAppToView = new Excel.Application();
                    xlAppToView.Workbooks.Open(path + "EmployeeDetails.xlsx");
                    xlAppToView.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            //
        }
    }

    // DOWNLOAD THE FILE.
    protected void DownLoadFile(object sender, EventArgs e)
    {
        try
        {
            string sPath = Server.MapPath("exportedfiles\\");

            Response.AppendHeader("Content-Disposition", "attachment; filename=EmployeeDetails.xlsx");
            Response.TransmitFile(sPath + "EmployeeDetails.xlsx");
            Response.End();
        }
        catch (Exception ex) { }
    }


}