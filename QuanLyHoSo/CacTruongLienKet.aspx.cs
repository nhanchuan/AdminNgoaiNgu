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

public partial class QuanLyHoSo_CacTruongLienKet : BasePage
{
    CountryBLL country;
    ProvinceBLL province;
    DistrictBLL district;
    EducationLVBLL educatuionlvl;
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
                    this.load_dlSchoollvl();
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
    private void load_dlSchoollvl()
    {
        educatuionlvl = new EducationLVBLL();
        this.load_DropdownList(dlSchoollvl, educatuionlvl.getallEducationLV(), "NAME", "ID");
        dlSchoollvl.Items.Insert(0, new ListItem("-- Chọn Cấp Độ --", "0"));
    }
}