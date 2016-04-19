using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

public partial class Controls_ctrMultiLanguage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name) != null)
            {
                ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name).Selected = true;
            }
        }
    }
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.SetCurrentLang(ddlLanguages.SelectedValue);
        Response.Redirect(Session.GetCurrentURL());
    }
}