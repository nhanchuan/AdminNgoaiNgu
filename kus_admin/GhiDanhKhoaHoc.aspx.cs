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
    private int PageSize = 10;
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
                if (!check_permiss(ac.UserID, FunctionName.GhiDanhLopMoi))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlHTChiNhanh();
                    dlCoSo.Items.Insert(0, new ListItem("--- Chọn Cơ Sở ---", "0"));
                    btnEditKhoaHoc.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default disabled");
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
    private void Getnc_KhoaHocPageWise(int pageIndex, int SoSoID)
    {
        nc_khoahoc = new nc_KhoaHocBLL();
        int recordCount = 0;
        gwKhoaHoc.DataSource = nc_khoahoc.get_nc_KhoaHoc_CoSoID(pageIndex, PageSize, SoSoID);
        recordCount = nc_khoahoc.Count_khoahocCS(SoSoID);
        gwKhoaHoc.DataBind();
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
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.Getnc_KhoaHocPageWise(pageIndex, Convert.ToInt32(dlCoSo.SelectedValue));
        Session["pageIndexnc_lophoc"] = pageIndex.ToString();
        //rptPager.Visible = true;
        //rptSearch.Visible = false;
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

    }

    protected void gwKhoaHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gwKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnEditKhoaHoc.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default");
    }
}