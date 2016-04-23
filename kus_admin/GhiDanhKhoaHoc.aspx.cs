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

public partial class kus_admin_GhiDanhKhoaHoc : BasePage
{
    private int PageSize = 20;
    //kus_LopHocBLL kus_lophoc;
    //kus_LopHoc_BooksBLL kus_lophoc_books;
    nc_KhoaHocBLL nc_khoahoc;
    kus_BooksBLL kus_books;
    kus_LichHocBLL kus_lichhoc;
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
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
                if (!check_permiss(ac.UserID, FunctionName.GhiDanhKhoaHoc))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlHTChiNhanh();
                    dlCoSo.Items.Insert(0, new ListItem("--- Chọn Cơ Sở ---", "0"));
                    btnDangKyKhoaHoc.Attributes.Add("class", "btn btn-default disabled");
                    btnLenlichhoc.Attributes.Add("class", "btn btn-default disabled");
                    rptPager.Visible = true;
                    rptSearch.Visible = false;
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
        dlCoSo.Items.Insert(0, new ListItem("--- Chọn Cơ Sở thuộc H.t Chi Nhánh ---", "0"));
    }
    private void Getnc_KhoaHocPageWise(int pageIndex, int CoSoID)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        int recordCount = 0;
        gwKhoaHoc.DataSource = nc_khoahoc.get_nc_KhoaHoc_CoSoID(pageIndex, PageSize, CoSoID);
        recordCount = nc_khoahoc.Count_khoahocCS(CoSoID);
        gwKhoaHoc.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        lblCountKhoaHoc.Text = recordCount.ToString();
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
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.Getnc_KhoaHocPageWise(pageIndex, Convert.ToInt32(dlCoSo.SelectedValue));
        Session["pageIndexnc_lophoc"] = pageIndex.ToString();
        rptPager.Visible = true;
        rptSearch.Visible = false;
    }
    protected void dlCoSo_SelectedIndexChanged(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        this.Getnc_KhoaHocPageWise(1, Convert.ToInt32(dlCoSo.SelectedValue));
    }

    protected void btnRefreshLstKhoaHoc_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void gwKhoaHoc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDel") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwKhoaHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This Process is Building ! !')</script>");
    }

    protected void gwKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnDangKyKhoaHoc.Attributes.Add("class", "btn btn-default");
        btnLenlichhoc.Attributes.Add("class", "btn btn-default");
    }

    protected void btnDangKyKhoaHoc_ServerClick(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        if (gwKhoaHoc.SelectedRow == null)
        {
            Response.Write("<script>alert('Chưa chọn khóa học ! Vui lòng chọn 1 khóa học trong danh sách !')</script>");
        }
        else
        {
            int soluong = Convert.ToInt32((gwKhoaHoc.SelectedRow.FindControl("lblSoLuong") as Label).Text);
            int soluongGD = Convert.ToInt32((gwKhoaHoc.SelectedRow.FindControl("lblSLGhiDanh") as Label).Text);
            if (soluongGD >= soluong)
            {
                //lblWarningDKLop.Text = "Lớp đã đầy, không thể ghi danh lớp này được nữa. Vui lòng chọn lớp khác !";
                Response.Write("<script>alert('Khóa học đã đủ số lượng học viên, không thể ghi danh khóa học này được nữa. Vui lòng chọn khóa học khác !')</script>");
            }
            else
            {
                string makhoahoc = (gwKhoaHoc.SelectedRow.FindControl("lblMaKhoaHoc") as Label).Text;
                Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/GhiDanhHocVien.aspx?makhoahoc=" + makhoahoc);
            }

        }
    }
    //search
    private void GetSearchKhoaHocPageWise(int pageIndex, string keysearch)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        int recordCount = 0;
        gwKhoaHoc.DataSource = nc_khoahoc.Search_nc_KhoaHoc(pageIndex, PageSize, keysearch);
        recordCount = nc_khoahoc.Count_search_khoahoc(keysearch);
        gwKhoaHoc.DataBind();
        this.PopulateSearch(recordCount, pageIndex);
    }
    private void PopulateSearch(int recordCount, int currentPage)
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
        rptSearch.DataSource = pages;
        rptSearch.DataBind();
    }
    protected void Search_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetSearchKhoaHocPageWise(pageIndex, txtsearch.Value);
        rptPager.Visible = false;
        rptSearch.Visible = true;
    }

    protected void btnSearchKhoaHoc_ServerClick(object sender, EventArgs e)
    {
        this.GetSearchKhoaHocPageWise(1, txtsearch.Value);
        rptPager.Visible = false;
        rptSearch.Visible = true;
    }

    protected void btnLenlichhoc_ServerClick(object sender, EventArgs e)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        if (gwKhoaHoc.SelectedRow == null)
        {
            Response.Write("<script>alert('Chưa chọn khóa học ! Vui lòng chọn 1 khóa học trong danh sách !')</script>");
        }
        else
        {
            string makhoahoc = (gwKhoaHoc.SelectedRow.FindControl("lblMaKhoaHoc") as Label).Text;
            Response.Redirect("http://" + Request.Url.Authority + "/kus_admin/CreateSchedule.aspx?makhoahoc=" + makhoahoc);
        }
    }
}