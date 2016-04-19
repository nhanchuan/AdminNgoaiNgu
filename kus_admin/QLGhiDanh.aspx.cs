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

public partial class kus_admin_QLGhiDanh : BasePage
{
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
    kus_GhiDanhBLL kus_ghidanh;
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
                if (!check_permiss(ac.UserID, FunctionName.QLGhiDanh))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlHTChiNhanh();
                    formHT_CoSO.Visible = false;
                    dlLoaiThongKe.Items.FindByValue("0").Selected = true;
                    dlCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
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
        }
        else
        {
            formHT_CoSO.Visible = true;
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
        if (!IsNumber(str.Substring(0, 2)))
        {
            return "";
        }
        else
        {
            day = str.Substring(0, 2);
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
    private void Getkus_HVGhiDanhCoSoPageWise(int pageIndex, DateTime startdate, DateTime enddate, int CoSoID)
    {
        kus_ghidanh = new kus_GhiDanhBLL();
        int recordCount = 0;
        gwGhiDanhHocVien.DataSource = kus_ghidanh.kus_getHVGhiDanhInCoSo(pageIndex, PageSize, startdate, enddate, CoSoID);
        recordCount = kus_ghidanh.CountgetHVGhiDanhInCoSo(startdate, enddate, CoSoID);
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
        this.Getkus_HVGhiDanhCoSoPageWise(pageIndex, startdate, enddate, Convert.ToInt32(dlCoSo.SelectedValue));
        rptPager.Visible = false;
        rptcoso.Visible = true;

    }
    protected void btnSunmitGhiDanh_Click(object sender, EventArgs e)
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

        if(dlCoSo.SelectedValue=="0")
        {
            this.Getkus_HVGhiDanhPageWise(1, startdate, enddate);
            lblSumHocVien.Text = kus_ghidanh.Countkus_getHVGhiDanh(startdate, enddate).ToString();
            rptPager.Visible = true;
            rptcoso.Visible = false;
        }
        else
        {
            this.Getkus_HVGhiDanhCoSoPageWise(1, startdate, enddate, Convert.ToInt32(dlCoSo.SelectedValue));
            lblSumHocVien.Text = kus_ghidanh.CountgetHVGhiDanhInCoSo(startdate, enddate, Convert.ToInt32(dlCoSo.SelectedValue)).ToString();
            rptPager.Visible = false;
            rptcoso.Visible = true;
        }


    }
    protected void btnPhieuGD_ServerClick(object sender, EventArgs e)
    {
        if(gwGhiDanhHocVien.SelectedRow==null)
        {
            Response.Write("<script>alert('Chưa chọn Học Viên !')</script>");
            return;
        }
        else
        {
            string MaGhiDanh = (gwGhiDanhHocVien.SelectedRow.FindControl("lblGhiDanhCode") as Label).Text;
            Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/PhieuGhiDanh.aspx?MaGhiDanh="+ MaGhiDanh);

        }
    }
}