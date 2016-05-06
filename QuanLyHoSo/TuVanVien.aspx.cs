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

public partial class QuanLyHoSo_TuVanVien : BasePage
{
    UserAccountsBLL useraccount;
    UserProfileBLL userprofile;
    EmployeesBLL employees;
    REGISTRATION_FORM_ADVISORY_BLL registrationForm;
    Registration_TypeBLL registrationType;
    EducationLVBLL educationlv;
    CountryAdvisoryBLL countryAdvisory;
    CustomerBasicInfoBLL customerbasicinfo;
    CustomerProfilePrivateBLL customerProPri;
    private int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!this.IsPostBack)
        {
            UserAccounts user = Session.GetCurrentUser();
            if (user == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(user.UserID, FunctionName.TuVanVien))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_userprofile(user.UserID);
                    //btnUncheckAll.Visible = false;
                    //do somthing
                    this.load_dlRegistration_Type();
                    dlRegistration_Type.Items.Insert(0, new ListItem("-- Loại tư vấn --", "0"));
                    this.load_dlEducationLV();
                    dlEducationLV.Items.Insert(0, new ListItem("-- Trình độ học vấn --", "0"));
                    this.load_dlCountryAdvisory();
                    dlCountryAdvisory.Items.Insert(0, new ListItem("-- Quốc Gia du học --", "0"));
                    rptPager.Visible = true;
                    RpSearchMore.Visible = false;
                    RepeaterKeySearch.Visible = false;
                    RepeaterFilterProgess.Visible = false;
                    this.Summary();
                }
            }
        }
    }
    protected void load_userprofile(int userId)
    {
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(userId);
        UserProfile pr = lstPR.FirstOrDefault();
        lblUserFullName.Text = pr.LastName + " " + pr.FirstName;
        lblmywebsite.Text = pr.WebsiteUrl;
        lblOccupation.Text = pr.Occupation;
        lbladdress.Text = pr.Address_ui;
        lblBirthday.Text = pr.Birthday.ToString("dd/MM/yyyy");
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        lblMaNV.Text = (emp == null) ? "Mã NV: "+"#" : "Mã NV: " + emp.EmployeesCode.ToString();
        lblregency.Text = emp.Regency;
        this.GetUserAdv_AdvisoryPageWise(1, emp.EmployeesID);
    }
    //protected void btnSelectAll_Click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow r in gwAdvisoryManager.Rows)
    //    {
    //        CheckBox ch = (CheckBox)r.FindControl("chkrow");
    //        ch.Checked = true;
    //    }
    //    btnSelectAll.Visible = false;
    //    btnUncheckAll.Visible = true;
    //}
    //protected void btnUncheckAll_Click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow r in gwAdvisoryManager.Rows)
    //    {
    //        CheckBox ch = (CheckBox)r.FindControl("chkrow");
    //        ch.Checked = false;
    //    }
    //    btnSelectAll.Visible = true;
    //    btnUncheckAll.Visible = false;
    //}
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
    private void GetUserAdv_AdvisoryPageWise(int pageIndex, int UserAdv)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int recordCount = 0;
        gwAdvisoryManager.DataSource = registrationForm.DLUserAdv_Form_AdvisoryPageWise(pageIndex, PageSize, UserAdv);
        recordCount = registrationForm.Count_DLUserAdv_Form_AdvisoryPageWise(UserAdv);
        gwAdvisoryManager.DataBind();
        this.PopulateUserAdvPager(recordCount, pageIndex);
        //lbltotalSearchDl.Text = recordCount.ToString();
    }
    private void PopulateUserAdvPager(int recordCount, int currentPage)
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
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetUserAdv_AdvisoryPageWise(pageIndex, emp.EmployeesID);
    }
    //==key search============================================================================================
    private void GetSearchKey_Emp_Form_AdvisoryPageWise(int pageIndex, string keysearch, int empId)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int recordCount = 0;
        gwAdvisoryManager.DataSource = registrationForm.SearchKey_Emp_Form_AdvisoryPageWise(pageIndex, PageSize, keysearch, empId);
        recordCount = registrationForm.Count_Emp_Form_AdvisoryPageWise(keysearch, empId);
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
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetSearchKey_Emp_Form_AdvisoryPageWise(pageIndex, txtsearchAdv.Value, emp.EmployeesID);
    }
    protected void btnsearchAdv_ServerClick(object sender, EventArgs e)
    {
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetSearchKey_Emp_Form_AdvisoryPageWise(1, txtsearchAdv.Value, emp.EmployeesID);
        rptPager.Visible = false;
        RpSearchMore.Visible = false;
        RepeaterKeySearch.Visible = true;
        RepeaterFilterProgess.Visible = false;
    }
    //==search more===========================================================================================
    private void GetMore_Emp_Form_AdvisoryPageWise(int pageIndex, int type, int edulv, int country, int empid)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int recordCount = 0;
        gwAdvisoryManager.DataSource = registrationForm.SearchMore_Emp_Form_AdvisoryPageWise(pageIndex, PageSize, type, edulv, country, empid);
        recordCount = registrationForm.CountMoreEmpForm_AdvisoryPageWise(type, edulv, country, empid);
        gwAdvisoryManager.DataBind();
        this.PopulateDLPager(recordCount, pageIndex);
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
        RpSearchMore.DataSource = pages;
        RpSearchMore.DataBind();
    }
    protected void DLPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetMore_Emp_Form_AdvisoryPageWise(pageIndex, int.Parse(dlRegistration_Type.SelectedValue), int.Parse(dlEducationLV.SelectedValue), int.Parse(dlCountryAdvisory.SelectedValue),emp.EmployeesID);
    }
    protected void btnSearchMore_Click(object sender, EventArgs e)
    {
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetMore_Emp_Form_AdvisoryPageWise(1, int.Parse(dlRegistration_Type.SelectedValue), int.Parse(dlEducationLV.SelectedValue), int.Parse(dlCountryAdvisory.SelectedValue), emp.EmployeesID);
        rptPager.Visible = false;
        RpSearchMore.Visible = true;
        RepeaterKeySearch.Visible = false;
        RepeaterFilterProgess.Visible = false;
    }
    protected void btnreload_Click(object sender, EventArgs e)
    {
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetUserAdv_AdvisoryPageWise(1, emp.EmployeesID);
    }
    protected void gwAdvisoryManager_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void GetFilterProgress_AdvisoryPageWise(int pageIndex, int ProgressForm, int UserAdv)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int recordCount = 0;
        gwAdvisoryManager.DataSource = registrationForm.FilterProgress_Form_AdvisoryPageWise(pageIndex, PageSize, ProgressForm, UserAdv);
        recordCount = registrationForm.CountFilterProgress_AdvisoryPageWise(ProgressForm, UserAdv);
        gwAdvisoryManager.DataBind();
        this.PopulateFilterProgressPager(recordCount, pageIndex);
        //lbltotalSearchDl.Text = recordCount.ToString();
    }
    private void PopulateFilterProgressPager(int recordCount, int currentPage)
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
        RepeaterFilterProgess.DataSource = pages;
        RepeaterFilterProgess.DataBind();
    }
    protected void FilterProgessPage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetFilterProgress_AdvisoryPageWise(pageIndex, Convert.ToInt32(dlProgressForm.SelectedValue),emp.EmployeesID);
    }
    protected void dlProgressForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        this.GetFilterProgress_AdvisoryPageWise(1, Convert.ToInt32(dlProgressForm.SelectedValue), emp.EmployeesID);
        rptPager.Visible = false;
        RpSearchMore.Visible = false;
        RepeaterKeySearch.Visible = false;
        RepeaterFilterProgess.Visible = true;
    }
    protected void btnAction_ServerClick(object sender, EventArgs e)
    {
        customerbasicinfo = new CustomerBasicInfoBLL();
        customerProPri = new CustomerProfilePrivateBLL();
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        string FileCode = RandomName + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
        int regisId = Convert.ToInt32((gwAdvisoryManager.SelectedRow.FindControl("lblRegistrationID") as Label).Text);
        List<CustomerProfilePrivate> lstCusPri = customerProPri.GetCustomerProfilePrivateWithRegisID(regisId);
        CustomerProfilePrivate cuspri = lstCusPri.FirstOrDefault();
        if (gwAdvisoryManager.SelectedRow == null || dlEmployeesAdvisory.SelectedValue == "0")
        {
            return;
        }
        else
        {
            int key =Convert.ToInt32(dlEmployeesAdvisory.SelectedValue);
            switch(key)
            {
                case 1:
                    if(cuspri!=null)
                    {
                        return;
                    }
                    else
                    {
                        this.customerbasicinfo.CreateBasicCodeInfo(FileCode);
                        List<CustomerBasicInfo> lstC = customerbasicinfo.GetCusBasicInfoWithCode(FileCode);
                        CustomerBasicInfo cb = lstC.FirstOrDefault();
                        this.customerProPri.CreateBasicCustPri(cb.InfoID, emp.EmployeesID, regisId);
                        this.registrationForm.updateProgress(2, regisId);
                        Response.Redirect("http://" + Request.Url.Authority + "/QuanLyHoSo/ThongTinKhachHang.aspx?FileCode=" + FileCode);
                    }
                    break;
                case 2:
                    List<CustomerBasicInfo> lstCCode = customerbasicinfo.GetCusBasicInfoWithInfoId(cuspri.InfoID);
                    CustomerBasicInfo cbCode = lstCCode.FirstOrDefault();
                    Response.Redirect("http://" + Request.Url.Authority + "/QuanLyHoSo/CapNhatThongTinKhachHang.aspx?FileCode=" + cbCode.BasicInfoCode);
                    break;
            }
            
        }
        
    }
    //======Summary===============================================================================================
    private string getday(string str)
    {
        string day = str.Substring(0, 2);
        return day;
    }
    private string getmonth(string str)
    {
        string month = str.Substring(3, 2);
        return month;
    }
    private void Summary()
    {
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(Session.GetCurrentUser().UserID);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        lblTotalSum.Text = registrationForm.SumAdv(emp.EmployeesID).ToString();
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lblDaySum.Text = registrationForm.SumAdvAsDAY(emp.EmployeesID,getday(date)).ToString();
        lblMonthSum.Text = registrationForm.SumAdvAsMONTH(emp.EmployeesID,getmonth(date)).ToString();
    }
    protected void btnreloadsum_ServerClick(object sender, EventArgs e)
    {
        this.Summary();
    }
}