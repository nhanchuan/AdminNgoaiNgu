using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


public partial class Demo_In_Project_HtmlEncode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string a = WebUtility.HtmlEncode("<html><head><title>T</title></head></html>");
        string b = WebUtility.HtmlDecode(a);
        Response.Write(a);
    }
}