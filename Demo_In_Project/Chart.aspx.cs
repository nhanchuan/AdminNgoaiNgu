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
public partial class Demo_In_Project_Chart : System.Web.UI.Page
{
    InternationalSchoolBLL internationalschool;
    CustomerProfilePrivateBLL customerpropri;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            this.loadHidden();
        }
    }

    private void loadHidden()
    {
        customerpropri = new CustomerProfilePrivateBLL();
        HiddenField1.Value = customerpropri.countProfileinCountry(1).ToString();
        HiddenField2.Value = customerpropri.countProfileinCountry(2).ToString();
        HiddenField3.Value = customerpropri.countProfileinCountry(3).ToString();
        HiddenField4.Value = customerpropri.countProfileinCountry(4).ToString();
        HiddenField5.Value = customerpropri.countProfileinCountry(5).ToString();
        HiddenField6.Value = customerpropri.countProfileinCountry(6).ToString();
        HiddenField7.Value = customerpropri.countProfileinCountry(7).ToString();
        HiddenField8.Value = customerpropri.countProfileinCountry(8).ToString();
        HiddenField9.Value = customerpropri.countProfileinCountry(9).ToString();
        HiddenField10.Value = customerpropri.countProfileinCountry(10).ToString();
        HiddenField11.Value = customerpropri.countProfileinCountry(11).ToString();
        HiddenField12.Value = customerpropri.countProfileinCountry(12).ToString();
        HiddenField13.Value = customerpropri.countProfileinCountry(13).ToString();
        HiddenField14.Value = customerpropri.countProfileinCountry(14).ToString();
        HiddenField15.Value = customerpropri.countProfileinCountry(15).ToString();
        HiddenField16.Value = customerpropri.countProfileinCountry(16).ToString();
        HiddenField17.Value = customerpropri.countProfileinCountry(17).ToString();
    }



}