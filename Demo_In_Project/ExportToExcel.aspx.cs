using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Configuration;
using DAL;
using BLL;

public partial class Demo_In_Project_ExportToExcel : System.Web.UI.Page
{
    kus_KhoiLopBLL kus_lophoc;
    kus_HocVienBLL kus_hocvien;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsavefile_Click(object sender, EventArgs e)
    {
        kus_lophoc = new kus_KhoiLopBLL();
        kus_hocvien = new kus_HocVienBLL();

        DataTable tb = kus_hocvien.getTBAllHocVien();
        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(tb, "HocVien");

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename="+999.ToString()+".xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }
}