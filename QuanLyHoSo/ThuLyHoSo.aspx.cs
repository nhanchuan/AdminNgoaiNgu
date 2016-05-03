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

public partial class QuanLyHoSo_ThuLyHoSo : BasePage
{
    CustomerProfilePrivateBLL customerProPri;
    CustomerBasicInfoBLL customerBsInfo;
    UserProfileBLL userprofile;
    EmployeesBLL employees;
    BagProfileBLL bagprofile;
    BagProfileTypeBLL bagprofiletype;
    BagAttachmentsBLL bagAttachment;
    BagFileTranslateBLL bagFileTranslate;
    InternationalSchoolBLL internalSchool;
    //CountryAdvisoryBLL countryadv;
    CountryBLL country;
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
                if (!check_permiss(ac.UserID, FunctionName.ThuLyHoSo))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.Summary();
                    this.load_dlLoaiHoSo();
                    dlLoaiHoSo.Items.Insert(0, new ListItem("--  Loại hồ sơ --", "0"));
                    this.GetCheckProfile_AdvisoryPageWise(1, EmployeeID(ac.UserID));
                    this.load_userprofile(ac.UserID);
                    rptPager.Visible = true;
                    RepeaterBagType.Visible = false;
                    RepeaterKeySearch.Visible = false;
                    this.load_gwInternationalSchool();
                    this.load_dlFilterCountry();
                    //DropDownList dllcountry = (DropDownList)gwInternationalSchool.HeaderRow.FindControl("dlFilterCountry");
                    //dllcountry.Items.Insert(0, new ListItem("--Filter Country--", "0"));
                    this.load_dlSchoolLvl();
                    this.load_dlSchoolName();
                    this.loadHidden();
                }
                
            }
        }
    }
    private void load_dlLoaiHoSo()
    {
        bagprofiletype = new BagProfileTypeBLL();
        dlLoaiHoSo.DataSource = bagprofiletype.getAllBagProfileType();
        dlLoaiHoSo.DataValueField = "BagProfileTypeID";
        dlLoaiHoSo.DataTextField = "TypeName";
        dlLoaiHoSo.DataBind();
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
        lblMaNV.Text = (emp == null) ? "Mã NV: " + "#" : "Mã NV: " + emp.EmployeesCode.ToString();
        lblregency.Text = emp.Regency;
    }
    private int EmployeeID(int userId)
    {
        int empId = 0;
        userprofile = new UserProfileBLL();
        employees = new EmployeesBLL();
        List<UserProfile> lstPR = userprofile.getUserProfileWithID(userId);
        UserProfile pr = lstPR.FirstOrDefault();
        List<Employees> lstemp = (pr == null) ? new List<Employees>(): employees.getEmpWithProfileId(pr.ProfileID);
        Employees emp = lstemp.FirstOrDefault();
        empId = (emp == null) ? 0 : emp.EmployeesID;
        return empId;
    }
    private void GetCheckProfile_AdvisoryPageWise(int pageIndex, int EmpId)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwThuLyHSManager.DataSource = customerProPri.GetThuLyHoSoPageWise(pageIndex, PageSize, EmpId);
        recordCount = customerProPri.CounThuLyHoSoPageWise(EmpId);
        gwThuLyHSManager.DataBind();
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
        UserAccounts ac = Session.GetCurrentUser();
        this.GetCheckProfile_AdvisoryPageWise(pageIndex, EmployeeID(ac.UserID));
    }
    private void GetThuLyHoSoTypePageWise(int pageIndex, int EmpId, int bagtype)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwThuLyHSManager.DataSource = customerProPri.GetThuLyHoSoTypePageWise(pageIndex, PageSize, EmpId, bagtype);
        recordCount = customerProPri.CounGetThuLyHoSoTypePageWise(EmpId, bagtype);
        gwThuLyHSManager.DataBind();
        this.BagTypePopulatePager(recordCount, pageIndex);
    }
    private void BagTypePopulatePager(int recordCount, int currentPage)
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
        RepeaterBagType.DataSource = pages;
        RepeaterBagType.DataBind();
    }
    protected void BagTypePage_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        UserAccounts ac = Session.GetCurrentUser();
        this.GetThuLyHoSoTypePageWise(pageIndex, EmployeeID(ac.UserID), Convert.ToInt32(dlLoaiHoSo.SelectedValue));
    }
    protected void dlLoaiHoSo_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.GetThuLyHoSoTypePageWise(1, EmployeeID(Session.GetCurrentUser().UserID), Convert.ToInt32(dlLoaiHoSo.SelectedValue));
        rptPager.Visible = false;
        RepeaterKeySearch.Visible = false;
        RepeaterBagType.Visible = true;
    }
    private void GetSearchkeyThuLyHoSoPageWise(int pageIndex, int EmpId, string keysearch)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int recordCount = 0;
        gwThuLyHSManager.DataSource = customerProPri.GetSearchkeyThuLyHoSoPageWise(pageIndex, PageSize, EmpId, keysearch);
        recordCount = customerProPri.CounGetSearchkeyThuLyHoSoPageWise(EmpId, keysearch);
        gwThuLyHSManager.DataBind();
        this.KeyPopulatePager(recordCount, pageIndex);
    }
    private void KeyPopulatePager(int recordCount, int currentPage)
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
        UserAccounts ac = Session.GetCurrentUser();
        this.GetSearchkeyThuLyHoSoPageWise(pageIndex, EmployeeID(ac.UserID), txtsearchAdv.Value);
    }
    protected void btnSearchKey_ServerClick(object sender, EventArgs e)
    {
        this.GetSearchkeyThuLyHoSoPageWise(1, EmployeeID(Session.GetCurrentUser().UserID), txtsearchAdv.Value);
        rptPager.Visible = false;
        RepeaterBagType.Visible = false;
        RepeaterKeySearch.Visible = true;
    }
    protected void btnreload_Click(object sender, EventArgs e)
    {
        this.GetCheckProfile_AdvisoryPageWise(1, EmployeeID(Session.GetCurrentUser().UserID));
    }
    //======SUM============================================
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
        customerProPri = new CustomerProfilePrivateBLL();
        UserAccounts ac = Session.GetCurrentUser();
        lblTotalSum.Text = customerProPri.CounThuLyHoSoPageWise(EmployeeID(Session.GetCurrentUser().UserID)).ToString();
        string date = DateTime.Now.ToString("dd/MM/yyyy");
        lblDaySum.Text = customerProPri.SumBagAsDAY(EmployeeID(Session.GetCurrentUser().UserID), getday(date)).ToString();
        lblMonthSum.Text = customerProPri.SumBagAsMONTH(EmployeeID(Session.GetCurrentUser().UserID), getmonth(date)).ToString();
    }
    protected void gwThuLyHSManager_SelectedIndexChanged(object sender, EventArgs e)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int profileId = Convert.ToInt32((gwThuLyHSManager.SelectedRow.FindControl("lblProfileID") as Label).Text);
        List<CustomerProfilePrivate> lstPr = customerProPri.GetCustomerProfilePrivateWithProfileID(profileId);
        CustomerProfilePrivate cuspro = lstPr.FirstOrDefault();
        btnHSChonTruong.Attributes.Add("class", (cuspro.BagProfileTypeID == 1) ? "btn btn-success": "btn btn-success disabled");
    }
    protected void btnAction_ServerClick(object sender, EventArgs e)
    {
        customerBsInfo = new CustomerBasicInfoBLL();
        customerProPri = new CustomerProfilePrivateBLL();
        bagprofile = new BagProfileBLL();
        int profileId = Convert.ToInt32((gwThuLyHSManager.SelectedRow.FindControl("lblProfileID") as Label).Text);
        List<CustomerProfilePrivate> lstCR = customerProPri.GetCustomerProfilePrivateWithProfileID(profileId);
        CustomerProfilePrivate cuspri = lstCR.FirstOrDefault();
        List<CustomerBasicInfo> lstbs = customerBsInfo.GetCusBasicInfoWithInfoId(cuspri.InfoID);
        CustomerBasicInfo cubs = lstbs.FirstOrDefault();
        List<BagProfile> lstbag = bagprofile.GetBagProfileWithInfoID(cuspri.InfoID);
        BagProfile bag = lstbag.FirstOrDefault();
        if (gwThuLyHSManager.SelectedRow == null)
        {
            lblActionsMessage.Text = "Chưa chọn hồ sơ !";
        }
        else
        {
            int key = Convert.ToInt32(dlEmployeesAdvisory.SelectedValue);
            switch (key)
            {
                case 0:
                    lblActionsMessage.Text = "Chưa chọn hành động !";
                    break;
                case 1:
                    if (bag != null)
                    {
                        lblActionsMessage.Text = "Hồ Sơ Khách Hàng đã được làm, hoặc đang làm. Vui lòng chọn xem hồ sơ !";
                        return;
                    }
                    else
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/QuanLyHoSo/HoSoKhachHang.aspx?FileCode=" + cubs.BasicInfoCode);
                    }
                    break;
                case 2:
                    if (bag == null)
                    {
                        lblActionsMessage.Text = "Hồ Sơ Khách Hàng chưa có trên hệ thống. Vui lòng chọn làm hồ sơ !";
                        return;
                    }
                    else
                    {
                        Response.Redirect("http://" + Request.Url.Authority + "/QuanLyHoSo/HoSoKhachHang.aspx?FileCode=" + cubs.BasicInfoCode);
                    }
                    break;
            }

        }
    }
    //======Change School================================================
    protected void load_gwInternationalSchool()
    {
        internalSchool = new InternationalSchoolBLL();
        gwInternationalSchool.DataSource = internalSchool.GetTbInternationalSchool();
        gwInternationalSchool.DataBind();
    }
    private void load_dlFilterCountry()
    {
        country = new CountryBLL();
        DropDownList dllcountry = (DropDownList)gwInternationalSchool.HeaderRow.FindControl("dlFilterCountry");
        this.load_DropdownList(dllcountry, country.getAllCountry(), "CountryName", "CountryID");
        dllcountry.Items.Insert(0, new ListItem("--Select All Country--", "0"));
    }
    private void load_dlSchoolLvl()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] {
            new DataColumn("Id", typeof(int)),
            new DataColumn("Name", typeof(string))
        });
        dt.Rows.Add(0, "--Filter School--");
        dt.Rows.Add(1, "Cấp 2 , 3");
        dt.Rows.Add(2, "Cao Đẳng");
        dt.Rows.Add(3, "Đại Học");
        DropDownList dllschoollvl = (DropDownList)gwInternationalSchool.HeaderRow.FindControl("dlSchoolLvl");
        dllschoollvl.DataSource = dt;
        dllschoollvl.DataTextField = "Name";
        dllschoollvl.DataValueField = "Id";
        dllschoollvl.DataBind();
    }
    private void load_dlSchoolName()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] {
            new DataColumn("Id", typeof(int)),
            new DataColumn("Name", typeof(string))
        });
        dt.Rows.Add(0, "--Filter School Name--");   
        dt.Rows.Add(1, "Name to A --> Z");
        dt.Rows.Add(2, "Name to Z -->A");
        DropDownList dllschoolname = (DropDownList)gwInternationalSchool.HeaderRow.FindControl("dlSchoolName");
        dllschoolname.DataSource = dt;
        dllschoolname.DataTextField = "Name";
        dllschoolname.DataValueField = "Id";
        dllschoolname.DataBind();
    }
    protected void dlFilterCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        internalSchool = new InternationalSchoolBLL();
        DropDownList dllcountry = (DropDownList)gwInternationalSchool.HeaderRow.FindControl("dlFilterCountry");
       
        if (dllcountry.SelectedValue == "0")
        {
            DataTable tb = internalSchool.GetTbInternationalSchool();
            gwInternationalSchool.DataSource = tb;
            gwInternationalSchool.DataBind();
            this.load_dlFilterCountry();
            this.load_dlSchoolLvl();
            this.load_dlSchoolName();
        }
        else
        {
            DataTable tb = internalSchool.GetTbInternationalSchoolWithCountry(Convert.ToInt32(dllcountry.SelectedValue));
            if (tb.Rows.Count == 0)
            {
                return;
            }
            else
            {
                gwInternationalSchool.DataSource = tb;
                gwInternationalSchool.DataBind();
                this.load_dlFilterCountry();
                this.load_dlSchoolLvl();
                this.load_dlSchoolName();
            }
        }
    }
    protected void dlSchoolLvl_SelectedIndexChanged(object sender, EventArgs e)
    {
        internalSchool = new InternationalSchoolBLL();
        DropDownList dllschoollvl = (DropDownList)gwInternationalSchool.HeaderRow.FindControl("dlSchoolLvl");
        gwInternationalSchool.DataSource = internalSchool.GetTbInternationalSchoolWithSchoolLvl(dllschoollvl.SelectedItem.ToString());
        gwInternationalSchool.DataBind();
        this.load_dlFilterCountry();
        this.load_dlSchoolLvl();
        this.load_dlSchoolName();
    }
    protected void dlSchoolName_SelectedIndexChanged(object sender, EventArgs e)
    {
        internalSchool = new InternationalSchoolBLL();
        DropDownList dllschoolname = (DropDownList)gwInternationalSchool.HeaderRow.FindControl("dlSchoolName");
        gwInternationalSchool.DataSource = new ObjectDataSource();
        switch (Convert.ToInt32(dllschoolname.SelectedValue.ToString()))
        {
            case 1:
                gwInternationalSchool.DataSource = internalSchool.GetInternationalSchoolOrderByName(1);
                gwInternationalSchool.DataBind();
                break;
            case 2:
                gwInternationalSchool.DataSource = internalSchool.GetInternationalSchoolOrderByName(2);
                gwInternationalSchool.DataBind();
                break;
        }
        this.load_dlFilterCountry();
        this.load_dlSchoolLvl();
        this.load_dlSchoolName();
    }
    protected void btnSaveSchool_ServerClick(object sender, EventArgs e)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        int profileId = Convert.ToInt32((gwThuLyHSManager.SelectedRow.FindControl("lblProfileID") as Label).Text);
        if (gwInternationalSchool.SelectedRow == null)
        {
            Response.Write("<script>alert('Chưa chọn Trường trong danh sách !')</script>");
            return;
        }
        else
        {
            List<CustomerProfilePrivate> lstPr = customerProPri.GetCustomerProfilePrivateWithProfileID(profileId);
            CustomerProfilePrivate cuspro = lstPr.FirstOrDefault();
            //if(cuspro.InternationalSchool!=0)
            //{
            //    Response.Write("<script>alert('Hồ Sơ mã :"+cuspro.ProfileCode+" đã chọn trường !')</script>");
            //    return;
            //}
            //else
            //{
            //    int SchoolID = Convert.ToInt32((gwInternationalSchool.SelectedRow.FindControl("lblSchoolID") as Label).Text);
            //    this.customerProPri.UpdateInternationalSchool(SchoolID, profileId);
            //    Response.Redirect(Request.Url.AbsoluteUri);
            //}
            int SchoolID = Convert.ToInt32((gwInternationalSchool.SelectedRow.FindControl("lblSchoolID") as Label).Text);
            this.customerProPri.UpdateInternationalSchool(SchoolID, profileId);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
    private void loadHidden()
    {
        customerProPri = new CustomerProfilePrivateBLL();
        HiddenField1.Value = customerProPri.countProfileinCountry(222).ToString();
        HiddenField2.Value = customerProPri.countProfileinCountry(12).ToString();
        HiddenField3.Value = customerProPri.countProfileinCountry(37).ToString();
        HiddenField4.Value = customerProPri.countProfileinCountry(221).ToString();
        HiddenField5.Value = customerProPri.countProfileinCountry(203).ToString();
        HiddenField6.Value = customerProPri.countProfileinCountry(187).ToString();
        HiddenField7.Value = customerProPri.countProfileinCountry(152).ToString();
        HiddenField8.Value = customerProPri.countProfileinCountry(205).ToString();
        HiddenField9.Value = customerProPri.countProfileinCountry(149).ToString();
        HiddenField10.Value = customerProPri.countProfileinCountry(79).ToString();
        HiddenField11.Value = customerProPri.countProfileinCountry(112).ToString();
        HiddenField12.Value = customerProPri.countProfileinCountry(96).ToString();
        HiddenField13.Value = customerProPri.countProfileinCountry(128).ToString();
        HiddenField14.Value = customerProPri.countProfileinCountry(106).ToString();
        HiddenField15.Value = customerProPri.countProfileinCountry(72).ToString();
        HiddenField16.Value = customerProPri.countProfileinCountry(167).ToString();
        HiddenField17.Value = customerProPri.countProfileinCountry(71).ToString();
    }

    protected void gwThuLyHSManager_RowDataBound(object sender, GridViewRowEventArgs e)
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
    //DELETE
    private Boolean deleteBagAttachment(int bagprofileID)
    {
        bagAttachment = new BagAttachmentsBLL();
        if (!this.bagAttachment.DeleteBagProfileID(bagprofileID))
        {
            return false;
        }
        return true;
    }
    private Boolean deleteBagFileTranslate(int bagprofileID)
    {
        bagFileTranslate = new BagFileTranslateBLL();
        if (!this.bagFileTranslate.DeleteBagProfileID(bagprofileID))
        {
            return false;
        }
        return true;
    }
    private Boolean deleteBagProfile(int inforID)
    {
        bagprofile = new BagProfileBLL();
        if (!this.bagprofile.DeleteBagProfileInfoID(inforID))
        {
            return false;
        }
        return true;
    }
    private Boolean deleteCustomerProfilePrivate(int inforID)
    {
        customerProPri = new CustomerProfilePrivateBLL();
        if (!this.customerProPri.deleteCustomerProfilePrivate(inforID))
        {
            return false;
        }
        return true;
    }
    private Boolean deleteCustomerBasicInfo(int inforID)
    {
        customerBsInfo = new CustomerBasicInfoBLL();
        if (!this.customerBsInfo.deleteCustomerBasicInfo(inforID))
        {
            return false;
        }
        return true;
    }
    protected void gwThuLyHSManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bagprofile = new BagProfileBLL();
        bagAttachment = new BagAttachmentsBLL();
        bagFileTranslate = new BagFileTranslateBLL();
        //Response.Write("<script>alert('This Process is Building ! !')</script>");
        try
        {
            int InfoID = Convert.ToInt32((gwThuLyHSManager.Rows[e.RowIndex].FindControl("lblInfoID") as Label).Text);
            List<BagProfile> lstBagProfile = bagprofile.GetBagProfileWithInfoID(InfoID);
            foreach (BagProfile itm in lstBagProfile)
            {
                List<BagAttachments> lstATT = bagAttachment.getListWithBagProfileID(itm.BagProfileID);
                foreach (BagAttachments itmatt in lstATT)
                {
                    string filename = Server.MapPath("../" + itmatt.AttachmentURL);
                    if (this.bagAttachment.DeleteBagAttachments(itmatt.AttachmentID))
                    {

                        if (filename != null || filename != string.Empty)
                        {
                            if ((System.IO.File.Exists(filename)))
                            {
                                System.IO.File.Delete(filename);
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                List<BagFileTranslate> lstBFT = bagFileTranslate.getListWithBagProfileID(itm.BagProfileID);
                foreach (BagFileTranslate itmbft in lstBFT)
                {
                    string filename = Server.MapPath("../" + itmbft.FileTranslateURL);
                    if (this.bagFileTranslate.DeleteBagFileTranslate(itmbft.FileTranslateID))
                    {
                        if (filename != null || filename != string.Empty)
                        {
                            if ((System.IO.File.Exists(filename)))
                            {
                                System.IO.File.Delete(filename);
                                Response.Redirect(Request.Url.AbsoluteUri);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                this.deleteBagAttachment(itm.BagProfileID);
                this.deleteBagFileTranslate(itm.BagProfileID);
            }
            
            this.deleteBagProfile(InfoID);
            this.deleteCustomerProfilePrivate(InfoID);
            this.deleteCustomerBasicInfo(InfoID);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        catch (Exception ex)
        {
            Response.Redirect("<script>alert('" + ex.ToString() + "')</script>");
        }
        
    }
}