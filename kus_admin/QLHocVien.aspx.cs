using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
public partial class kus_admin_QLHocVien : BasePage
{
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
    kus_GhiDanhBLL kus_ghidanh;
    nc_KhoaHocBLL nc_khoahoc;
    kus_HocVienBLL kus_hocvien;
    public int PageSize = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!IsPostBack)
        {
            UserAccounts ac = Session.GetCurrentUser();
            if (ac == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(ac.UserID, FunctionName.QLHocVien))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlHTChiNhanh();
                    formHT_CoSO.Visible = false;
                    dlLoaiThongKe.Items.FindByValue("0").Selected = true;
                    dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
                    dlKhoaHoc.Items.Insert(0, new ListItem("------ Chọn Khóa Học thuộc cơ sở -------", "0"));
                    btnSunmitGhiDanhLop.Visible = false;
                    btnSunmitGhiDanhHV.Visible = true;
                    btnExporttoExcel.Visible = false;
                }
            }
        }
    }
    private void load_dlHTChiNhanh()
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        dlHTChiNhanh.DataSource = kus_htchinhanh.getlAllHTChiNHanh();
        dlHTChiNhanh.DataTextField = "tenHTChiNhanh";
        dlHTChiNhanh.DataValueField = "hTChiNhanhID";
        dlHTChiNhanh.DataBind();
        dlHTChiNhanh.Items.Insert(0, new ListItem("-- Chọn Ht.Chi Nhánh --", "0"));
    }
    protected void dlHTChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        dlCoSo.DataSource = kus_coso.getLSTCoSoWithChiNhanhID(Convert.ToInt32(dlHTChiNhanh.SelectedValue));
        dlCoSo.DataTextField = "TenCoSo";
        dlCoSo.DataValueField = "CoSoID";
        dlCoSo.DataBind();
        dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
    }
    protected void dlLoaiThongKe_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dlLoaiThongKe.SelectedValue == "0")
        {
            formHT_CoSO.Visible = false;
            panelChonNgay.Visible = true;
            btnSunmitGhiDanhLop.Visible = false;
            btnSunmitGhiDanhHV.Visible = true;
            btnExporttoExcel.Visible = false;
        }
        else
        {
            formHT_CoSO.Visible = true;
            panelChonNgay.Visible = false;
            btnSunmitGhiDanhLop.Visible = true;
            btnSunmitGhiDanhHV.Visible = false;
            btnExporttoExcel.Visible = true;
        }
    }
    public bool IsNumber(string pText)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        return regex.IsMatch(pText);
    }
    private string getday(string str)
    {
        string day = "";
        if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
        {
            return "";
        }
        else
        {
            if (!IsNumber(str.Substring(0, 2)))
            {
                return "";
            }
            else
            {
                day = str.Substring(0, 2);
            }
        }

        return day;
    }
    private string getmonth(string str)
    {
        string month = "";
        if (!IsNumber(str.Substring(3, 2)))
        {
            return "";
        }
        else
        {
            month = str.Substring(3, 2);
        }
        return month;
    }
    private string getyear(string str)
    {
        string year = "";
        if (str.Length != 10)
        {
            return "";
        }
        else
        {
            if (!IsNumber(str.Substring(6, 4)))
            {
                return "";
            }
            else
            {
                year = str.Substring(6, 4);
            }
        }
        return year;
    }
    private void Getkus_HVGhiDanhPageWise(int pageIndex, DateTime startdate, DateTime enddate)
    {
        kus_ghidanh = new kus_GhiDanhBLL();
        int recordCount = 0;
        gwGhiDanhHocVien.DataSource = kus_ghidanh.kus_getHVGhiDanh(pageIndex, PageSize, startdate, enddate);
        recordCount = kus_ghidanh.Countkus_getHVGhiDanh(startdate, enddate);
        gwGhiDanhHocVien.DataBind();
        this.PopulatePager(recordCount, pageIndex);
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;
        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        DateTime startdate;
        if (DateTime.TryParseExact(txtStartdate.Text, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out startdate) || getday(txtStartdate.Text) == "" || getmonth(txtStartdate.Text) == "" || getyear(txtStartdate.Text) == "")
        {
            lblstartdateFalse.Text = "Ngày bắt đầu không chính xác !";
            return;
        }
        else
        {
            lblstartdateFalse.Text = "";
            startdate = DateTime.ParseExact(getday(txtStartdate.Text) + "/" + getmonth(txtStartdate.Text) + "/" + getyear(txtStartdate.Text), "dd/MM/yyyy", null);
        }
        DateTime enddate;
        if (DateTime.TryParseExact(txtEnddate.Text, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out enddate) || getday(txtEnddate.Text) == "" || getmonth(txtEnddate.Text) == "" || getyear(txtEnddate.Text) == "")
        {
            lblEnddatefalse.Text = "Ngày kết thúc không chính xác !";
            return;
        }
        else
        {
            lblEnddatefalse.Text = "";
            enddate = DateTime.ParseExact(getday(txtEnddate.Text) + "/" + getmonth(txtEnddate.Text) + "/" + getyear(txtEnddate.Text), "dd/MM/yyyy", null);
        }
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.Getkus_HVGhiDanhPageWise(pageIndex, startdate, enddate);
        rptPager.Visible = true;
        rptcoso.Visible = false;
    }
    private void Getkus_HVGhiDanhKhoaHocPageWise(int pageIndex, int khoahoc)
    {
        kus_ghidanh = new kus_GhiDanhBLL();
        int recordCount = 0;
        gwGhiDanhHocVien.DataSource = kus_ghidanh.kus_getHVGhiDanhInKhoaHoc(pageIndex, PageSize, khoahoc);
        recordCount = kus_ghidanh.CountgetHVGhiDanhInKhoaHoc(khoahoc);
        gwGhiDanhHocVien.DataBind();
        this.PopulateCSPager(recordCount, pageIndex);
    }
    private void PopulateCSPager(int recordCount, int currentPage)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;
        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptcoso.DataSource = pages;
        rptcoso.DataBind();
    }
    protected void CSPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.Getkus_HVGhiDanhKhoaHocPageWise(pageIndex, Convert.ToInt32(dlKhoaHoc.SelectedValue));
        rptPager.Visible = false;
        rptcoso.Visible = true;

    }
    //protected void btnPhieuGD_ServerClick(object sender, EventArgs e)
    //{
    //    if (gwGhiDanhHocVien.SelectedRow == null)
    //    {
    //        Response.Write("<script>alert('Chưa chọn Học Viên !')</script>");
    //        return;
    //    }
    //    else
    //    {
    //        string MaGhiDanh = (gwGhiDanhHocVien.SelectedRow.FindControl("lblGhiDanhCode") as Label).Text;
    //        Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/PhieuGhiDanh.aspx?MaGhiDanh=" + MaGhiDanh);

    //    }
    //}
    protected void dlCoSo_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        dlKhoaHoc.DataSource = nc_khoahoc.DropdownKhoaHocWithCS(Convert.ToInt32(dlCoSo.SelectedValue));
        dlKhoaHoc.DataTextField = "TenKhoaHoc";
        dlKhoaHoc.DataValueField = "ID";
        dlKhoaHoc.DataBind();
        dlKhoaHoc.Items.Insert(0, new ListItem("----- Chọn Khóa Học thuộc cơ sở -----", "0"));
    }

    protected void btnSunmitGhiDanhLop_Click(object sender, EventArgs e)
    {
        kus_ghidanh = new kus_GhiDanhBLL();
        this.Getkus_HVGhiDanhKhoaHocPageWise(1, Convert.ToInt32(dlKhoaHoc.SelectedValue));
        lblSumHocVien.Text = kus_ghidanh.CountgetHVGhiDanhInKhoaHoc(Convert.ToInt32(dlKhoaHoc.SelectedValue)).ToString();
        rptPager.Visible = false;
        rptcoso.Visible = true;
    }
    protected void btnSunmitGhiDanhHV_Click(object sender, EventArgs e)
    {
        kus_ghidanh = new kus_GhiDanhBLL();
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        DateTime startdate;
        if (DateTime.TryParseExact(txtStartdate.Text, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out startdate) || getday(txtStartdate.Text) == "" || getmonth(txtStartdate.Text) == "" || getyear(txtStartdate.Text) == "")
        {
            lblstartdateFalse.Text = "Ngày bắt đầu không chính xác !";
            return;
        }
        else
        {
            lblstartdateFalse.Text = "";
            startdate = DateTime.ParseExact(getday(txtStartdate.Text) + "/" + getmonth(txtStartdate.Text) + "/" + getyear(txtStartdate.Text), "dd/MM/yyyy", null);
        }
        DateTime enddate;
        if (DateTime.TryParseExact(txtEnddate.Text, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out enddate) || getday(txtEnddate.Text) == "" || getmonth(txtEnddate.Text) == "" || getyear(txtEnddate.Text) == "")
        {
            lblEnddatefalse.Text = "Ngày kết thúc không chính xác !";
            return;
        }
        else
        {
            lblEnddatefalse.Text = "";
            enddate = DateTime.ParseExact(getday(txtEnddate.Text) + "/" + getmonth(txtEnddate.Text) + "/" + getyear(txtEnddate.Text), "dd/MM/yyyy", null);
        }
        this.Getkus_HVGhiDanhPageWise(1, startdate, enddate);
        lblSumHocVien.Text = kus_ghidanh.Countkus_getHVGhiDanh(startdate, enddate).ToString();
        rptPager.Visible = true;
        rptcoso.Visible = false;

    }
    protected void btnExporttoExcel_ServerClick(object sender, EventArgs e)
    {
        if (gwGhiDanhHocVien.Rows.Count == 0)
        {
            Response.Write("<script>alert('No data')</script>");
        }
        else
        {
            int lophocID = Convert.ToInt32(dlKhoaHoc.SelectedValue);
            if (lophocID == 0)
            {
                Response.Write("<script>alert('Chưa chọn lớp học !')</script>");
            }
            else
            {
                this.ExportToExcel(Convert.ToInt32(dlKhoaHoc.SelectedValue));
            }
        }
    }
    // FUNCTION EXPORT TO EXCEL
    protected void ExportToExcel(int khoahoc)
    {
        kus_hocvien = new kus_HocVienBLL();
        nc_khoahoc = new nc_KhoaHocBLL();
        DataTable tb = kus_hocvien.ExprotHVtoExcel(khoahoc);
        try
        {
            if (tb.Rows.Count > 0)
            {
                string path = Server.MapPath("../FileManager/Excel/");

                if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                {
                    Directory.CreateDirectory(path);
                }

                File.Delete(path + "ListHocVien.xlsx"); // DELETE THE FILE BEFORE CREATING A NEW ONE.

                // ADD A WORKBOOK USING THE EXCEL APPLICATION.
                Excel.Application xlAppToExport = new Excel.Application();
                xlAppToExport.Workbooks.Add("");

                // ADD A WORKSHEET.
                Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
                xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];
                // ROW ID FROM WHERE THE DATA STARTS SHOWING.
                int iRowCnt = 4;

                // SHOW THE HEADER.
                List<nc_KhoaHoc> lstKhoaHoc = nc_khoahoc.getListKhoaHocWithID(khoahoc);
                nc_KhoaHoc khoh = lstKhoaHoc.FirstOrDefault();
                xlWorkSheetToExport.Cells[1, 1] = "DANH SÁCH HỌC VIÊN KHÓA " + ((khoh == null) ? "" : khoh.TenKhoaHoc + " - " + khoh.MaKhoaHoc);

                Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
                range.EntireRow.Font.Name = "Calibri";
                range.EntireRow.Font.Bold = true;
                range.EntireRow.Font.Size = 18;

                xlWorkSheetToExport.Range["A1:H1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

                // SHOW COLUMNS ON THE TOP.
                xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "STT";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "MÃ HỌC VIÊN.";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "HỌ";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "TÊN";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 5] = "GIỚI TÍNH";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 6] = "NGÀY SINH";
                xlWorkSheetToExport.Cells[iRowCnt - 1, 7] = "HỌC PHÍ";

                foreach (DataRow r in tb.Rows)
                {
                    xlWorkSheetToExport.Cells[iRowCnt, 1] = (string.IsNullOrEmpty(r["ThuTu"].ToString())) ? "" : ((int)r["ThuTu"]).ToString();
                    xlWorkSheetToExport.Cells[iRowCnt, 2] = (string.IsNullOrEmpty(r["HocVienCode"].ToString())) ? "" : (string)r["HocVienCode"];
                    xlWorkSheetToExport.Cells[iRowCnt, 3] = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
                    xlWorkSheetToExport.Cells[iRowCnt, 4] = (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : (string)r["FirstName"];
                    xlWorkSheetToExport.Cells[iRowCnt, 5] = (string.IsNullOrEmpty(r["Sex"].ToString())) ? "" : (string)r["Sex"];
                    xlWorkSheetToExport.Cells[iRowCnt, 6] = (string.IsNullOrEmpty(r["Birthday"].ToString())) ? "" : ((DateTime)r["Birthday"]).ToString("dd/MM/yyyy");
                    xlWorkSheetToExport.Cells[iRowCnt, 7] = (string.IsNullOrEmpty(r[9].ToString())) ? "" : ((int)r[9] == 0) ? "Chưa đóng" : "Đã đóng";
                    iRowCnt = iRowCnt + 1;
                }
                // FINALLY, FORMAT THE EXCEL SHEET USING EXCEL'S AUTOFORMAT FUNCTION.
                Excel.Range range1 = xlAppToExport.ActiveCell.Worksheet.Cells[4, 1] as Excel.Range;
                range1.AutoFormat(ExcelAutoFormat.xlRangeAutoFormatList3);

                // SAVE THE FILE IN A FOLDER.
                xlWorkSheetToExport.SaveAs(path + "ListHocVien.xlsx");

                // CLEAR.
                xlAppToExport.Workbooks.Close();
                xlAppToExport.Quit();
                xlAppToExport = null;
                xlWorkSheetToExport = null;

                lblConfirm.Text = "Data Exported Successfully.";
                lblConfirm.Attributes.Add("style", "color:green; font: normal 14px Verdana;");
                btDownLoadFile.Attributes.Add("style", "display:block; font: normal 18px Verdana;");
            }
        }
        catch (Exception ex)
        {
            lblConfirm.Text = ex.Message.ToString();
            lblConfirm.Attributes.Add("style", "color:red; font: bold 14px/16px Sans-Serif,Arial");
        }

    }
    protected void DownLoadFile(object sender, EventArgs e)
    {
        string sPath = Server.MapPath("../FileManager/Excel/ListHocVien.xlsx");
        FileInfo file = new FileInfo(sPath);
        try
        {

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(sPath));
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.TransmitFile(sPath);
            Response.Flush();
            Response.End();
        }


        catch (Exception ex) {
            Response.Write("<scipt>alert('" + ex + "')</scipt>");
        }
    }
    protected void btnViewHocVienInfor_ServerClick(object sender, EventArgs e)
    {
        if(gwGhiDanhHocVien.SelectedRow==null)
        {
            Response.Write("<script>alert('No Row selected!')</script>");
        }
        else
        {
            string HocVienCode = (gwGhiDanhHocVien.SelectedRow.FindControl("lblHocVienCode") as Label).Text;
            Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/ChiTietHocVien.aspx?MaHocVien=" + HocVienCode);
        }
    }
}