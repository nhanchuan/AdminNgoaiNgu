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

public partial class QuanLyHoSo_KiemTraHoSoChuyen : BasePage
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
                if (!check_permiss(ac.UserID, FunctionName.NewUser))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.GetCheckProfile_AdvisoryPageWise(1);
                    btnUncheckAll.Visible = false;
                    this.load_dlEmployees();
                    dlChangeEmpPropri.Items.Insert(0, new ListItem("-- Nhân viên làm hồ sơ --", "0"));
                    rptPager.Visible = true;
                    RepeaterKeySearch.Visible = false;
                }
            }
        }
    }
    private void GetCheckProfile_AdvisoryPageWise(int pageIndex)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwProfilePrivateManager.DataSource = customerProPri.GetCheckProfile_AdvisoryPageWise(pageIndex, PageSize);
        recordCount = customerProPri.CountGetCheckProfile_AdvisoryPageWise();
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
        this.GetCheckProfile_AdvisoryPageWise(pageIndex);
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
        dlChangeEmpPropri.DataSource = employees.DropdownEmployeesWithDepartments(3);
        dlChangeEmpPropri.DataTextField = "Name";
        dlChangeEmpPropri.DataValueField = "EmployeesID";
        dlChangeEmpPropri.DataBind();
    }
    protected void btnChangeEmpAdvisory_Click(object sender, EventArgs e)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        if (dlChangeEmpPropri.SelectedValue == "0")
        {
            Response.Write("<script>alert('Chưa chọn Nhân Viên Tư Vấn !')</script>");
        }
        else
        {
            foreach (GridViewRow r in gwProfilePrivateManager.Rows)
            {
                CheckBox ch = (CheckBox)r.FindControl("chkrow");
                if (ch.Checked)
                {
                    customerProPri.UpdateEmpFile(Convert.ToInt32((r.FindControl("lblProfileID") as Label).Text),2,Convert.ToInt32(dlChangeEmpPropri.SelectedValue));
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
    private void GetCheckKeyProfile_AdvisoryPageWise(int pageIndex, string keysearch)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwProfilePrivateManager.DataSource = customerProPri.GetCheckKeyProfile_AdvisoryPageWise(pageIndex, PageSize, keysearch);
        recordCount = customerProPri.CountGetCheckKeyProfile_AdvisoryPageWise(keysearch);
        gwProfilePrivateManager.DataBind();
        this.KeySearchPopulatePager(recordCount, pageIndex);
    }
    private void KeySearchPopulatePager(int recordCount, int currentPage)
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
        this.GetCheckKeyProfile_AdvisoryPageWise(pageIndex, txtSearchProPri.Value);
    }
    protected void btnSearchProfile_ServerClick(object sender, EventArgs e)
    {
        this.GetCheckKeyProfile_AdvisoryPageWise(1, txtSearchProPri.Value);
        rptPager.Visible = false;
        RepeaterKeySearch.Visible = true;
    }
}