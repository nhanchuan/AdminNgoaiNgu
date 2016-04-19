using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class Demo_In_Project_Editer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   

    protected void btnview_Click(object sender, EventArgs e)
    {
        string content= Editor2.Content.ToString();
        txtcontent.Text = content;
    }
}