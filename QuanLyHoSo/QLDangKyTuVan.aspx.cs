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
using System.Collections;

public partial class QuanLyHoSo_QLDangKyTuVan : BasePage
{
    Registration_TypeBLL registrationType;
    EducationLVBLL educationlv;
    CountryAdvisoryBLL countryAdvisory;
    REGISTRATION_FORM_ADVISORY_BLL registrationForm;
    EmployeesBLL employees;
    private int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        UserAccounts ac = Session.GetCurrentUser();
        if(!IsPostBack)
        {
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
                    //do somthing
                    this.load_dlRegistration_Type();
                    dlRegistration_Type.Items.Insert(0, new ListItem("-- Loại tư vấn --", "0"));
                    this.load_dlEducationLV();
                    dlEducationLV.Items.Insert(0, new ListItem("-- Trình độ học vấn --", "0"));
                    this.load_dlCountryAdvisory();
                    dlCountryAdvisory.Items.Insert(0, new ListItem("-- Quốc Gia du học --", "0"));
                    this.GetForm_AdvisoryPageWise(1);
                    //lblstartindex.Text = ((1 - 1) * PageSize + 1).ToString();
                    //lblendindex.Text = ((((1 - 1) * PageSize + 1) + PageSize) - 1).ToString();
                    btnUncheckAll.Visible = false;
                    rptPager.Visible = true;
                    Repeatersearch.Visible = false;
                    RepeaterKeySearch.Visible = false;
                    load_dlEmployeesAdvisory();
                    dlEmployeesAdvisory.Items.Insert(0, new ListItem("-- Chọn Nhân Viên Tư Vấn --", "0"));
                }
            }
        }
        
    }
    private void load_dlRegistration_Type()
    {
        registrationType = new Registration_TypeBLL();
        dlRegistration_Type.DataSource = registrationType.getAllRegistration_Type();
        dlRegistration_Type.DataValueField = "TypeID";
        dlRegistration_Type.DataTextField = "TypeName";
        dlRegistration_Type.DataBind();
    }
    private void load_dlEducationLV()
    {
        educationlv = new EducationLVBLL();
        dlEducationLV.DataSource = educationlv.getallEducationLV();
        dlEducationLV.DataValueField = "ID";
        dlEducationLV.DataTextField = "NAME";
        dlEducationLV.DataBind();
    }
    private void load_dlCountryAdvisory()
    {
        countryAdvisory = new CountryAdvisoryBLL();
        dlCountryAdvisory.DataSource = countryAdvisory.getallCountryAdvisory();
        dlCountryAdvisory.DataValueField = "CountryAdvisoryID";
        dlCountryAdvisory.DataTextField = "CountryName";
        dlCountryAdvisory.DataBind();
    }
    private void GetForm_AdvisoryPageWise(int pageIndex)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int recordCount = 0;
        gwAdvisoryManager.DataSource = registrationForm.GetForm_AdvisoryPageWise(pageIndex, PageSize);
        recordCount = registrationForm.CountRecordForm_Advisory();
        gwAdvisoryManager.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        //lbltotalRecord.Text = recordCount.ToString();
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
        this.GetForm_AdvisoryPageWise(pageIndex);
        //lblstartindex.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        //lblendindex.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();
    }
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in gwAdvisoryManager.Rows)
        {
            CheckBox ch = (CheckBox)r.FindControl("chkrow");
            ch.Checked = true;
        }
        btnSelectAll.Visible = false;
        btnUncheckAll.Visible = true;
    }
    protected void btnUncheckAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in gwAdvisoryManager.Rows)
        {
            CheckBox ch = (CheckBox)r.FindControl("chkrow");
            ch.Checked = false;
        }
        btnSelectAll.Visible = true;
        btnUncheckAll.Visible = false;
    }
    private void GetDLForm_AdvisoryPageWise(int pageIndex, int type, int edulv, int country)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int recordCount = 0;
        gwAdvisoryManager.DataSource = registrationForm.SearchDLForm_AdvisoryPageWise(pageIndex, PageSize, type, edulv, country);
        recordCount = registrationForm.Count_SearchDLForm_AdvisoryPageWise(type, edulv, country);
        gwAdvisoryManager.DataBind();
        this.PopulateDLPager(recordCount, pageIndex);
        //lbltotalSearchDl.Text = recordCount.ToString();
    }
    private void PopulateDLPager(int recordCount, int currentPage)
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
        Repeatersearch.DataSource = pages;
        Repeatersearch.DataBind();
    }
    protected void DLPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetDLForm_AdvisoryPageWise(pageIndex, int.Parse(dlRegistration_Type.SelectedValue), int.Parse(dlEducationLV.SelectedValue), int.Parse(dlCountryAdvisory.SelectedValue));
        //lblstartindex.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        //lblendindex.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();
    }
    protected void btnSearchMore_Click(object sender, EventArgs e)
    {
        this.GetDLForm_AdvisoryPageWise(1, int.Parse(dlRegistration_Type.SelectedValue), int.Parse(dlEducationLV.SelectedValue), int.Parse(dlCountryAdvisory.SelectedValue));
        //this.GetDLForm_AdvisoryPageWise(1, 1, 1,1);

        rptPager.Visible = false;
        Repeatersearch.Visible = true;
        RepeaterKeySearch.Visible = false;
    }
    protected void btnreload_ServerClick(object sender, EventArgs e)
    {
        //Response.Redirect(Request.Url.AbsoluteUri);
        this.GetForm_AdvisoryPageWise(1);
    }
    private void GetKeySearchForm_AdvisoryPageWise(int pageIndex, string keysearch)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int recordCount = 0;
        gwAdvisoryManager.DataSource = registrationForm.SearchKey_DL_Form_AdvisoryPageWise(pageIndex, PageSize, keysearch);
        recordCount = registrationForm.Count_SearchKey_DL_Form_AdvisoryPageWise(keysearch);
        gwAdvisoryManager.DataBind();
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
        this.GetKeySearchForm_AdvisoryPageWise(pageIndex, txtsearchAdv.Value);
        //lblstartindex.Text = ((pageIndex - 1) * PageSize + 1).ToString();
        //lblendindex.Text = ((((pageIndex - 1) * PageSize + 1) + PageSize) - 1).ToString();
    }
    protected void btnsearchAdv_ServerClick(object sender, EventArgs e)
    {
        this.GetKeySearchForm_AdvisoryPageWise(1, txtsearchAdv.Value);
        rptPager.Visible = false;
        Repeatersearch.Visible = false;
        RepeaterKeySearch.Visible = true;
    }
    //protected void btnSendAdvisory_Click(object sender, EventArgs e)
    //{
       
    //    string ctId = "";
    //    foreach (GridViewRow r in gwAdvisoryManager.Rows)
    //    {
    //        CheckBox ch = (CheckBox)r.FindControl("chkrow");
    //        if (ch.Checked)
    //        {
    //            ctId += (r.FindControl("lblRegistrationID") as Label).Text;
    //            Response.Write("<script>alert('" + ctId + "')</script>");
    //        }
    //    }
    //}
   private void load_dlEmployeesAdvisory()
    {
        employees = new EmployeesBLL();
        dlEmployeesAdvisory.DataSource = employees.DropdownEmployeesWithDepartments(2);
        dlEmployeesAdvisory.DataTextField = "Name";
        dlEmployeesAdvisory.DataValueField = "EmployeesID";
        dlEmployeesAdvisory.DataBind();
    }

    protected void btnSendAdv_ServerClick(object sender, EventArgs e)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        if (dlEmployeesAdvisory.SelectedValue == "0")
        {
            Response.Write("<script>alert('Chưa chọn Nhân Viên Tư Vấn !')</script>");
        }
        else
        {
            foreach (GridViewRow r in gwAdvisoryManager.Rows)
            {
                CheckBox ch = (CheckBox)r.FindControl("chkrow");
                if (ch.Checked)
                {
                    //ctId += (r.FindControl("lblRegistrationID") as Label).Text;
                    registrationForm.UpdateUserAdvisory(Convert.ToInt32(dlEmployeesAdvisory.SelectedValue), Convert.ToInt32((r.FindControl("lblRegistrationID") as Label).Text));
                    this.registrationForm.updateProgress(1, Convert.ToInt32((r.FindControl("lblRegistrationID") as Label).Text));
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        foreach (GridViewRow r in gwAdvisoryManager.Rows)
        {
            CheckBox ch = (CheckBox)r.FindControl("chkrow");
            if (ch.Checked)
            {
                registrationForm.DeleteAdvisory(Convert.ToInt32((r.FindControl("lblRegistrationID") as Label).Text));
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}