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

public partial class QuanLyHoSo_TraCuuHoSo : BasePage
{
    public int PageSize = 10;
    BagProfileTypeBLL bagprofiletype;
    CustomerProfilePrivateBLL customerprofileprivate;
    BagProfileBLL bagprofile;
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
                if (!check_permiss(ac.UserID, FunctionName.TraCuuHoSo))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlLoaiHoSo();
                    btnViewProfile.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default disabled");
                }
            }
        }
    }
    private void load_dlLoaiHoSo()
    {
        bagprofiletype = new BagProfileTypeBLL();
        this.load_DropdownList(dlLoaiHoSo, bagprofiletype.getAllBagProfileType(), "TypeName", "BagProfileTypeID");
        dlLoaiHoSo.Items.Insert(0, new ListItem("-- Chọn loại hồ sơ --", "0"));
    }
    private void TraCuuHoSoPageWise(int pageIndex, string ProfileCode, int BagProfileTypeID, string FullName, string Email, string IdentityCard, string Phone)
    {
        customerprofileprivate = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwTraCuuHoSo.DataSource = customerprofileprivate.TraCuuHoSoPageWise(pageIndex, PageSize, ProfileCode, BagProfileTypeID, FullName, Email, IdentityCard, Phone);
        recordCount = customerprofileprivate.CountTraCuuHoSoPageWise(ProfileCode, BagProfileTypeID, FullName, Email, IdentityCard, Phone);
        gwTraCuuHoSo.DataBind();
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
        this.TraCuuHoSoPageWise(pageIndex, txtProfileCode.Text, Convert.ToInt32(dlLoaiHoSo.SelectedValue), txtFullName.Text, txttEmail.Text, txtCMND.Text, txtPhone.Text);
    }


    protected void btnSearchHocVien_ServerClick(object sender, EventArgs e)
    {
        try
        {
            this.TraCuuHoSoPageWise(1, txtProfileCode.Text, Convert.ToInt32(dlLoaiHoSo.SelectedValue), txtFullName.Text, txttEmail.Text, txtCMND.Text, txtPhone.Text);
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void btnRefreshSearch_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    private void load_gwBagProfileManager(int InfoID)
    {
        bagprofile = new BagProfileBLL();
        gwBagProfileManager.DataSource = bagprofile.ViewBagProFile(InfoID);
        gwBagProfileManager.DataBind();
    }
    protected void gwTraCuuHoSo_SelectedIndexChanged(object sender, EventArgs e)
    {
        bagprofile = new BagProfileBLL();
        btnViewProfile.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default");
        int infoID = Convert.ToInt32((gwTraCuuHoSo.SelectedRow.FindControl("lblInfoID") as Label).Text);
        this.load_gwBagProfileManager(infoID);
        lblSumBagFile.Text = bagprofile.SumBAGProFile(infoID).ToString();
    }
}