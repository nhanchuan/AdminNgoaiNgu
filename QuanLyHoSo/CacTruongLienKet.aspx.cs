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

public partial class QuanLyHoSo_CacTruongLienKet : BasePage
{
    public int PageSize = 10;
    CountryBLL country;
    ProvinceBLL province;
    DistrictBLL district;
    EducationLVBLL educatuionlvl;
    InternationalSchoolBLL internationalSchool;
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
                if (!check_permiss(ac.UserID, FunctionName.CacTruongLienKet))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlCountry();
                    dlProvinces.Items.Insert(0, new ListItem("-- Chọn Tiểu Bang - Tỉnh / Thành Phố --", "0"));
                    dlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận Huyện --", "0"));
                    btnEditTruong.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default disabled");
                    this.InternationalSchoolPageWise(1);
                    this.load_dlSchoolLvl();
                    this.load_dlSchoolName();
                    rptPager.Visible = true;
                    rptSearch.Visible = false;
                    this.load_dlECountry();
                    dlEProvince.Items.Insert(0, new ListItem("-- Chọn Tiểu Bang - Tỉnh / Thành Phố --", "0"));
                    dlEDistrict.Items.Insert(0, new ListItem("-- Chọn Quận Huyện --", "0"));
                }
            }
        }
    }
    private void load_dlCountry()
    {
        country = new CountryBLL();
        dlDistrict.ClearSelection();
        this.load_DropdownList(dlCountry, country.getAllCountry(), "CountryName", "CountryID");
        dlCountry.Items.Insert(0, new ListItem("-- Chọn Quốc Gia --", "0"));
    }
    protected void dlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        province = new ProvinceBLL();
        this.load_DropdownList(dlProvinces, province.getProvinceWithCid(Convert.ToInt32(dlCountry.SelectedValue)), "ProvinceName", "ProvinceID");
        dlProvinces.Items.Insert(0, new ListItem("-- Chọn Tiểu Bang - Tỉnh / Thành Phố --", "0"));
    }
    protected void dlProvinces_SelectedIndexChanged(object sender, EventArgs e)
    {
        district = new DistrictBLL();
        this.load_DropdownList(dlDistrict, district.getDistrictwithProid(Convert.ToInt32(dlProvinces.SelectedValue)), "DistrictName", "DistrictID");
        dlDistrict.Items.Insert(0, new ListItem("-- Chọn Quận Huyện --", "0"));
    }
    private void InternationalSchoolPageWise(int pageIndex)
    {
        internationalSchool = new InternationalSchoolBLL();
        int recordCount = 0;
        gwInternationalSchool.DataSource = internationalSchool.InternationalSchoolPageWise(pageIndex, PageSize);
        recordCount = internationalSchool.CountInternationalSchoolPageWise();
        gwInternationalSchool.DataBind();
        this.PopulatePager(rptPager, recordCount, pageIndex, PageSize);
        lblSumSchools.Text = recordCount.ToString();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.InternationalSchoolPageWise(pageIndex);
        //Session["pageIndexnc_lophoc"] = pageIndex.ToString();
        rptPager.Visible = true;
        rptSearch.Visible = false;
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
    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        try
        {
            internationalSchool = new InternationalSchoolBLL();
            string SchoolName = txtSchoolName.Text;
            string SchoolAddress = txtAddress.Text;
            string WebSite = txtWebSite.Text;
            string SchoolLvl = dlSchoollvl.SelectedItem.ToString();
            string AboutLink = txtAboutLink.Text;
            int CountryID = Convert.ToInt32(dlCountry.SelectedValue);
            int ProvinceID = Convert.ToInt32(dlProvinces.SelectedValue);
            int DistrictID = Convert.ToInt32(dlDistrict.SelectedValue);
            string GoogleMap = txtGooGleMap.Text;
            string Phone = txtPhone.Text;
            string namthanhlap = txtEstablish.Text;
            DateTime Establish;
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
            if (string.IsNullOrWhiteSpace(namthanhlap) || DateTime.TryParseExact(namthanhlap, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out Establish) || getday(namthanhlap) == "" || getmonth(namthanhlap) == "" || getyear(namthanhlap) == "")
            {
                Establish = Convert.ToDateTime("12/12/1900");
            }
            else
            {
                Establish = DateTime.ParseExact(getday(namthanhlap) + "/" + getmonth(namthanhlap) + "/" + getyear(namthanhlap), "dd/MM/yyyy", null);
            }


            string HocPhi = txtHocPhi.Text;
            string PhiKhac = txtPhiKhac.Text;
            string DatCoc = txtDatCoc.Text;
            string DieuKienNhapHoc = txtDieuKiennhaphoc.Text;
            string HocBong = txtHocBong.Text;
            if (internationalSchool.NewInternationalSchool(SchoolName, SchoolAddress, WebSite, SchoolLvl, AboutLink, CountryID, ProvinceID, DistrictID, GoogleMap, Phone, Establish, HocPhi, PhiKhac, DatCoc, DieuKienNhapHoc, HocBong))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {

            }

        }
        catch(Exception ex)
        {
            lblExceptionNew.Text = ex.ToString();
        }
    }
    protected void txtSchoolName_TextChanged(object sender, EventArgs e)
    {
        internationalSchool = new InternationalSchoolBLL();
        List<InternationalSchool> lst = internationalSchool.GetAllInternationalSchoolWithName(txtSchoolName.Text);
        InternationalSchool inter = lst.FirstOrDefault();
        if(inter!=null)
        {
            lblSchoolNameExist.Text = "Trường đã tồn tại. Vui lòng nhập Trường khác !";
            return;
        }
        else
        {
            lblSchoolNameExist.Text = "";
        }
    }
    private void SearchInternationalSchoolPageWise(int pageIndex, string keysearch)
    {
        internationalSchool = new InternationalSchoolBLL();
        int recordCount = 0;
        gwInternationalSchool.DataSource = internationalSchool.SearchInternationalSchoolPageWise(pageIndex, PageSize, keysearch);
        recordCount = internationalSchool.CountSearchInternationalSchoolPageWise(keysearch);
        gwInternationalSchool.DataBind();
        this.PopulatePager(rptSearch, recordCount, pageIndex, PageSize);
        lblSumSchools.Text = recordCount.ToString();
    }
    protected void Page_SearchChanged(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.SearchInternationalSchoolPageWise(pageIndex, txtsearchSchool.Value);
        rptPager.Visible = false;
        rptSearch.Visible = true;
    }
    protected void btnSearchSchools_ServerClick(object sender, EventArgs e)
    {
        this.SearchInternationalSchoolPageWise(1, txtsearchSchool.Value);
        rptPager.Visible = false;
        rptSearch.Visible = true;
    }
    protected void gwInternationalSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnEditTruong.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default");
    }
    protected void txtESchoolName_TextChanged(object sender, EventArgs e)
    {
        internationalSchool = new InternationalSchoolBLL();
        List<InternationalSchool> lst = internationalSchool.GetAllInternationalSchoolWithName(txtESchoolName.Text);
        InternationalSchool inter = lst.FirstOrDefault();
        if (inter != null)
        {
            lblESchoolNameExist.Text = "Trường đã tồn tại. Vui lòng nhập Trường khác !";
            return;
        }
        else
        {
            lblESchoolNameExist.Text = "";
        }
    }
    private void load_dlECountry()
    {
        country = new CountryBLL();
        dlEDistrict.ClearSelection();
        this.load_DropdownList(dlECountry, country.getAllCountry(), "CountryName", "CountryID");
        dlECountry.Items.Insert(0, new ListItem("-- Chọn Quốc Gia --", "0"));
    }

    protected void dlECountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        province = new ProvinceBLL();
        this.load_DropdownList(dlEProvince, province.getProvinceWithCid(Convert.ToInt32(dlEDistrict.SelectedValue)), "ProvinceName", "ProvinceID");
        dlEProvince.Items.Insert(0, new ListItem("-- Chọn Tiểu Bang - Tỉnh / Thành Phố --", "0"));
    }

    protected void dlEProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        district = new DistrictBLL();
        this.load_DropdownList(dlEDistrict, district.getDistrictwithProid(Convert.ToInt32(dlEProvince.SelectedValue)), "DistrictName", "DistrictID");
        dlEDistrict.Items.Insert(0, new ListItem("-- Chọn Quận Huyện --", "0"));
    }

    protected void btnSaveEditSchool_Click(object sender, EventArgs e)
    {
        internationalSchool = new InternationalSchoolBLL();
        try
        { 
            //int SchoolID=Convert.ToInt32((gwInternationalSchool))
            string SchoolName = txtSchoolName.Text;
            string SchoolAddress = txtAddress.Text;
            string WebSite = txtWebSite.Text;
            string SchoolLvl = dlSchoollvl.SelectedItem.ToString();
            string AboutLink = txtAboutLink.Text;
            int CountryID = Convert.ToInt32(dlCountry.SelectedValue);
            int ProvinceID = Convert.ToInt32(dlProvinces.SelectedValue);
            int DistrictID = Convert.ToInt32(dlDistrict.SelectedValue);
            string GoogleMap = txtGooGleMap.Text;
            string Phone = txtPhone.Text;
            string namthanhlap = txtEstablish.Text;
            DateTime Establish;
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
            if (string.IsNullOrWhiteSpace(namthanhlap) || DateTime.TryParseExact(namthanhlap, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out Establish) || getday(namthanhlap) == "" || getmonth(namthanhlap) == "" || getyear(namthanhlap) == "")
            {
                Establish = Convert.ToDateTime("12/12/1900");
            }
            else
            {
                Establish = DateTime.ParseExact(getday(namthanhlap) + "/" + getmonth(namthanhlap) + "/" + getyear(namthanhlap), "dd/MM/yyyy", null);
            }


            string HocPhi = txtHocPhi.Text;
            string PhiKhac = txtPhiKhac.Text;
            string DatCoc = txtDatCoc.Text;
            string DieuKienNhapHoc = txtDieuKiennhaphoc.Text;
            string HocBong = txtHocBong.Text;
        }
        catch(Exception ex)
        {
            lblExeptionEditSchool.Text = ex.ToString();
        }
    }
}
