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

public partial class QuanLyHoSo_HoSoTongHop : BasePage
{
    CustomerBasicInfoBLL customerbasicinfo;
    CustomerProfilePrivateBLL customerProPri;
    EmployeesBLL employees;
    public int PageSize = 10;
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
                if (!check_permiss(ac.UserID, FunctionName.HoSoTongHop))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.GetProfile_AdvisoryPageWise(1);
                    btnUncheckAll.Visible = false;
                    this.load_dlEmployees();
                    dlEmployees.Items.Insert(0, new ListItem("-- Nhân viên làm hồ sơ --", "0"));
                    rptPager.Visible = true;
                    RepeaterKeySearch.Visible = false;
                }
            }
        }
    }
    private void GetProfile_AdvisoryPageWise(int pageIndex)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwProfilePrivateManager.DataSource = customerProPri.GetProfile_AdvisoryPageWise(pageIndex, PageSize);
        recordCount = customerProPri.CountProfile_AdvisoryPageWisee();
        gwProfilePrivateManager.DataBind();
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
        this.GetProfile_AdvisoryPageWise(pageIndex);
        //lblstartindex.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        //lblendindex.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();
    }
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in gwProfilePrivateManager.Rows)
        {
            CheckBox ch = (CheckBox)r.FindControl("chkrow");
            ch.Checked = true;
        }
        btnSelectAll.Visible = false;
        btnUncheckAll.Visible = true;
    }
    protected void btnUncheckAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in gwProfilePrivateManager.Rows)
        {
            CheckBox ch = (CheckBox)r.FindControl("chkrow");
            ch.Checked = false;
        }
        btnSelectAll.Visible = true;
        btnUncheckAll.Visible = false;
    }
    private void load_dlEmployees()
    {
        employees = new EmployeesBLL();
        dlEmployees.DataSource = employees.DropdownEmployeesWithDepartments(3);
        dlEmployees.DataTextField = "Name";
        dlEmployees.DataValueField = "EmployeesID";
        dlEmployees.DataBind();
    }
    private void GetProfile_AdvisorySearchKeyPageWise(int pageIndex, string keysearch)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwProfilePrivateManager.DataSource = customerProPri.GetProfile_AdvisorySearchKeyPageWise(pageIndex, PageSize, keysearch);
        recordCount = customerProPri.Count_GetProfile_AdvisorySearchKeyPageWise(keysearch);
        gwProfilePrivateManager.DataBind();
        this.PopulateKeySearchPager(recordCount, pageIndex);
        //lbltotalSearchDl.Text = recordCount.ToString();
    }
    private void PopulateKeySearchPager(int recordCount, int currentPage)
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
        RepeaterKeySearch.DataSource = pages;
        RepeaterKeySearch.DataBind();
    }
    protected void KeySearchPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetProfile_AdvisorySearchKeyPageWise(pageIndex, txtsearchAdv.Value);
    }
    protected void btnSearchProfile_ServerClick(object sender, EventArgs e)
    {
        this.GetProfile_AdvisorySearchKeyPageWise(1, txtsearchAdv.Value);
        rptPager.Visible = false;
        RepeaterKeySearch.Visible = true;
    }
    protected void btnreload_Click(object sender, EventArgs e)
    {
        this.GetProfile_AdvisoryPageWise(1);
    }

    protected void btnSendProfile_ServerClick(object sender, EventArgs e)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        if (dlEmployees.SelectedValue == "0")
        {
            Response.Write("<script>alert('Chưa chọn Nhân Viên Tư Vấn !')</script>");
            return;
        }
        else
        {
            foreach (GridViewRow r in gwProfilePrivateManager.Rows)
            {
                CheckBox ch = (CheckBox)r.FindControl("chkrow");
                if (ch.Checked)
                {
                    //ctId += (r.FindControl("lblRegistrationID") as Label).Text;
                    customerProPri.UpdateEmpFile(Convert.ToInt32((r.FindControl("lblProfileID") as Label).Text),2, Convert.ToInt32(dlEmployees.SelectedValue));
                    //this.registrationForm.updateProgress(1, Convert.ToInt32((r.FindControl("lblRegistrationID") as Label).Text));
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}