using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
using System.Data.SqlClient;

public partial class QuanLyHoSo_NewInternationalSchool : BasePage
{
    InternationalSchoolBLL internatoinalschool;
    CountryAdvisoryBLL countryadv;
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
                    load_dlCountry();
                    dlCountry.Items.Insert(0, new ListItem("----------------------", "0"));
                }
            }
        }
    }
    public void load_dlCountry()
    {
        countryadv = new CountryAdvisoryBLL();
        dlCountry.DataSource = countryadv.getallCountryAdvisory();
        dlCountry.DataValueField = "CountryAdvisoryID";
        dlCountry.DataTextField = "CountryName";
        dlCountry.DataBind();
    }
    protected void btnSaveInfo_Click(object sender, EventArgs e)
    {
        internatoinalschool = new InternationalSchoolBLL();
        string SchoolName = txtSchoolname.Text;
        string address = txtSchoolAddress.Text;
        string website = txtWebSite.Text;
        string schoolvl = dlSchoolLvl.SelectedItem.ToString();
        string aboutlink = txtAboutLink.Text;
        int coutry = Convert.ToInt32(dlCountry.SelectedValue);
        string map = txtmap.Text;
        string phone = txtPhone.Text;
        this.internatoinalschool.NewInternationalSchool(SchoolName, address, website, schoolvl, aboutlink, coutry, map, phone);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}