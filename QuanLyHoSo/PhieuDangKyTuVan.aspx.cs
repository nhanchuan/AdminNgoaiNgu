﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;

public partial class QuanLyHoSo_PhieuDangKyTuVan : BasePage
{
    CountryBLL country;
    ProvinceBLL province;
    DistrictBLL district;
    Registration_TypeBLL registrationType;
    EducationLVBLL educationlv;
    CountryAdvisoryBLL countryAdvisory;
    REGISTRATION_FORM_ADVISORY_BLL registrationForm;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if(!IsPostBack)
        {
            UserAccounts ac = Session.GetCurrentUser();
            if(ac==null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(ac.UserID, FunctionName.PhieuDKTuVan))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    //do something
                    this.load_dlCountrys();
                    dlCountrys.Items.Insert(0, new ListItem("-- Select Country --", "0"));
                    dlProvinces.Items.Insert(0, new ListItem("-- Select Province --", "0"));
                    dlDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
                    this.load_dlRegistration_Type();
                    dlRegistration_Type.Items.Insert(0, new ListItem("-- Chọn loại tư vấn --", "0"));
                    this.load_dlEducationLV();
                    dlEducationLV.Items.Insert(0, new ListItem("-- Chọn Trình độ học vấn --", "0"));
                    this.load_dlCountryAdvisory();
                    dlCountryAdvisory.Items.Insert(0, new ListItem("-- Chọn Quốc Gia du học --", "0"));
                }
            }
        }
    }
    private void load_dlCountrys()
    {
        country = new CountryBLL();
        dlCountrys.DataSource = country.getAllCountry();
        dlCountrys.DataTextField = "CountryName";
        dlCountrys.DataValueField = "CountryID";
        dlCountrys.DataBind();
    }
    protected void dlCountrys_SelectedIndexChanged(object sender, EventArgs e)
    {
        province = new ProvinceBLL();
        dlProvinces.DataSource = province.getProvinceWithCid(int.Parse(dlCountrys.SelectedValue));
        dlProvinces.DataTextField = "ProvinceName";
        dlProvinces.DataValueField = "ProvinceID";
        dlProvinces.DataBind();
        dlProvinces.Items.Insert(0, new ListItem("-- Select Province --", "0"));
        dlDistrict.DataSource = null;
        district = new DistrictBLL();
        dlDistrict.DataSource = district.getDistrictwithProid(0);
        dlDistrict.DataTextField = "DistrictName";
        dlDistrict.DataValueField = "DistrictID";
        dlDistrict.DataBind();
        dlDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
    }
    protected void dlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        district = new DistrictBLL();
        dlDistrict.DataSource = district.getDistrictwithProid(int.Parse(dlProvinces.SelectedValue));
        dlDistrict.DataTextField = "DistrictName";
        dlDistrict.DataValueField = "DistrictID";
        dlDistrict.DataBind();
        dlDistrict.Items.Insert(0, new ListItem("-- Select District --", "0"));
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
    private string getyear(string str)
    {
        string year = str.Substring(6, 4);
        return year;
    }
    protected void btnSunmit_Click(object sender, EventArgs e)
    {
        registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
        int countryid = int.Parse(dlCountrys.SelectedValue);
        int provinceid = int.Parse(dlProvinces.SelectedValue);
        int districtid = int.Parse(dlDistrict.SelectedValue);
        int sex;
        if (!rdnam.Checked && !rdnu.Checked)
        {
            sex = 0;
        }
        else
        {
            sex = (rdnam.Checked) ? 1 : (rdnu.Checked) ? 2 : 0;
        }
        DateTime bitrhday;
        if (txtbirthday.Value=="")
        {
            bitrhday = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            bitrhday = DateTime.ParseExact(getday(txtbirthday.Value) + "/" + getmonth(txtbirthday.Value) + "/" + getyear(txtbirthday.Value), "dd/MM/yyyy", null);
        }
        int typeAdvisory =int.Parse(dlRegistration_Type.SelectedValue);
        int studylv = int.Parse(dlEducationLV.SelectedValue);
        int countryadv = int.Parse(dlCountryAdvisory.SelectedValue);
        string contentAdv = CKContentAdvisory.Text;
        if (registrationForm.NewCustomerAdvisory(txtFullName.Text, countryid, provinceid, districtid, txtAddress.Text, bitrhday, sex, txtPhone.Text, txtEmail.Text, typeAdvisory, studylv, countryadv, contentAdv, 0,0,0))
        {
            //Response.Redirect("http://" + Request.Url.Authority + "/QuanLyHoSo/QLDangKyTuVan.aspx");
            this.Clear_Form();
            Response.Write("<script>alert('Nhập Phiếu Đăng Ký Tư Vấn Thành Công !')</script>");

        }
        else
        {
            Response.Write("<script>alert('False to input !')</script>");
        }
        //Response.Write("<script>alert('" + countryadv.ToString() + "')</script>");
    }
    private void Clear_Form()
    {
        
        txtFullName.Text = "";
        txtAddress.Text = "";
        txtbirthday.Value = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        CKContentAdvisory.Text = "";
        dlCountrys.ClearSelection();
        dlProvinces.ClearSelection();
        dlDistrict.ClearSelection();
        dlRegistration_Type.ClearSelection();
        dlEducationLV.ClearSelection();
        dlCountryAdvisory.ClearSelection();
        rdnam.Checked = false;
        rdnu.Checked = false;
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.Write("<script>alert('" + getday(txtbirthday.Value) + "=>" + getmonth(txtbirthday.Value) + "=>" + getyear(txtbirthday.Value) + "')</script>");
    //}
}