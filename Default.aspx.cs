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

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!this.IsPostBack)
        {
            UserAccounts user = Session.GetCurrentUser();
            if(user==null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                //do something
            }
        }
    }
}